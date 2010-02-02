#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web.Controls
{
    /// <summary>
    /// Represents a control container
    /// </summary>
    public class Container : System.Web.UI.WebControls.PlaceHolder
    {
        private ContainerType _containerType = ContainerType.None;

        //+
        //- @ContainerType -//
        public ContainerType ContainerType
        {
            get
            {
                return _containerType;
            }
            set
            {
                _containerType = value;
            }
        }

        //- @TagName -//
        public String TagName
        {
            get
            {
                switch (_containerType)
                {
                    case ContainerType.Div:
                        return "div";
                    case ContainerType.Span:
                        return "span";
                    case ContainerType.None:
                    default:
                        return String.Empty;
                }
            }
        }

        //- @DefaultContent -//
        public String DefaultContent { get; set; }

        //- @QuickAttributeName1 -//
        public String QuickAttributeName1 { get; set; }

        //- @QuickAttributeValue1 -//
        public String QuickAttributeValue1 { get; set; }

        //- @QuickAttributeName2 -//
        public String QuickAttributeName2 { get; set; }

        //- @QuickAttributeValue2 -//
        public String QuickAttributeValue2 { get; set; }

        //+
        //- #Render -//
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            if (!String.IsNullOrEmpty(TagName))
            {
                builder.Append("<" + TagName);
                if (!String.IsNullOrEmpty(QuickAttributeName1) && !String.IsNullOrEmpty(QuickAttributeValue1))
                {
                    builder.Append(" " + QuickAttributeName1 + "=\"" + QuickAttributeValue1 + "\"");
                }
                if (!String.IsNullOrEmpty(QuickAttributeName2) && !String.IsNullOrEmpty(QuickAttributeValue2))
                {
                    builder.Append(" " + QuickAttributeName2 + "=\"" + QuickAttributeValue2 + "\"");
                }
                builder.Append(">");
                writer.Write(builder.ToString());
            }
            if (Controls.Count > 0)
            {
                base.Render(writer);
            }
            else
            {
                writer.Write(DefaultContent);
            }
            if (!String.IsNullOrEmpty(TagName))
            {
                writer.Write("</" + TagName + ">");
            }
        }
    }
}