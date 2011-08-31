#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Caching;
using System.Web.SessionState;
using System.Web.UI;
using Nalarium.IO;

namespace Nalarium.Web
{
    /// <summary>
    /// Provides streamlined interaction with HTTP data.
    /// </summary>
    /// <remarks>
    /// HttpData allows generic access to the items context collection,
    /// session information, and cookie information.  It also allows
    /// scoped access of each of these.
    /// 
    /// In componentized scenarios, scoping should always be used.  This
    /// prevents data namespace collisions.  The example below shows
    /// an item named ProjectName::Count being set in the items context
    /// collection.
    /// </remarks>
    /// <example>
    /// Int32 itemCount = 7;
    /// Http.SetScopedItem&lt;Int32&gt;("ProjectName", "Count", itemCount);
    /// 
    /// itemCount = Http.GetScopedItem&lt;Int32&gt;("ProjectName", "Count");
    /// </example>
    public static class HttpData
    {
        //- @Info -//

        //- @DataStateType -//

        #region DataStateType enum

        public enum DataStateType
        {
            Item = 1,
            Session = 2
        }

        #endregion

        //+
        //+ get
        //- @GetItem -//
        /// <summary>
        /// Gets an item from the HTTP context.
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="name">The name of the item.</param>
        /// <returns>The item value or the default value of the item type.</returns>
        public static T GetItem<T>(String name)
        {
            HttpContext context = Http.Context;
            if (context.Items[name] is T)
            {
                return (T)context.Items[name];
            }
            //+
            return default(T);
        }

        //- @GetCacheItem -//
        /// <summary>
        /// Gets an item from the HTTP cache.
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="name">The name of the item.</param>
        /// <returns>The item value or the default value of the item type.</returns>
        public static T GetCacheItem<T>(String name)
        {
            HttpContext context = Http.Context;
            if (context.Cache.Get(name) is T)
            {
                return (T)context.Cache.Get(name);
            }
            //+
            return default(T);
        }

        //- @GetSessionItem -//
        /// <summary>
        /// Gets an item from the HTTP session.
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="name">The name of the item.</param>
        /// <returns>The item value or the default value of the item type.</returns>
        public static T GetSessionItem<T>(String name)
        {
            try
            {
                HttpContext context = Http.Context;
                if (context.Session[name] is T)
                {
                    return (T)context.Session[name];
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.Session_NotAvailable, ex);
            }
            //+
            return default(T);
        }

        //+ get scoped
        //- @GetScopedItem -//
        /// <summary>
        /// Gets a scoped/namespaced item from the HTTP context.
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="scope">The scope of the item</param>
        /// <param name="name">The name of the item.</param>
        /// <returns>The item value or the default value of the item type.</returns>
        public static T GetScopedItem<T>(String scope, String name)
        {
            var t = GetItem<T>(scope + "::" + name);
            if (t != null)
            {
                return t;
            }
            //+
            return default(T);
        }

        //- @GetScopedCacheItem -//
        /// <summary>
        /// Gets a scoped/namespaced item from the HTTP cache.
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="scope">The scope of the item</param>
        /// <param name="name">The name of the item.</param>
        /// <returns>The item value or the default value of the item type.</returns>
        public static T GetScopedCacheItem<T>(String scope, String name)
        {
            var t = GetCacheItem<T>(scope + "::" + name);
            if (t != null)
            {
                return t;
            }
            return default(T);
        }

        //- @GetScopedSessionItem -//
        /// <summary>
        /// Gets a scoped/namespaced item from the HTTP session.
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="scope">The scope of the item</param>
        /// <param name="name">The name of the item.</param>
        /// <returns>The item value or the default value of the item type.</returns>
        public static T GetScopedSessionItem<T>(String scope, String name)
        {
            var t = GetSessionItem<T>(scope + "::" + name);
            if (t != null)
            {
                return t;
            }
            return default(T);
        }

        //+ set
        //- @SetItem -//
        /// <summary>
        /// Set an item in the HTTP context.
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="name">The name of the item.</param>
        /// <param name="item">The value of the item.</param>
        public static void SetItem<T>(String name, T item)
        {
            Http.Context.Items[name] = item;
        }

        //- @SetCacheItem -//
        /// <summary>
        /// Set an item in the HTTP cache.
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="name">The name of the item.</param>
        /// <param name="item">The value of the item.</param>
        public static void SetCacheItem<T>(String name, T item)
        {
            Http.Cache.Insert(name, item);
        }

        /// <summary>
        /// Set an item in the HTTP cache.
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="name">The name of the item.</param>
        /// <param name="item">The value of the item.</param>
        /// <param name="slidingExpiration"></param>
        public static void SetCacheItem<T>(String name, T item, TimeSpan slidingExpiration)
        {
            //++ parameter 4 requires NoSlidingExpiration to be set; thus it's ignored
            Http.Cache.Insert(name, item, null, DateTime.MaxValue, slidingExpiration);
        }

        /// <summary>
        /// Set an item in the HTTP cache.
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="name">The name of the item.</param>
        /// <param name="item">The value of the item.</param>
        /// <param name="cacheDependency">The file or cache key dependencies for the item. When any dependency changes, the object becomes invalid and is removed from the cache./param>
        /// <param name="slidingExpiration">The time at which the inserted object expires and is removed from the cache.</param>
        public static void SetCacheItem<T>(String name, T item, CacheDependency cacheDependency, TimeSpan slidingExpiration)
        {
            Http.Cache.Insert(name, item, cacheDependency, DateTime.MaxValue, slidingExpiration);
        }

        /// <summary>
        /// Set an item in the HTTP cache.
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="name">The name of the item.</param>
        /// <param name="item">The value of the item.</param>
        /// <param name="cacheDependency">The file or cache key dependencies for the item. When any dependency changes, the object becomes invalid and is removed from the cache./param>
        /// <param name="onUpdateCallback">A delegate that, if provided, will be called when an object is removed from the cache. You can use this to notify applications when their objects are deleted from the cache.</param>
        public static void SetCacheItem<T>(String name, T item, CacheDependency cacheDependency, TimeSpan slidingExpiration, CacheItemUpdateCallback onUpdateCallback)
        {
            Http.Cache.Insert(name, item, cacheDependency, DateTime.MaxValue, slidingExpiration, onUpdateCallback);
        }

        //- @SetSessionItem -//
        /// <summary>
        /// Set an item in the HTTP session.
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="name">The name of the item.</param>
        /// <param name="item">The value of the item.</param>
        public static void SetSessionItem<T>(String name, T item)
        {
            try
            {
                Http.Session[name] = item;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.Session_NotAvailable, ex);
            }
        }

        //+ set scoped
        //- @SetScopedItem -//
        /// <summary>
        /// Sets a scoped/namespaced item in the HTTP context.
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="scope">The scope of the item</param>
        /// <param name="name">The name of the item.</param>
        /// <param name="item">The value of the item.</param>
        public static void SetScopedItem<T>(String scope, String name, T item)
        {
            SetItem(scope + "::" + name, item);
        }

        //- @SetScopedCacheItem -//
        /// <summary>
        /// Sets a scoped/namespaced item in the HTTP cache.
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="scope">The scope of the item</param>
        /// <param name="name">The name of the item.</param>
        /// <param name="item">The value of the item.</param>
        public static void SetScopedCacheItem<T>(String scope, String name, T item)
        {
            SetCacheItem(scope + "::" + name, item);
        }

        //- @SetScopedSessionItem -//
        /// <summary>
        /// Sets a scoped/namespaced item in the HTTP session.
        /// </summary>
        /// <typeparam name="T">Type of the item.</typeparam>
        /// <param name="scope">The scope of the item</param>
        /// <param name="name">The name of the item.</param>
        /// <param name="item">The value of the item.</param>
        public static void SetScopedSessionItem<T>(String scope, String name, T item)
        {
            SetSessionItem(scope + "::" + name, item);
        }

        //+ import
        //- @ImportItemMap -//
        /// <summary>
        /// Imports the item map into HTTP context items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="map">The map to import</param>
        public static void ImportItemMap<T>(Map<String, T> map)
        {
            List<String> keyList = map.GetKeyList();
            foreach (String key in keyList)
            {
                SetItem(key, map[key]);
            }
        }

        //- @ImportCacheMap -//
        /// <summary>
        /// Imports the item map into HTTP cache items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="map">The map to import</param>
        public static void ImportCacheMap<T>(Map<String, T> map)
        {
            List<String> keyList = map.GetKeyList();
            foreach (String key in keyList)
            {
                SetItem(key, map[key]);
            }
        }

        //- @ImportSessionMap -//
        /// <summary>
        /// Imports the item map into HTTP sesson items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="map">The map to import</param>
        public static void ImportSessionMap<T>(Map<String, T> map)
        {
            List<String> keyList = map.GetKeyList();
            foreach (String key in keyList)
            {
                SetSessionItem(key, map[key]);
            }
        }


        //- @ExportScope -//
        /// <summary>
        /// Exports a map containing all the information in a particular items scope.
        /// </summary>
        /// <typeparam name="Type of map to return"></typeparam>
        /// <param name="stateType">The data store type (item or session) from which to pull the scope data</param>
        /// <param name="scope">The name of the scope</param>
        /// <returns>Populated map containins the information in a particular scope.</returns>
        public static T ExportScope<T>(DataStateType stateType, String scope) where T : Map, new()
        {
            if (stateType != DataStateType.Item && stateType != DataStateType.Session)
            {
                throw new InvalidOperationException(Resource.HttpData_ExportScopeInvalidUse);
            }
            var map = new T();
            String scopePrefix = scope + "::";
            if (stateType == DataStateType.Item)
            {
                IDictionary itemStore = Http.Context.Items;
                foreach (Object item in itemStore)
                {
                    var dictionaryEntry = (DictionaryEntry)item;
                    String str = dictionaryEntry.Key as String ?? String.Empty;
                    if (str.StartsWith(scopePrefix, StringComparison.OrdinalIgnoreCase))
                    {
                        str = str.Substring(scopePrefix.Length, str.Length - scopePrefix.Length);
                        Object value = dictionaryEntry.Value;
                        map.Add(str, value as String ?? value + " [Converted]");
                    }
                }
            }
            if (stateType == DataStateType.Session)
            {
                HttpSessionState sessionStore = Http.Session;
                foreach (String str in sessionStore)
                {
                    String strClean = str;
                    if (str.StartsWith(scopePrefix, StringComparison.OrdinalIgnoreCase))
                    {
                        strClean = str.Substring(scopePrefix.Length, str.Length - scopePrefix.Length);
                        Object value = sessionStore[str];
                        map.Add(strClean, value as String ?? value + " [Converted]");
                    }
                }
            }
            //+
            return map;
        }

        /// <summary>
        /// Imports the item map into the a specific scoped/namespaced set of HTTP context items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="scope">The scope of the item</param>
        /// <param name="map">The map to import</param>
        public static void ImportScopedItemMap<T>(String scope, Map<String, T> map)
        {
            List<String> keyList = map.GetKeyList();
            foreach (String key in keyList)
            {
                SetScopedItem(scope, key, map[key]);
            }
        }

        //- @ImportCacheMap -//
        /// <summary>
        /// Imports the item map into the a specific scoped/namespaced set of HTTP cache items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="scope">The scope of the item</param>
        /// <param name="map">The map to import</param>
        public static void ImportScopedCacheMap<T>(String scope, Map<String, T> map)
        {
            List<String> keyList = map.GetKeyList();
            foreach (String key in keyList)
            {
                SetScopedItem(scope, key, map[key]);
            }
        }

        //- @ImportSessionMap -//
        /// <summary>
        /// Imports the item map into the a specific scoped/namespaced set of HTTP sesson items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="scope">The scope of the item</param>
        /// <param name="map">The map to import</param>
        public static void ImportScopedSessionMap<T>(String scope, Map<String, T> map)
        {
            List<String> keyList = map.GetKeyList();
            foreach (String key in keyList)
            {
                SetScopedSessionItem(scope, key, map[key]);
            }
        }

        //+ content
        //- @GetHTTPInput -//
        /// <summary>
        /// Gets the HTTP request input as specific type
        /// </summary>
        /// <typeparam name="T">Desired type of return data</typeparam>
        /// <returns>The input content byte array (null if no content).</returns>
        public static T GetHttpInput<T>()
        {
            return Parser.Parse<T>(GetInputHttpString());
        }

        //- @InputContentString -//
        /// <summary>
        /// Gets the HTTP request input content string.
        /// </summary>
        /// <value>The input content string (blank string if no content).</value>
        public static String GetInputHttpString()
        {
            return StreamConverter.GetStreamText(GetInputHttpStream());
        }

        //- @InputStream -//
        /// <summary>
        /// Gets the HTTP request stream.
        /// </summary>
        /// <value>The request stream.</value>
        public static Stream GetInputHttpStream()
        {
            return Http.Request.InputStream;
        }

        //- @InputByteArray -//
        /// <summary>
        /// Gets the HTTP request input content byte array.
        /// </summary>
        /// <value>The input content byte array (null if no content).</value>
        public static Byte[] GetInputHttpByteArray()
        {
            return StreamConverter.GetStreamByteArray(GetInputHttpStream());
        }

        //+ query
        //- @GetQueryItem -//
        /// <summary>
        /// Gets the query item.
        /// </summary>
        /// <param name="name">The key of the query string item to return</param>
        /// <returns>Query string item</returns>
        public static String GetQueryItem(String name)
        {
            return Parser.ParseString(Http.Request.QueryString[name]);
        }

        /// <summary>
        /// Gets the query item or, if the item is missing, the default value.
        /// </summary>
        /// <param name="name">The key of the query string item to return</param>
        /// <param name="defaultValue">The default value to return if the item is missing.</param>
        /// <returns>Query string item</returns>
        public static String GetQueryItem(String name, String defaultValue)
        {
            String value = GetQueryItem(name);
            if (String.IsNullOrEmpty(value))
            {
                return defaultValue;
            }
            //+
            return value;
        }

        //- @GetQueryItemMap -//
        /// <summary>
        /// Gets a query string information as a map
        /// </summary>
        /// <returns>Map populated with query string data.</returns>
        public static Map GetQueryItemMap()
        {
            var map = new Map();
            map.AddQueryString(Http.QueryString);
            //+
            return map;
        }

        //+ cookie
        //- @GetCookie -//
        /// <summary>
        /// Gets an HTTP cookie value.
        /// </summary>
        /// <param name="name">The name of the cookie</param>
        /// <returns>The value of the cookie</returns>
        public static String GetCookie(String name)
        {
            HttpCookieCollection cookieCollection = Http.Request.Cookies;
            //+
            HttpCookie cookie = cookieCollection[name];
            if (cookie != null)
            {
                return cookie.Value ?? string.Empty;
            }
            //+
            return String.Empty;
        }

        //- @SetCookie -//
        /// <summary>
        /// Sets a cookie
        /// </summary>
        /// <param name="name">The name of the cookie</param>
        /// <param name="value">The value of the cookie</param>
        public static void SetCookie(String name, String value)
        {
            HttpCookieCollection cookieCollection = Http.Response.Cookies;
            //+
            var cookie = new HttpCookie(name, value);
            cookie.Path = "/";
            cookieCollection.Set(cookie);
        }

        /// <summary>
        /// Sets a cookie
        /// </summary>
        /// <param name="name">The name of the cookie</param>
        /// <param name="value">The value of the cookie</param>
        /// <param name="timeSpan">The duration a cookie should last</param>
        public static void SetCookie(String name, String value, TimeSpan timeSpan)
        {
            HttpCookieCollection cookieCollection = Http.Response.Cookies;
            //+
            var cookie = new HttpCookie(name, value);
            cookie.Expires = DateTime.Now.Add(timeSpan);
            cookie.Path = "/";
            cookieCollection.Set(cookie);
        }

        /// <summary>
        /// Sets a cookie
        /// </summary>
        /// <param name="name">The name of the cookie</param>
        /// <param name="value">The value of the cookie</param>
        /// <param name="dateTime">The expiration date of the cookie</param>
        public static void SetCookie(String name, String value, DateTime dateTime)
        {
            HttpCookieCollection cookieCollection = Http.Response.Cookies;
            //+
            var cookie = new HttpCookie(name, value);
            cookie.Expires = dateTime;
            cookie.Path = "/";
            cookieCollection.Set(cookie);
        }

        //+ server variable
        //- @GetServerVariableItem -//
        /// <summary>
        /// Gets the header item.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static String GetServerVariableItem(String name)
        {
            return Parser.ParseString(Http.Request.ServerVariables[name]);
        }

        /// <summary>
        /// Gets the header item or, if the item is missing, the default value.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="defaultValue">The default value to return if the item is missing.</param>
        /// <returns></returns>
        public static String GetServerVariableItem(String name, String defaultValue)
        {
            String value = GetServerVariableItem(name);
            if (String.IsNullOrEmpty(value))
            {
                return defaultValue;
            }
            //+
            return value;
        }

        //+ header
        //- @GetHeaderItem -//
        /// <summary>
        /// Gets the header item.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static String GetHeaderItem(String name)
        {
            return Parser.ParseString(Http.Request.Headers[name]);
        }

        /// <summary>
        /// Gets the header item or, if the item is missing, the default value.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="defaultValue">The default value to return if the item is missing.</param>
        /// <returns></returns>
        public static String GetHeaderItem(String name, String defaultValue)
        {
            String value = GetHeaderItem(name);
            if (String.IsNullOrEmpty(value))
            {
                return defaultValue;
            }
            //+
            return value;
        }

        //- @SetHeaderItem -//
        /// <summary>
        /// Sets the header item.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public static void SetHeaderItem(String name, String value)
        {
            Http.Response.AddHeader(name, value);
        }

        //- @GetHeaderItemMap -//
        /// <summary>
        /// Gets a series of header items as a Map.
        /// </summary>
        /// <param name="parameterArray">Names of the header elements to return in the map.</param>
        /// <returns></returns>
        public static Map GetHeaderItemMap(params String[] parameterArray)
        {
            return GetHeaderItemMap(false, parameterArray);
        }

        /// <summary>
        /// Gets a series of header items as a Map.
        /// </summary>
        /// <param name="ensure">If true, all values must be non-blank.  If any values are blank, null is returned.</param>
        /// <param name="parameterArray">Names of the header elements to return in the map.</param>
        /// <returns></returns>
        public static Map GetHeaderItemMap(Boolean ensure, params String[] parameterArray)
        {
            var map = new Map();
            if (parameterArray != null)
            {
                foreach (String item in parameterArray)
                {
                    String value = GetHeaderItem(item, String.Empty);
                    if (!String.IsNullOrEmpty(value) || !ensure)
                    {
                        map.Add(item, value);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            //+
            return map;
        }

        //+ capture
        //- @GetCaptureItem -//
        /// <summary>
        /// Gets an item that was captured in aliasing.
        /// </summary>
        /// <param name="name">The name of the item captured</param>
        /// <returns>Value of the captured item</returns>
        public static String GetCaptureItem(String name)
        {
            return GetScopedItem<String>(Info.Capture, name);
        }

        /// <summary>
        /// Gets all items capturedd uring aliasing.
        /// </summary>
        /// <returns>Map populated with variables captured in aliasing</returns>
        public static Map GetCaptureItemMap()
        {
            return ExportScope<Map>(DataStateType.Item, Info.Capture);
        }

        //+ control
        //- @GetControlValue -//
        /// <summary>
        /// Gets an ASP.NET control value without accessing the control directly.
        /// </summary>
        /// <param name="name">The name of the control</param>
        /// <returns></returns>
        public static String GetControlValue(String name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                Page page = Http.Page;
                if (page != null)
                {
                    Control control = ControlFinder.FindControlRecursively(page, name);
                    if (control != null)
                    {
                        return Http.Form[control.UniqueID];
                    }
                }
            }
            //+
            return String.Empty;
        }

        #region Nested type: Info

        public static class Info
        {
            public const String Capture = "Capture";
        }

        #endregion
    }
}