#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
using System.Web.UI.WebControls;
//+
namespace Nalarium.Web.Controls
{
    [System.Web.UI.ParseChildren(true, "Content")]
    public class DisplacedPlaceHolder : System.Web.UI.WebControls.PlaceHolder
    {
        //- @Content -//
        public System.Web.UI.Control Content { get; set; }

        //- @TargetPlaceHolder -//
        public String TargetPlaceHolder { get; set; }

        //+
        //- #OnInit -//
        protected override void OnInit(EventArgs e)
        {
            PlaceHolder targetPlaceHolder = ControlFinder.FindControlRecursively(this.Page, TargetPlaceHolder) as PlaceHolder;
            if (targetPlaceHolder != null)
            {
                targetPlaceHolder.Controls.Add(Content);
            }
            Controls.Clear();
            //+
            base.OnInit(e);
        }
    }
}