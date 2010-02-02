#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web
{
    /// <summary>
    /// Provides a simple non-webform web page.
    /// </summary>
    public class SimplePage : System.Web.UI.Page
    {
        //- @EnableState -//
        public Boolean EnableState { get; set; }

        //+
        //- @Ctor -//
        public SimplePage()
        {
            EnableState = false;
        }

        //- #Render -//
        /// <summary>
        /// Removes viewstate, event validation and the ASP.NET form element from the page
        /// </summary>
        /// <param name="originalWriter">The original writer.</param>
        protected override void Render(System.Web.UI.HtmlTextWriter originalWriter)
        {
            System.IO.StringWriter stringWriter = new System.IO.StringWriter(System.Globalization.CultureInfo.CurrentCulture);
            System.Web.UI.HtmlTextWriter htmlTextWriter = new System.Web.UI.HtmlTextWriter(stringWriter);
            //+
            base.Render(htmlTextWriter);
            htmlTextWriter.Close();
            //+
            String data = stringWriter.GetStringBuilder().ToString();
            String pattern = @"<div>([\r\n\s]*)<input type=""hidden"" name=""__VIEWSTATE"" id=""__VIEWSTATE"" value=""(?<viewstate>[+/=a-z0-9]+)"" />([\r\n\s]*)</div>";
            data = System.Text.RegularExpressions.Regex.Replace(data, pattern, String.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            pattern = @"<div>([\r\n\s]*)<input type=""hidden"" name=""__EVENTVALIDATION"" id=""__EVENTVALIDATION"" value=""(?<eventvalidation>[+/=a-z0-9]+)"" />([\r\n\s]*)</div>";
            data = System.Text.RegularExpressions.Regex.Replace(data, pattern, String.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            pattern = @"<form name=""ctl([\d]+)"" method=""post"" action="""" id=""ctl([\d]+)"">([\r\n\s]*)";
            data = System.Text.RegularExpressions.Regex.Replace(data, pattern, String.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            if (!EnableState)
            {
                pattern = @"<form name=""ctl([\d]+)"" method=""post"">([\r\n\s]*)";
                data = System.Text.RegularExpressions.Regex.Replace(data, pattern, String.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            }
            pattern = @"([\r\n\s]*)</form>";
            String replacement = String.Empty;
            if (EnableState)
            {
                replacement = new Nalarium.Web.Controls.StateArea().GetRenderData() + @"
</form>";
            }
            data = System.Text.RegularExpressions.Regex.Replace(data, pattern, replacement, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            //+
            originalWriter.Write(data);
        }
    }
}