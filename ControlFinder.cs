#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
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
        public static System.Web.UI.Control FindControlThroughAncestors(System.Web.UI.Control descendant, String parentId)
        {
            if (descendant == null)
            {
                return null;
            }
            System.Web.UI.Control foundControl = descendant.Parent;
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
        public static T FindControlThroughAncestors<T>(System.Web.UI.Control descendant, String parentId) where T : System.Web.UI.Control
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
        public static T FindControlThroughAncestorsByType<T>(System.Web.UI.Control descendant) where T : System.Web.UI.Control
        {
            if (descendant == null)
            {
                return null;
            }
            T castControl = descendant.Parent as T;
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
        public static System.Web.UI.Control FindControlRecursively(System.Web.UI.Control ancestor, String controlId)
        {
            if (ancestor != null)
            {
                System.Web.UI.Control foundControl = ancestor.FindControl(controlId);
                if (foundControl != null)
                {
                    return foundControl;
                }
                foreach (System.Web.UI.Control c in ancestor.Controls)
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
        public static T FindControlRecursively<T>(System.Web.UI.Control ancestor, String controlId) where T : System.Web.UI.Control
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
        public static T FindControlRecursivelyByType<T>(System.Web.UI.Control ancestor) where T : System.Web.UI.Control
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
        public static T FindControlRecursivelyByType<T>(System.Web.UI.Control ancestor, Boolean allowSubType) where T : System.Web.UI.Control
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
        public static System.Collections.Generic.List<T> FindAllControlsRecursivelyByType<T>(System.Web.UI.Control ancestor) where T : System.Web.UI.Control
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
        public static System.Collections.Generic.List<T> FindAllControlsRecursivelyByType<T>(System.Web.UI.Control ancestor, Boolean allowSubType) where T : System.Web.UI.Control
        {
            System.Collections.Generic.List<T> list = new System.Collections.Generic.List<T>();
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
                        System.Collections.Generic.List<T> returnList = FindAllControlsRecursivelyByType<T>(ancestor.Controls[i], allowSubType);
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