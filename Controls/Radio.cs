#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web.Controls
{
    /// <summary>
    /// Represents a radio box for Nalarium
    /// </summary>
    public class Radio : FormControl
    {
        //- @GroupName -//
        public String GroupName { get; set; }

        //- @Label -//
        public String Label { get; set; }

        //- @Selected -//
        public Boolean Selected { get; set; }

        //- @Value -//
        public String Value { get; set; }

        //- @ValueEqualsLabel -//
        public Boolean ValueEqualsLabel { get; set; }

        //+
        //- #OnInit -//
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //+
            if (Http.Method != HttpVerbs.Get)
            {
                if (StateTracker.GetOriginalValue(GroupName) == Value)
                {
                    Selected = true;
                }
            }
        }

        //- #OnPreRender -//
        protected override void OnPreRender(EventArgs e)
        {
            String uniqueIdContainer = UniqueIDContainer;
            String id = String.Empty;
            if (String.IsNullOrEmpty(uniqueIdContainer))
            {
                id = GroupName;
            }
            else
            {
                id = uniqueIdContainer + "$" + GroupName;
            }
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
                if (ValueEqualsLabel)
                {
                    Value = Label;
                }
                container.Controls.Add(new System.Web.UI.WebControls.Literal
                {
                    Text = String.Format("<input name=\"{0}\" id=\"{1}\" type=\"radio\" value=\"{2}\" {3} {4} />", id, ClientID, Value, Selected ? " checked=\"checked\"" : String.Empty, clientHiddenAttribute)
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
                StateTracker.Set(StateEntryType.ControlId, GroupName, id);
            }
            //+
            base.OnPreRender(e);
        }
    }
}