#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web.Controls
{
    public class Paragraph : System.Web.UI.Control
    {
        //- @Text -//
        public String Text { get; set; }

        //- @ClassName -//
        public String ClassName { get; set; }

        //+
        //- @Ctor -//
        public Paragraph()
        {
        }

        //- #Render -//
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder("<p");
            if (!String.IsNullOrEmpty(ClassName))
            {
                builder.Append(" class=\"" + ClassName + "\"");
            }
            builder.Append(">" + this.Text + "</p>");
            writer.Write(builder.ToString());
            //+
            base.Render(writer);
        }
    }
}