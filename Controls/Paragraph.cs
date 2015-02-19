#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Text;
using System.Web.UI;

namespace Nalarium.Web.Controls
{
    public class Paragraph : Control
    {
        //- @Text -//
        public String Text { get; set; }

        //- @ClassName -//
        public String ClassName { get; set; }

        //+
        //- @Ctor -//

        //- #Render -//
        protected override void Render(HtmlTextWriter writer)
        {
            var builder = new StringBuilder("<p");
            if (!String.IsNullOrEmpty(ClassName))
            {
                builder.Append(" class=\"" + ClassName + "\"");
            }
            builder.Append(">" + Text + "</p>");
            writer.Write(builder.ToString());
            //+
            base.Render(writer);
        }
    }
}