#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web.Controls
{
    /// <summary>
    /// Represents a label for Nalarium
    /// </summary>
    public class Label : FormControl
    {
        //- @Text -//
        public String Text { get; set; }

        //- @AssociatedControl -//
        public FormControl AssociatedControl { get; set; }

        //+
        //- #Render -//
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            if (AssociatedControl != null)
            {
                writer.Write(String.Format("<label for=\"{0}\">{1}</label>", AssociatedControl.ClientID, Text));
            }
            else
            {
                writer.Write(String.Format("<span>{0}</span>", Text));
            }
            base.Render(writer);
        }
    }
}