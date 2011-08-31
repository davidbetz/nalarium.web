#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;

namespace Nalarium.Web
{
    //- @Header -//
    /// <summary>
    /// Common HTTP headers.
    /// </summary>
    public static class HttpHeader
    {
        //- @Request -//

        #region Nested type: Request

        /// <summary>
        /// Common request header names.
        /// </summary>
        public static class Request
        {
            public const String Accept = "accept";
            public const String AcceptCharset = "accept-charset";
            public const String AcceptEncoding = "accept-encoding";
            public const String AcceptLanguage = "accept-language";
            public const String AcceptRanges = "accept-ranges";
            public const String Authorization = "authorization";
            public const String CacheControl = "cache-control";
            public const String Connection = "connection";
            public const String Cookie = "cookie";
            public const String Date = "date";
            public const String Host = "host";
            public const String IfModifiedSince = "if-modified-since";
            public const String IfNoneMatch = "if-none-match";
            public const String UserAgent = "user-agent";
        }

        #endregion

        //- @Response -//

        #region Nested type: Response

        /// <summary>
        /// Common response header names.
        /// </summary>
        public static class Response
        {
            public const String AcceptRanges = "accept-ranges";
            public const String Age = "age";
            public const String Allow = "allow";
            public const String CacheControl = "cache-control";
            public const String ContentEncoding = "content-encoding";
            public const String ContentLanguage = "content-language";
            public const String ContentLength = "content-length";
            public const String ContentLocation = "content-location";
            public const String ContentDisposition = "content-disposition";
            public const String ContentMD5 = "content-md5";
            public const String ContentRange = "content-range";
            public const String ContentType = "content-type";
            public const String Date = "date";
            public const String ETag = "etag";
            public const String LastModified = "last-modified";
            public const String Location = "location";
            public const String RewriteUrl = "X-REWRITE-URL";
            public const String Server = "server";
            public const String SetCookie = "set-cookie";
        }

        #endregion
    }
}