#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web.Controls
{
    /// <summary>
    /// Represents a hidden field for Nalarium
    /// </summary>
    public class HiddenField : FormControl
    {
        //- @Value -//
        public String Value { get; set; }

        //+
        //- #OnInit -//
        protected override void OnInit(EventArgs e)
        {
            if (Http.Method != HttpVerbs.Get)
            {
                Value = StateTracker.GetOriginalValue(ID);
            }
            //+
            base.OnInit(e);
        }

        //- #OnPreRender -//
        protected override void OnPreRender(EventArgs e)
        {
            if (Visibility == Visibility.ClientHidden)
            {
                throw new InvalidOperationException(String.Format(Resource.Control_ClientHiddenNotCompatible, "Nalarium.Web.Controls.HiddenField"));
            }
            if (Visibility != Visibility.ServerHidden)
            {
                System.Web.UI.WebControls.Literal literal = new System.Web.UI.WebControls.Literal
                {
                    Text = String.Format("<input name=\"{0}\" id=\"{1}\" type=\"hidden\" value=\"{2}\" />", UniqueID, ClientID, Value)
                };
                Controls.Add(literal);
            }
            //+ state
            if (!Form.SurpressState && Http.Method == HttpVerbs.Get)
            {
                StateTracker.Set(StateEntryType.ControlId, ID, UniqueID);
            }
            //+
            base.OnPreRender(e);
        }
    }
}