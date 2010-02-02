#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web.Controls
{
    /// <summary>
    /// Adds Google Analytics to the page.
    /// </summary>
    public class GoogleAnalytics : System.Web.UI.Control
    {
        //- @TrackingCode -//
        /// <summary>
        /// Analytics tracking code including the prefix (i.e. UA-).
        /// </summary>
        public String TrackingCode { get; set; }

        //- @Path -//
        /// </summary>
        public String Path { get; set; }

        //+
        //- @Ctor -//
        public GoogleAnalytics()
        {
        }
        public GoogleAnalytics(String trackingCode)
        {
            TrackingCode = trackingCode;
        }

        //+
        //- #Render -//
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            if (String.IsNullOrEmpty(TrackingCode))
            {
                return;
            }
            String path = Path;
            if (!String.IsNullOrEmpty(path))
            {
                path = "'" + path.ToLower() + "'";
            }
            String output = @"<script type=""text/javascript"">
var gaJsHost = ((""https:"" == document.location.protocol) ? ""https://ssl."" : ""http://www."");
document.write(unescape(""%3Cscript src='"" + gaJsHost + ""google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E""));
</script>
<script type=""text/javascript"">
try{
var pageTracker = _gat._getTracker(""" + TrackingCode + @""");
pageTracker._trackPageview(" + path + @");
} catch(err) {}</script>";
            writer.Write(output);
        }
    }
}