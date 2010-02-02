#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web.Controls
{
    /// <summary>
    /// Represents a check box for Nalarium
    /// </summary>
    public class CheckBox : FormControl
    {
        //- @Label -//
        public String Label { get; set; }

        //- @Checked -//
        public Boolean Checked { get; set; }

        //- @Value -//
        public String Value { get; set; }

        //+
        //- #OnInit -//
        protected override void OnInit(EventArgs e)
        {
            if (Http.Method != HttpVerbs.Get)
            {
                Checked = !String.IsNullOrEmpty(StateTracker.GetOriginalValue(ID));
            }
            //+
            base.OnInit(e);
        }

        //- #OnPreRender -//
        protected override void OnPreRender(EventArgs e)
        {
            if (Visibility != Visibility.ServerHidden)
            {
                Container container = new Container();
                Controls.Add(container);
                String clientHiddenAttribute = String.Empty;
                if (!String.IsNullOrEmpty(Label))
                {
                    Label label = new Label
                    {
                        AssociatedControl = this,
                        Text = Label
                    };
                    container.Controls.Add(label);
                }
                else
                {
                    clientHiddenAttribute = ClientHiddenAttribute;
                }
                container.Controls.Add(new System.Web.UI.WebControls.Literal
                {
                    Text = String.Format("<input name=\"{0}\" id=\"{1}\" type=\"checkbox\"{2} value=\"{3}\" {4} />", UniqueID, ClientID, Checked ? " checked=\"checked\"" : String.Empty, Value, clientHiddenAttribute)
                });
                if (Visibility == Visibility.ClientHidden && !String.IsNullOrEmpty(Label))
                {
                    container.ContainerType = ContainerType.Div;
                    container.QuickAttributeName1 = "style";
                    container.QuickAttributeValue1 = "display:none";
                }
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