#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
//+
namespace Nalarium.Web.Controls
{
    public class Break : System.Web.UI.Control
    {
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            writer.Write("<br/>");
            //+
            base.Render(writer);
        }
    }
}