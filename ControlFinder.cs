#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Nalarium.Web
{
    /// <summary>
    /// Allows easy searching of ASP.NET controls by either name or type
    /// </summary>
    public static class ControlFinder
    {
        //- @FindControlThroughAncestors -//
        /// <summary>
        /// Looks for a control by going through ancestors.
        /// </summary>
        /// <param name="descendant">The ancestor element of the control.</param>
        /// <param name="controlName">Name of the control.</param>
        /// <returns>Found control or null if not found.</returns>
        public static Control FindControlThroughAncestors(Control descendant, String parentId)
        {
            if (descendant == null)
            {
                return null;
            }
            Control foundControl = descendant.Parent;
            if (foundControl.ID == parentId)
            {
                return foundControl;
            }
            //+
            return FindControlThroughAncestors(foundControl, parentId);
        }

        /// <summary>
        /// Looks for a control by going through ancestors.
        /// </summary>
        /// <typeparam name="T">Type of parent.</typeparam>
        /// <param name="descendant">The ancestor element of the control.</param>
        /// <param name="controlName">Name of the control.</param>
        /// <returns>Found control or null if not found.</returns>
        public static T FindControlThroughAncestors<T>(Control descendant, String parentId) where T : Control
        {
            return FindControlThroughAncestors(descendant, parentId) as T;
        }

        //- @FindControlThroughAncestorsByType -//
        /// <summary>
        /// Looks for a control by going through ancestors by type.
        /// </summary>
        /// <typeparam name="T">Type of parent.</typeparam>
        /// <param name="descendant">The ancestor element of the control.</param>
        /// <param name="controlName">Name of the control.</param>
        /// <returns>Found control or null if not found.</returns>
        public static T FindControlThroughAncestorsByType<T>(Control descendant) where T : Control
        {
            if (descendant == null)
            {
                return null;
            }
            var castControl = descendant.Parent as T;
            if (castControl != null)
            {
                return castControl;
            }
            //+
            return FindControlThroughAncestorsByType<T>(descendant.Parent);
        }

        //- @FindControlRecursively -//
        /// <summary>
        /// Recursively searched for an ASP.NET control by name
        /// </summary>
        /// <param name="ancestor">The ancestor element of the control.</param>
        /// <param name="controlName">Name of the control.</param>
        /// <returns>Found control or null if not found.</returns>
        public static Control FindControlRecursively(Control ancestor, String controlId)
        {
            if (ancestor != null)
            {
                Control foundControl = ancestor.FindControl(controlId);
                if (foundControl != null)
                {
                    return foundControl;
                }
                foreach (Control c in ancestor.Controls)
                {
                    foundControl = FindControlRecursively(c, controlId);
                    if (foundControl != null)
                    {
                        return foundControl;
                    }
                }
            }
            //+
            return null;
        }

        /// <summary>
        /// Recursively searched for an ASP.NET control by name.
        /// </summary>
        /// <typeparam name="T">Type of control</typeparam>
        /// <param name="ancestor">The ancestor element of the control.</param>
        /// <param name="controlName">Name of the control.</param>
        /// <returns>Found control or null if not found.</returns>
        public static T FindControlRecursively<T>(Control ancestor, String controlId) where T : Control
        {
            return FindControlRecursively(ancestor, controlId) as T;
        }

        //- @FindControlRecursivelyByType -//
        /// <summary>
        /// Recursively searched for an ASP.NET control by type.
        /// </summary>
        /// <typeparam name="T">The type of the control to find.</typeparam>
        /// <param name="ancestor">The ancestor element of the control.</param>
        /// <returns>Found control or null if not found.</returns>
        public static T FindControlRecursivelyByType<T>(Control ancestor) where T : Control
        {
            return FindControlRecursivelyByType<T>(ancestor, false);
        }

        //- @FindControlRecursivelyByType -//
        /// <summary>
        /// Recursively searched for an ASP.NET control by type.
        /// </summary>
        /// <typeparam name="T">The type of the control to find.</typeparam>
        /// <param name="ancestor">The ancestor element of the control.</param>
        /// <param name="allowSubType">True is the type can be a subtype of T.</param>
        /// <returns>Found control or null if not found.</returns>
        public static T FindControlRecursivelyByType<T>(Control ancestor, Boolean allowSubType) where T : Control
        {
            T control = null;
            if (ancestor.Controls != null && ancestor.Controls.Count > 0)
            {
                for (Int32 i = 0; i < ancestor.Controls.Count; i++)
                {
                    if ((allowSubType && ancestor.Controls[i] is T) || ancestor.Controls[i].GetType() == typeof(T))
                    {
                        control = ancestor.Controls[i] as T;
                    }
                    else
                    {
                        control = FindControlRecursivelyByType<T>(ancestor.Controls[i], allowSubType);
                    }
                    if (control != null)
                    {
                        return control;
                    }
                }
            }
            //+
            return control;
        }

        //- @FindAllControlsRecursivelyByType -//
        /// <summary>
        /// Recursively searched for an ASP.NET control by type.
        /// </summary>
        /// <typeparam name="T">The type of the contro lto find.</typeparam>
        /// <param name="ancestor">The ancestor element of the control.</param>
        /// <returns>Found control or null if not found.</returns>
        public static List<T> FindAllControlsRecursivelyByType<T>(Control ancestor) where T : Control
        {
            return FindAllControlsRecursivelyByType<T>(ancestor, false);
        }

        //- @FindControlRecursivelyByType -//
        /// <summary>
        /// Recursively searched for an ASP.NET control by type.
        /// </summary>
        /// <typeparam name="T">The type of the contro lto find.</typeparam>
        /// <param name="ancestor">The ancestor element of the control.</param>
        /// <param name="allowSubType">True is the type can be a subtype of T.</param>
        /// <returns>Found control or null if not found.</returns>
        public static List<T> FindAllControlsRecursivelyByType<T>(Control ancestor, Boolean allowSubType) where T : Control
        {
            var list = new List<T>();
            T control = null;
            if (ancestor.Controls != null && ancestor.Controls.Count > 0)
            {
                for (Int32 i = 0; i < ancestor.Controls.Count; i++)
                {
                    if ((allowSubType && ancestor.Controls[i] is T) || ancestor.Controls[i].GetType() == typeof(T))
                    {
                        control = ancestor.Controls[i] as T;
                        if (control != null)
                        {
                            list.Add(control);
                        }
                    }
                    else
                    {
                        List<T> returnList = FindAllControlsRecursivelyByType<T>(ancestor.Controls[i], allowSubType);
                        if (returnList.Count > 0)
                        {
                            list.AddRange(returnList);
                        }
                    }
                }
            }
            //+
            return list;
        }
    }
}