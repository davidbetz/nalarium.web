#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Web;
using System.Web.Caching;
using System.Web.Management;
using System.Web.UI;
using Nalarium.Activation;

namespace Nalarium.Web.Configuration.Activation
{
    internal class WebExceptionTypeFactory : TypeFactory
    {
        //- @CreateObject -//
        public override Type CreateType(String text)
        {
            Type ex = null;
            switch (text)
            {
                case "http":
                    return Nalarium.Activation.TypeCache.InlineRegister(typeof(HttpException));
                case "httpunhandled":
                    return Nalarium.Activation.TypeCache.InlineRegister(typeof(HttpUnhandledException));
                case "httpcompile":
                    return Nalarium.Activation.TypeCache.InlineRegister(typeof(HttpCompileException));
                case "httpparse":
                    return Nalarium.Activation.TypeCache.InlineRegister(typeof(HttpParseException));
                case "httprequestvalidation":
                    return Nalarium.Activation.TypeCache.InlineRegister(typeof(HttpRequestValidationException));
                case "databasenotenabledfornotification":
                    return Nalarium.Activation.TypeCache.InlineRegister(typeof(DatabaseNotEnabledForNotificationException));
                case "tablenotenabledfornotification":
                    return Nalarium.Activation.TypeCache.InlineRegister(typeof(TableNotEnabledForNotificationException));
                case "sqlexecution":
                    return Nalarium.Activation.TypeCache.InlineRegister(typeof(SqlExecutionException));
                case "viewstate":
                    return Nalarium.Activation.TypeCache.InlineRegister(typeof(ViewStateException));
            }
            //+
            return ex;
        }
    }
}