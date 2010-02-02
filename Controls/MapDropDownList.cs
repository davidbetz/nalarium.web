#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web.Controls
{
    /// <summary>
    /// Represents a drop down list where the data source will be a map data source.
    /// </summary>
    public class MapDropDownList : System.Web.UI.WebControls.DropDownList
    {
        //- @DataTextField -//
        public override String DataTextField
        {
            get
            {
                return "Value";
            }
            set
            {
            }
        }

        //- @DataValueField -//
        public override String DataValueField
        {
            get
            {
                return "Key";
            }
            set
            {
            }
        }
    }
}