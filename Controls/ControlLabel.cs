#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Text;
using System.Web.UI;

namespace Nalarium.Web.Controls
{
    public class ControlLabel : Control
    {
        //- @ForId -//
        public String ForId { get; set; }

        //- @AssociatedControl -//
        public Control AssociatedControl { get; set; }

        //- @Suffix -//
        public String Suffix { get; set; }

        //- @Text -//
        public String Text { get; set; }

        //+
        //- @Ctor -//

        //- #Render -//
        protected override void Render(HtmlTextWriter writer)
        {
            String forId = ForId;
            if (AssociatedControl != null)
            {
                forId = AssociatedControl.UniqueID;
            }
            var builder = new StringBuilder("<label for=\"" + forId + "\">");
            builder.Append(Text + Suffix);
            builder.Append("</label>");
            writer.Write(builder.ToString());
            //+
            base.Render(writer);
        }
    }
}