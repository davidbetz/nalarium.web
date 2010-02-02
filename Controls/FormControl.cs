#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web.Controls
{
    /// <summary>
    /// Represents the base of a control that uses a Nalarium form.
    /// </summary>
    public abstract class FormControl : System.Web.UI.Control
    {
        private Visibility _visibility = Visibility.Visible;

        //+
        //- @Visibility -//
        /// <summary>
        /// Represents the visibility of a control.
        /// </summary>
        public Visibility Visibility
        {
            get
            {
                return _visibility;
            }
            set
            {
                _visibility = value;
            }
        }

        //- @UniqueIDContainer -//
        public String UniqueIDContainer
        {
            get
            {
                String uniqueID = UniqueID;
                String[] uniqueIDPartArray = uniqueID.Split('$');
                if (uniqueIDPartArray.Length > 1)
                {
                    String[] newUniqueIDPartArray = new String[uniqueIDPartArray.Length - 1];
                    for (int i = 0; i < uniqueIDPartArray.Length - 1; i++)
                    {
                        newUniqueIDPartArray[i] = uniqueIDPartArray[i];
                    }
                    //+
                    return String.Join("$", newUniqueIDPartArray);
                }
                //+
                return String.Empty;
            }
        }

        //- #Form -//
        protected Form Form
        {
            get
            {
                return ControlFinder.FindControlThroughAncestorsByType<Form>(this);
            }
        }

        //- #ClientHiddenAttribute -//
        protected String ClientHiddenAttribute
        {
            get
            {
                if (Visibility == Visibility.ClientHidden)
                {
                    return "style=\"display:none;\"";
                }
                //+
                return String.Empty;
            }
        }
    }
}