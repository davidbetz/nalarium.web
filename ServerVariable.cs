#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;

namespace Nalarium.Web
{
    //- @ServerVariable -//
    /// <summary>
    /// Common server variables.
    /// </summary>
    public static class ServerVariable
    {
        public const String ALL_HTTP = "ALL_HTTP";
        public const String ALL_RAW = "ALL_RAW";
        public const String APPL_MD_PATH = "APPL_MD_PATH";
        public const String APPL_PHYSICAL_PATH = "APPL_PHYSICAL_PATH";
        public const String AUTH_TYPE = "AUTH_TYPE";
        public const String AUTH_USER = "AUTH_USER";
        public const String AUTH_PASSWORD = "AUTH_PASSWORD";
        public const String LOGON_USER = "LOGON_USER";
        public const String REMOTE_USER = "REMOTE_USER";
        public const String CERT_COOKIE = "CERT_COOKIE";
        public const String CERT_FLAGS = "CERT_FLAGS";
        public const String CERT_ISSUER = "CERT_ISSUER";
        public const String CERT_KEYSIZE = "CERT_KEYSIZE";
        public const String CERT_SECRETKEYSIZE = "CERT_SECRETKEYSIZE";
        public const String CERT_SERIALNUMBER = "CERT_SERIALNUMBER";
        public const String CERT_SERVER_ISSUER = "CERT_SERVER_ISSUER";
        public const String CERT_SERVER_SUBJECT = "CERT_SERVER_SUBJECT";
        public const String CERT_SUBJECT = "CERT_SUBJECT";
        public const String CONTENT_LENGTH = "CONTENT_LENGTH";
        public const String CONTENT_TYPE = "CONTENT_TYPE";
        public const String GATEWAY_INTERFACE = "GATEWAY_INTERFACE";
        public const String HTTPS = "HTTPS";
        public const String HTTPS_KEYSIZE = "HTTPS_KEYSIZE";
        public const String HTTPS_SECRETKEYSIZE = "HTTPS_SECRETKEYSIZE";
        public const String HTTPS_SERVER_ISSUER = "HTTPS_SERVER_ISSUER";
        public const String HTTPS_SERVER_SUBJECT = "HTTPS_SERVER_SUBJECT";
        public const String INSTANCE_ID = "INSTANCE_ID";
        public const String INSTANCE_META_PATH = "INSTANCE_META_PATH";
        public const String LOCAL_ADDR = "LOCAL_ADDR";
        public const String PATH_INFO = "PATH_INFO";
        public const String PATH_TRANSLATED = "PATH_TRANSLATED";
        public const String QUERY_STRING = "QUERY_STRING";
        public const String REMOTE_ADDR = "REMOTE_ADDR";
        public const String REMOTE_HOST = "REMOTE_HOST";
        public const String REMOTE_PORT = "REMOTE_PORT";
        public const String REQUEST_METHOD = "REQUEST_METHOD";
        public const String SCRIPT_NAME = "SCRIPT_NAME";
        public const String SERVER_NAME = "SERVER_NAME";
        public const String SERVER_PORT = "SERVER_PORT";
        public const String SERVER_PORT_SECURE = "SERVER_PORT_SECURE";
        public const String SERVER_PROTOCOL = "SERVER_PROTOCOL";
        public const String SERVER_SOFTWARE = "SERVER_SOFTWARE";
        public const String URL = "URL";
        public const String HTTP_CONNECTION = "HTTP_CONNECTION";
        public const String HTTP_ACCEPT = "HTTP_ACCEPT";
        public const String HTTP_ACCEPT_ENCODING = "HTTP_ACCEPT_ENCODING";
        public const String HTTP_ACCEPT_LANGUAGE = "HTTP_ACCEPT_LANGUAGE";
        public const String HTTP_HOST = "HTTP_HOST";
        public const String HTTP_USER_AGENT = "HTTP_USER_AGENT";
        public const String HTTP_X_FORWARDED_FOR = "HTTP_X_FORWARDED_FOR";
        public const String HTTP_REFERRER = "HTTP_REFERER";
    }
}