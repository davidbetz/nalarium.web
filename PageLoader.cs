#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
using System.Web;
//+
namespace Nalarium.Web
{
    /// <summary>
    /// Handles direct page aliasing.
    /// </summary>
    public static class PageLoader
    {
        //- @PageLoader -//
        /// <summary>
        /// Compiles and loads the specific page.
        /// </summary>
        /// <param name="virtualPath">The virtual path specifying the ASPX page to load.</param>
        public static void Load(String virtualPath)
        {
            HttpContext context = Http.Context;
            System.Web.UI.Page page = System.Web.UI.PageParser.GetCompiledPageInstance(virtualPath, null, context) as System.Web.UI.Page;
            Http.ManuallyLoadedPage = page;
            page.ProcessRequest(context);
        }
        /// <summary>
        /// Loads the specific page.
        /// </summary>
        /// <param name="page">The page which to load.</param>
        public static void Load(System.Web.UI.Page page)
        {
            HttpContext context = Http.Context;
            Http.ManuallyLoadedPage = page;
            page.ProcessRequest(Http.Context);
        }
    }
}