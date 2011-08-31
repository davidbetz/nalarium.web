#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System.Web;

namespace Nalarium.Web
{
    public abstract class ApplicationInitializer
    {
        //- @Context -//
        /// <summary>
        /// Gets the HttpContext.
        /// </summary>
        public HttpContext Context { get; set; }

        //- @OnStartup -//
        /// <summary>
        /// Runs the app-processor; which runs when the application or session is initialized.
        /// </summary>
        /// <param name="context">The HttpContext object.</param>
        /// <param name="parameterArray">The optional parameter array.</param>
        public abstract void OnStartup();

        //- @OnShutdown -//
        /// <summary>
        /// Runs the app-processor; which runs when the application or session is shutdown.
        /// </summary>
        /// <param name="context">The HttpContext object.</param>
        /// <param name="parameterArray">The optional parameter array.</param>
        public virtual void OnShutdown()
        {
            //+ blank
        }
    }
}