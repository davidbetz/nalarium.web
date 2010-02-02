#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System.Web;
//+
using Nalarium.Activation;
//+
namespace Nalarium.Web
{
    public static class NonPublicHandlerFactory
    {
        //- ~CreateHttpForbiddenHandler -//
        public static IHttpHandler CreateHttpForbiddenHandler()
        {
            return ObjectCreator.CreateWithNonPublicConstructorAs<System.Web.IHttpHandler>(AssemblyName.SystemWeb, "System.Web.HttpForbiddenHandler");
        }

        //- ~CreateStaticFileHandler -//
        public static IHttpHandler CreateStaticFileHandler()
        {
            return ObjectCreator.CreateWithNonPublicConstructorAs<System.Web.IHttpHandler>(AssemblyName.SystemWeb, "System.Web.StaticFileHandler");
        }

        //- ~CreateHttpNotFoundHandler -//
        public static IHttpHandler CreateHttpNotFoundHandler()
        {
            return ObjectCreator.CreateWithNonPublicConstructorAs<System.Web.IHttpHandler>(AssemblyName.SystemWeb, "System.Web.HttpNotFoundHandler");
        }
    }
}