#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
using System.Resources;
//+
namespace Nalarium.Web.Controls
{
    public interface ILocalizedPage
    {
        //- AssemblyName -//
        /// <summary>
        /// Represents the name of the assembly from which to pull a resource manager.
        /// </summary>
        String AssemblyName { get; }

        //- BuiltInCultureArray -//
        /// <summary>
        /// Represents an array of cultures built into the assembly specifies in AssemblyName.
        /// </summary>
        String[] BuiltInCultureArray { get; }

        //- DefaultResourceManager -//
        /// <summary>
        /// Represents the resource manager to use if no others are found.
        /// </summary>
        ResourceManager DefaultResourceManager { get; }

        //- CurrentResourceManager -//
        /// <summary>
        /// Represents the currently active resource manager.
        /// </summary>
        ResourceManager CurrentResourceManager { get; }
    }
}