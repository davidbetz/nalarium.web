#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web.Controls
{
    /// <summary>
    /// Used to localize text in an ASP.NET page using a standard .NET resource file.
    /// </summary>
    public class LocalizedText : System.Web.UI.Control
    {
        //- @String -//
        /// <summary>
        /// The resource key used to lookup the localized string.
        /// </summary>
        public String Key { get; set; }

        //- @Parameter1 -//
        /// <summary>
        /// Text to replace {0} in your localized string.
        /// </summary>
        public String Parameter1 { get; set; }

        //- @Parameter2 -//
        /// <summary>
        /// Text to replace {1} in your localized string (only works when Parameter1 is populated).
        /// </summary>
        public String Parameter2 { get; set; }

        //- @Parameter3 -//
        /// <summary>
        /// Text to replace {2} in your localized string (only works when Parameter1 and Parameter2 are populated).
        /// </summary>
        public String Parameter3 { get; set; }

        //+
        //- @Ctor -//
        public LocalizedText()
        {
        }
        public LocalizedText(String key)
        {
            Key = key;
        }

        //+
        //- #Render -//
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            ILocalizedPage page = Http.Page as ILocalizedPage;
            if (page != null)
            {
                try
                {
                    String text = page.CurrentResourceManager.GetString(Key);
                    if (!String.IsNullOrEmpty(Parameter1) && !String.IsNullOrEmpty(Parameter2) && !String.IsNullOrEmpty(Parameter3))
                    {
                        text = String.Format(text, Parameter1, Parameter2, Parameter3);
                    }
                    if (!String.IsNullOrEmpty(Parameter1) && !String.IsNullOrEmpty(Parameter2))
                    {
                        text = String.Format(text, Parameter1, Parameter2);
                    }
                    else if (!String.IsNullOrEmpty(Parameter1))
                    {
                        text = String.Format(text, Parameter1);
                    }
                    writer.Write(text);
                }
                catch
                {
                    //+ blank
                }
            }
        }
    }
}