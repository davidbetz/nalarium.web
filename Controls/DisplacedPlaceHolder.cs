#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nalarium.Web.Controls
{
    [ParseChildren(true, "Content")]
    public class DisplacedPlaceHolder : PlaceHolder
    {
        //- @Content -//
        public Control Content { get; set; }

        //- @TargetPlaceHolder -//
        public String TargetPlaceHolder { get; set; }

        //+
        //- #OnInit -//
        protected override void OnInit(EventArgs e)
        {
            var targetPlaceHolder = ControlFinder.FindControlRecursively(Page, TargetPlaceHolder) as PlaceHolder;
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