#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;

namespace Nalarium.Web
{
    public abstract class GlobalApplicationInitializer : ApplicationInitializer
    {
        internal static Type _Type = typeof(GlobalApplicationInitializer);
    }
}