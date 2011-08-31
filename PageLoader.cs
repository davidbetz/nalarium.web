#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Web;
using System.Web.UI;

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
            var page = PageParser.GetCompiledPageInstance(virtualPath, null, context) as Page;
            Http.ManuallyLoadedPage = page;
            page.ProcessRequest(context);
        }

        /// <summary>
        /// Loads the specific page.
        /// </summary>
        /// <param name="page">The page which to load.</param>
        public static void Load(Page page)
        {
            HttpContext context = Http.Context;
            Http.ManuallyLoadedPage = page;
            page.ProcessRequest(Http.Context);
        }
    }
}