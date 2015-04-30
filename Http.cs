#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.SessionState;
using System.Web.UI;

namespace Nalarium.Web
{
    /// <summary>
    /// Provides interaction with various HTTP information
    /// </summary>
    /// <example>
    /// if (Nalarium.Web.Http.UrlPartArray.Contains("faq"))
    /// {
    ///   //+ matches http://www.netfxharmonics.com/faq/
    /// }
    /// </example>
    public static class Http
    {
        //+ field
        private static readonly Type _httpMethodType = typeof(HttpVerbs);

        //+
        //- ~IsPageManuallyLoaded -//
        public static Page ManuallyLoadedPage
        {
            get
            {
                return HttpData.GetScopedItem<Page>(Info.Alias, Info.ManuallyLoadedPage);
            }
            set
            {
                HttpData.SetScopedItem(Info.Alias, Info.ManuallyLoadedPage, value);
            }
        }

        //- @CurrentHandler -//
        /// <summary>
        /// Gets the current handler.
        /// </summary>
        public static IHttpHandler CurrentHandler
        {
            get
            {
                return Context.CurrentHandler;
            }
        }

        //- @Method -//
        /// <summary>
        /// Gets the HTTP method
        /// </summary>
        public static HttpVerbs Method
        {
            get
            {
                try
                {
                    return (HttpVerbs)Enum.Parse(_httpMethodType, Request.HttpMethod, true);
                }
                catch
                {
                    return HttpVerbs.Unknown;
                }
            }
        }

        //- @Page -//
        /// <summary>
        /// Gets current active Page object
        /// </summary>
        public static Page Page
        {
            get
            {
                IHttpHandler handler = CurrentHandler;
                Page page;
                if ((page = handler as Page) != null)
                {
                    return (Page)handler;
                }
                page = ManuallyLoadedPage;
                if (page != null)
                {
                    return page;
                }
                var handler2 = handler as IHasPage;
                if (handler2 == null)
                {
                    return null;
                }
                page = handler2.Page;
                if (page != null)
                {
                    return page;
                }
                //+
                return null;
            }
        }

        //- @Root -//
        /// <summary>
        /// Gets the URL root.
        /// </summary>
        public static String Root
        {
            get
            {
                Int32 end;
                if (AbsoluteUrl.Contains("?"))
                {
                    end = AbsoluteUrl.IndexOf(AbsolutePath, StringComparison.OrdinalIgnoreCase);
                }
                else
                {
                    end = AbsoluteUrl.Length - AbsolutePath.Length;
                }
                //+
                return UrlCleaner.CleanWebPathTail(AbsoluteUrl.Substring(0, end));
            }
        }

        //- @ApplicationRoot -//
        /// <summary>
        /// Gets the application root.
        /// </summary>
        public static String ApplicationRoot
        {
            get
            {
                return Root + ApplicationPath;
            }
        }

        //- @ApplicationPath -//
        /// <summary>
        /// Gets the application path.
        /// </summary>
        public static String ApplicationPath
        {
            get
            {
                return Request.ApplicationPath;
            }
        }

        //- @PhysicalApplicationPath -//
        /// <summary>
        /// Gets the physical application path.
        /// </summary>
        public static String PhysicalApplicationPath
        {
            get
            {
                return Request.PhysicalApplicationPath;
            }
        }

        //- @Url -//
        /// <summary>
        /// Gets the URL.
        /// </summary>
        public static Uri Uri
        {
            get
            {
                Uri uri = Request.Url;
                if (uri.AbsoluteUri.EndsWith("default.htm"))
                {
                    return new Uri(uri.AbsoluteUri.Substring(0, uri.AbsoluteUri.IndexOf("default.htm")));
                }
                //+
                return uri;
            }
        }

        //- @IsAliased -//
        /// <summary>
        /// Tells whether is the current request is aliased (i.e. rewritten)
        /// </summary>
        public static Boolean IsAliased
        {
            get
            {
                return HttpData.GetScopedItem<Boolean>(Info.Alias, Info.IsAliased);
            }
        }

        //- @RawUrl -//
        /// <summary>
        /// Gets the raw URL.
        /// </summary>
        public static String RawUrl
        {
            get
            {
                return (RawUrlOriginalCase ?? String.Empty).ToLower(CultureInfo.CurrentCulture);
            }
        }

        //- @RawUrlOriginalCase -//
        /// <summary>
        /// Gets the raw URL.
        /// </summary>
        public static String RawUrlOriginalCase
        {
            get
            {
                return Root + "/" + UrlCleaner.CleanWebPathHead(Request.RawUrl);
            }
        }

        //- @RawPath -//
        /// <summary>
        /// Gets the raw path.
        /// </summary>
        public static String RawPath
        {
            get
            {
                return (RawPathOriginalCase ?? String.Empty).ToLower(CultureInfo.CurrentCulture);
            }
        }

        //- @RawUrlOriginalCase -//
        /// <summary>
        /// Gets the raw path.
        /// </summary>
        public static String RawPathOriginalCase
        {
            get
            {
                return Request.RawUrl;
            }
        }

        //- @AbsoluteUrl -//
        /// <summary>
        /// Gets the absolute url.
        /// </summary>
        public static String AbsoluteUrl
        {
            get
            {
                return (Uri.AbsoluteUri ?? String.Empty).ToLower(CultureInfo.CurrentCulture);
            }
        }

        //- @AbsolutePath -//
        /// <summary>
        /// Gets the absolute path.
        /// </summary>
        public static String AbsolutePath
        {
            get
            {
                return (Uri.AbsolutePath ?? String.Empty).ToLower(CultureInfo.CurrentCulture);
            }
        }

        //- @AbsoluteUrlOriginalCase -//
        /// <summary>
        /// Gets the absolute path with original case
        /// </summary>
        public static String AbsoluteUrlOriginalCase
        {
            get
            {
                return Uri.AbsoluteUri;
            }
        }

        //- @AbsolutePathOriginalCase -//
        /// <summary>
        /// Gets the absolute path with original case
        /// </summary>
        public static String AbsolutePathOriginalCase
        {
            get
            {
                return Uri.AbsolutePath;
            }
        }

        //- @UrlPartArray -//
        /// <summary>
        /// Gets the URL part array.
        /// </summary>
        public static String[] UrlPartArray
        {
            get
            {
                return AbsolutePathOriginalCase.ToLower(CultureInfo.CurrentCulture).Split('/').Where(p => !String.IsNullOrEmpty(p)).ToArray();
            }
        }

        //- @Referer -//
        /// <summary>
        /// Gets the address from which the current request came.
        /// </summary>
        public static String Referrer
        {
            get
            {
                return ReferrerOriginalCase.ToLower(CultureInfo.CurrentCulture);
            }
        }

        //- @RefererOriginalCase -//
        /// <summary>
        /// Gets the address from which the current request came with the original case.
        /// </summary>
        public static String ReferrerOriginalCase
        {
            get
            {
                return HttpData.GetServerVariableItem(ServerVariable.HTTP_REFERRER);
            }
        }

        //- @IpAddress -//
        /// <summary>
        /// Gets the client IP address.
        /// </summary>
        public static String IPAddress
        {
            get
            {
                String address = HttpData.GetServerVariableItem(ServerVariable.HTTP_X_FORWARDED_FOR);
                if (String.IsNullOrEmpty(address))
                {
                    address = HttpData.GetServerVariableItem(ServerVariable.REMOTE_ADDR);
                }
                //+
                return address ?? String.Empty;
            }
        }

        //- @Port -//
        /// <summary>
        /// Gets the HTTP port.
        /// </summary>
        public static Int32 Port
        {
            get
            {
                String root = Root;
                Int32 colon = root.IndexOf(":", root.IndexOf("//"));
                if (colon > -1)
                {
                    return Parser.Parse<Int32>(root.Substring(colon + 1, root.Length - colon - 1));
                }
                //+
                return 80;
            }
        }

        //- @Domain -//
        /// <summary>
        /// Gets the domain.
        /// </summary>
        public static String Domain
        {
            get
            {
                String root = Root;
                Int32 doubleSlash = root.IndexOf("//");
                Int32 colon = root.IndexOf(":", doubleSlash);
                if (colon > -1)
                {
                    return root.Substring(doubleSlash + 2, colon - doubleSlash - 2);
                }
                else
                {
                    return root.Substring(doubleSlash + 2, root.Length - doubleSlash - 2);
                }
            }
        }

        //- @DomainPartArray -//
        /// <summary>
        /// Gets the domain part array.
        /// </summary>
        public static String[] DomainPartArray
        {
            get
            {
                return Domain.ToLower(CultureInfo.CurrentCulture).Split('.').Where(p => !String.IsNullOrEmpty(p)).ToArray();
            }
        }

        //- @SubDomainPartArray -//
        /// <summary>
        /// Gets the subdomain part array.
        /// </summary>
        public static String[] SubDomainPartArray
        {
            get
            {
                String[] domainPartArray = DomainPartArray;
                if (domainPartArray.Length > 2)
                {
                    return ArrayModifier.Strip<String>(domainPartArray, 2);
                }
                //+
                return domainPartArray;
            }
        }

        //+
        //- @GetSubdomainPart -//

        //+
        //- @StatusCode -//
        /// <summary>
        /// Gets or sets the HTTP status code.
        /// </summary>
        public static StatusCode StatusCode
        {
            get
            {
                return (StatusCode)Response.StatusCode;
            }

            set
            {
                Response.StatusCode = (Int32)value;
            }
        }

        //+
        //- @GetUrlPart -//

        //- @AcceptedEncoding -//
        /// <summary>
        /// Gets the accepted encodings for the browser.
        /// </summary>
        public static String AcceptedEncoding
        {
            get
            {
                return Request.Headers.Get("Accept-Encoding");
            }
        }

        //- @QueryString -//
        /// <summary>
        /// Gets the raw query string.
        /// </summary>
        public static String QueryString
        {
            get
            {
                return HttpData.GetServerVariableItem(ServerVariable.QUERY_STRING);
            }
        }

        //- @QueryString -//
        /// <summary>
        /// Gets the raw query string.
        /// </summary>
        public static Map QueryStringMap
        {
            get
            {
                var map = new Map();
                var partArray = HttpData.GetServerVariableItem(ServerVariable.QUERY_STRING).Split('&');
                if (partArray.Length > 0)
                {
                    foreach (var item in partArray)
                    {
                        if (item.Contains("="))
                        {
                            var partArray2 = item.Split('=');
                            if (partArray2.Length == 2)
                            {
                                map.Add(partArray2[0], partArray2[1]);
                            }
                        }
                        else
                        {
                            map.Add(item, string.Empty);
                        }
                    }
                }
                return map;
            }
        }

        //- @UserAgent -//
        /// <summary>
        /// Gets the user agent.
        /// </summary>
        public static String UserAgent
        {
            get
            {
                return Parser.ParseString(Request.UserAgent);
            }
        }

        //+ alias
        //- @Application -//
        /// <summary>
        /// Gets the current HttpApplication.
        /// </summary>
        public static HttpApplication Application
        {
            get
            {
                return Context.ApplicationInstance;
            }
        }

        //- @Context -//
        /// <summary>
        /// Gets the current HttpContext.
        /// </summary>
        public static HttpContext Context
        {
            get
            {
                return HttpContext.Current;
            }
        }

        //- @UploadedFileCollection -//
        /// <summary>
        /// Gets a collection of uploaded files.
        /// </summary>
        public static HttpFileCollection UploadedFileCollection
        {
            get
            {
                return Request.Files;
            }
        }

        //- @Request -//
        /// <summary>
        /// Gets the current HttpRequest.
        /// </summary>
        public static HttpRequest Request
        {
            get
            {
                return Context.Request;
            }
        }

        //- @Response -//
        /// <summary>
        /// Gets the current HttpResponse.
        /// </summary>
        public static HttpResponse Response
        {
            get
            {
                return Context.Response;
            }
        }

        //- @Server -//
        /// <summary>
        /// Gets the current HttpServerUtility object.
        /// </summary>
        public static HttpServerUtility Server
        {
            get
            {
                return Context.Server;
            }
        }

        //- @Session -//
        /// <summary>
        /// Gets the HTTP session object.
        /// </summary>
        public static HttpSessionState Session
        {
            get
            {
                return Context.Session;
            }
        }

        //- @Cache -//
        /// <summary>
        /// Gets the caching object.
        /// </summary>
        public static Cache Cache
        {
            get
            {
                return Context.Cache;
            }
        }

        //- @Form -//
        /// <summary>
        /// Gets the HTTP form object
        /// </summary>
        public static NameValueCollection Form
        {
            get
            {
                return Request.Form;
            }
        }

        /// <summary>
        /// Gets a particular part of a subdomain.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>The requested part of the subdomain.</returns>
        public static String GetSubdomainPart(Position position)
        {
            return Collection.GetArrayPart(DomainPartArray, position);
        }

        /// <summary>
        /// Gets a particular part of a subdomain.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>The requested part of the subdomain.</returns>
        public static String GetSubdomainPart(Int32 position)
        {
            String[] partArray = DomainPartArray;
            if (partArray.Length >= position)
            {
                return partArray[partArray.Length - position - 1];
            }
            //+
            return String.Empty;
        }

        /// <summary>
        /// Gets a particular part of a URL
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>The requested part of the URL</returns>
        public static String GetUrlPart(Position position)
        {
            return Collection.GetArrayPart(UrlPartArray, position);
        }

        /// <summary>
        /// Gets a particular part of a URL
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>The requested part of the URL</returns>
        public static String GetUrlPart(Int32 position)
        {
            String[] partArray = UrlPartArray;
            if (partArray.Length >= position)
            {
                return partArray[partArray.Length - position - 1];
            }
            //+
            return String.Empty;
        }

        //- @Redirect -//
        /// <summary>
        /// Redirects to the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        public static void Redirect(String url)
        {
            Response.Redirect(url);
        }

        /// <summary>
        /// Redirects to the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="endResponse">Indicates whether execution of the current page should terminate.</param>
        public static void Redirect(String url, Boolean endResponse)
        {
            Response.Redirect(url, endResponse);
        }

        //- @SetSlidingCache -//
        /// <summary>
        /// Sets sliding cache for a specific number of days.
        /// </summary>
        /// <param name="days">Number of days to set for sliding cache.</param>
        public static void SetSlidingCache(Int32 days)
        {
            HttpCachePolicy cache = Response.Cache;
            cache.SetExpires(DateTime.Now + TimeSpan.FromDays(days));
            cache.SetMaxAge(TimeSpan.FromDays(days));
            cache.SetCacheability(HttpCacheability.Public);
            cache.SetValidUntilExpires(true);
            cache.SetSlidingExpiration(true);
            cache.SetETagFromFileDependencies();
        }

        #region Nested type: Info

        public static class Info
        {
            public const String Alias = "__$Alias";
            public const String TrueUrl = "TrueUrl";
            public const String IsAliased = "IsAliased";
            public const String ManuallyLoadedPage = "ManuallyLoadedPage";
        }

        #endregion
    }
}