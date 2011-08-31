#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Nalarium.Web.Controls
{
    public class ControlLifeCycleTracker : Control
    {
        //+ field
        public static List<LifeCycleCompletedPosition> LifeCycleCompletedPositionList
        {
            get
            {
                return HttpData.GetScopedItem<List<LifeCycleCompletedPosition>>(Info.Scope, Info.LifeCycleCompletedPosition);
            }
            private set
            {
                HttpData.SetScopedItem(Info.Scope, Info.LifeCycleCompletedPosition, value);
            }
        }

        //+
        //- @AddToPage -//
        public static void AddToPage()
        {
            Page page = Http.Page;
            if (page == null)
            {
                return;
            }
            if (ControlFinder.FindControlRecursivelyByType<ControlLifeCycleTracker>(page) == null)
            {
                page.Controls.Add(new ControlLifeCycleTracker());
            }
        }

        //- #OnInit -//
        protected override void OnInit(EventArgs e)
        {
            LifeCycleCompletedPositionList = new List<LifeCycleCompletedPosition>();
            LifeCycleCompletedPositionList.Add(LifeCycleCompletedPosition.Init);
            Page.RegisterRequiresControlState(this);
        }

        //- #CreateControlCollection -//
        protected override ControlCollection CreateControlCollection()
        {
            LifeCycleCompletedPositionList.Add(LifeCycleCompletedPosition.CreateControlCollection);
            return base.CreateControlCollection();
        }

        //- #LoadControlState -//
        protected override void LoadControlState(Object savedState)
        {
            LifeCycleCompletedPositionList.Add(LifeCycleCompletedPosition.LoadControlState);
        }

        //- #LoadViewState -//
        protected override void LoadViewState(Object savedState)
        {
            LifeCycleCompletedPositionList.Add(LifeCycleCompletedPosition.LoadViewState);
        }

        //- #OnLoad -//
        protected override void OnLoad(EventArgs e)
        {
            LifeCycleCompletedPositionList.Add(LifeCycleCompletedPosition.Load);
        }

        //- #CreateChildControls -//
        protected override void CreateChildControls()
        {
            LifeCycleCompletedPositionList.Add(LifeCycleCompletedPosition.CreateChildControls);
        }

        //- #OnDataBinding -//
        protected override void OnDataBinding(EventArgs e)
        {
            LifeCycleCompletedPositionList.Add(LifeCycleCompletedPosition.DataBinding);
        }

        //- #OnPreRender -//
        protected override void OnPreRender(EventArgs e)
        {
            LifeCycleCompletedPositionList.Add(LifeCycleCompletedPosition.PreRender);
        }

        //- #SaveControlState -//
        protected override object SaveControlState()
        {
            LifeCycleCompletedPositionList.Add(LifeCycleCompletedPosition.SaveControlState);
            return base.SaveControlState();
        }

        //- #SaveViewState -//
        protected override object SaveViewState()
        {
            LifeCycleCompletedPositionList.Add(LifeCycleCompletedPosition.SaveViewState);
            return base.SaveControlState();
        }

        //- #Render -//
        protected override void Render(HtmlTextWriter writer)
        {
            LifeCycleCompletedPositionList.Add(LifeCycleCompletedPosition.Render);
        }

        //- #OnUnload -//
        protected override void OnUnload(EventArgs e)
        {
            LifeCycleCompletedPositionList.Add(LifeCycleCompletedPosition.Unload);
        }

        #region Nested type: Info

        public class Info
        {
            public const String Scope = "LifeCycleTracker";
            public const String LifeCycleCompletedPosition = "LifeCycleCompletedPosition";
        }

        #endregion
    }
}