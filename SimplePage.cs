#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI;
using Nalarium.Web.Controls;

namespace Nalarium.Web
{
    /// <summary>
    /// Provides a simple non-webform web page.
    /// </summary>
    public class SimplePage : Page
    {
        //- @EnableState -//

        //+
        //- @Ctor -//
        public SimplePage()
        {
            EnableState = false;
        }

        public Boolean EnableState { get; set; }

        //- #Render -//
        /// <summary>
        /// Removes viewstate, event validation and the ASP.NET form element from the page
        /// </summary>
        /// <param name="originalWriter">The original writer.</param>
        protected override void Render(HtmlTextWriter originalWriter)
        {
            var stringWriter = new StringWriter(CultureInfo.CurrentCulture);
            var htmlTextWriter = new HtmlTextWriter(stringWriter);
            //+
            base.Render(htmlTextWriter);
            htmlTextWriter.Close();
            //+
            String data = stringWriter.GetStringBuilder().ToString();
            String pattern = @"<div>([\r\n\s]*)<input type=""hidden"" name=""__VIEWSTATE"" id=""__VIEWSTATE"" value=""(?<viewstate>[+/=a-z0-9]+)"" />([\r\n\s]*)</div>";
            data = Regex.Replace(data, pattern, String.Empty, RegexOptions.IgnoreCase);
            pattern = @"<div>([\r\n\s]*)<input type=""hidden"" name=""__EVENTVALIDATION"" id=""__EVENTVALIDATION"" value=""(?<eventvalidation>[+/=a-z0-9]+)"" />([\r\n\s]*)</div>";
            data = Regex.Replace(data, pattern, String.Empty, RegexOptions.IgnoreCase);
            pattern = @"<form name=""ctl([\d]+)"" method=""post"" action="""" id=""ctl([\d]+)"">([\r\n\s]*)";
            data = Regex.Replace(data, pattern, String.Empty, RegexOptions.IgnoreCase);
            if (!EnableState)
            {
                pattern = @"<form name=""ctl([\d]+)"" method=""post"">([\r\n\s]*)";
                data = Regex.Replace(data, pattern, String.Empty, RegexOptions.IgnoreCase);
            }
            pattern = @"([\r\n\s]*)</form>";
            String replacement = String.Empty;
            if (EnableState)
            {
                replacement = new StateArea().GetRenderData() + @"
</form>";
            }
            data = Regex.Replace(data, pattern, replacement, RegexOptions.IgnoreCase);
            //+
            originalWriter.Write(data);
        }
    }
}