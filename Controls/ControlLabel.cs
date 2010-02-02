#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web.Controls
{
    public class ControlLabel : System.Web.UI.Control
    {
        //- @ForId -//
        public String ForId { get; set; }

        //- @AssociatedControl -//
        public System.Web.UI.Control AssociatedControl { get; set; }

        //- @Suffix -//
        public String Suffix { get; set; }

        //- @Text -//
        public String Text { get; set; }

        //+
        //- @Ctor -//
        public ControlLabel()
        {
        }

        //- #Render -//
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            String forId = ForId;
            if (AssociatedControl != null)
            {
                forId = AssociatedControl.UniqueID;
            }
            System.Text.StringBuilder builder = new System.Text.StringBuilder("<label for=\"" + forId + "\">");
            builder.Append(Text + Suffix);
            builder.Append("</label>");
            writer.Write(builder.ToString());
            //+
            base.Render(writer);
        }
    }
}