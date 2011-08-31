#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

//+
using System.Web.UI;

namespace Nalarium.Web.Controls
{
    public class Break : Control
    {
        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<br/>");
            //+
            base.Render(writer);
        }
    }
}