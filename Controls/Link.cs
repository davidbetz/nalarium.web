#region Copyright
//+ Themelia Pro 2.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2007-2009
#endregion
using System;
//+
namespace Themelia.Web.Controls
{
    /// <summary>
    /// Allows quick showing of web domain-aware links.
    /// </summary>
    public class Link : System.Web.UI.Control
    {
        //- @LinkMode -//
        /// <summary>
        /// Type of link to show.
        /// </summary>
        public LinkMode LinkMode { get; set; }

        //- @Text -//
        /// <summary>
        /// Text to show in the link.  If blank, a localized default will be used.
        /// </summary>
        public String Text { get; set; }

        //+
        //- #Render -//
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            String target = String.Empty;
            String textKey = String.Empty;
            String text = String.Empty;
            switch (LinkMode)
            {
                case LinkMode.RemoveOneParameter:
                    target = String.Join("/", ArrayModifier.Strip<String>(Http.UrlPartArray));
                    textKey = "Path_UpOneLevel";
                    break;
                case LinkMode.CurrentWebDomain:
                    target = Http.WebDomain.Path;
                    textKey = "Path_WebDomain";
                    break;
                case LinkMode.CurrentEndpoint:
                    target = Http.WebDomain.EndpointPath;
                    textKey = "Path_Endpoint";
                    break;
                case LinkMode.RootWebDomain:
                    target = "/";
                    textKey = "Path_Home";
                    break;
                default:
                    break;
            }
            if (!String.IsNullOrEmpty(Text))
            {
                text = Text;
            }
            else
            {
                text = Themelia.Web.Globalization.ResourceAccessor.GetString(textKey);
            }
            writer.Write(@"<a href=""" + target+ @""">" + text + @"</a>");
            //+
            base.Render(writer);
        }
    }
}