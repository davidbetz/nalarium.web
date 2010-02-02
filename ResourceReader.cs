#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
using System.IO;
using System.Reflection;
using System.Web.UI;
//+
namespace Nalarium.Web
{
    public static class ResourceReader
    {
        //- @ReadResource -//
        public static string ReadResource(string assemblyName, string resourceName, out string contentType)
        {
            return ReadResource(Assembly.Load(assemblyName), resourceName, out contentType);
        }
        public static string ReadResource(Assembly assembly, string resourceName, out string contentType)
        {
            contentType = ReadContentType(assembly, resourceName);
            UnmanagedMemoryStream resourceStream = (UnmanagedMemoryStream)assembly.GetManifestResourceStream(resourceName);
            if (resourceStream != null)
            {
                StreamReader reader = new StreamReader(resourceStream, true);
                return reader.ReadToEnd();
            }
            //+
            return String.Empty;
        }

        //- @ReadContentType -//
        public static String ReadContentType(string assemblyName, String resourceName)
        {
            return ReadContentType(Assembly.Load(assemblyName), resourceName);
        }
        public static String ReadContentType(Assembly assembly, String resourceName)
        {
            WebResourceAttribute webResourceAttribute = ReadWebResourceAttribute(assembly, resourceName);
            if (webResourceAttribute == null)
            {
                return String.Empty;
            }
            //+
            return webResourceAttribute.ContentType;
        }

        //- @ReadWebResourceAttribute -//
        public static WebResourceAttribute ReadWebResourceAttribute(string assemblyName, String resourceName)
        {
            return ReadWebResourceAttribute(Assembly.Load(assemblyName), resourceName);
        }
        public static WebResourceAttribute ReadWebResourceAttribute(Assembly assembly, String resourceName)
        {
            Object[] attributeArray = assembly.GetCustomAttributes(typeof(WebResourceAttribute), false);
            if (attributeArray == null)
            {
                return null;
            }
            //+
            foreach (Object item in attributeArray)
            {
                WebResourceAttribute webResourceAttribute = item as WebResourceAttribute;
                if (webResourceAttribute == null)
                {
                    continue;
                }
                if (webResourceAttribute.WebResource == resourceName)
                {
                    return webResourceAttribute;
                }
            }
            //+
            return null;
        }
    }
}