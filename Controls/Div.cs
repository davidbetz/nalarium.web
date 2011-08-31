#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;

namespace Nalarium.Web.Controls
{
    /// <summary>
    /// Represents an HTML div element
    /// </summary>
    public class Div : Container
    {
        //- @ClassName -//
        public Div()
        {
            ContainerType = ContainerType.Div;
            QuickAttributeName1 = "class";
            QuickAttributeName2 = "id";
        }

        public String ClassName
        {
            get
            {
                return QuickAttributeValue1;
            }
            set
            {
                QuickAttributeValue1 = value;
            }
        }

        //- @ID -//
        public override String ID
        {
            get
            {
                return QuickAttributeValue2;
            }
            set
            {
                QuickAttributeValue2 = value;
            }
        }

        //+
        //- @Ctor -//
    }
}