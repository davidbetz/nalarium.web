#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web.Controls
{
    /// <summary>
    /// Represents a form for Nalarium
    /// </summary>
    public class Form : System.Web.UI.WebControls.PlaceHolder
    {
        //- @SurpressState -//
        public Boolean SurpressState { get; set; }

        //- #Render -//
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            writer.Write("<form method=\"post\" action=\"" + Nalarium.Web.Http.AbsolutePath + "\">");
            if (!SurpressState)
            {
                if (ControlFinder.FindControlRecursivelyByType<StateArea>(this) == null)
                {
                    writer.Write(new StateArea().GetRenderData());
                }
            }
            base.Render(writer);
            writer.Write("</form>");
        }
    }
}