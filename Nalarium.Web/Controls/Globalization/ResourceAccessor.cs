﻿#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using Nalarium.Web.Properties;

namespace Nalarium.Web.Globalization
{
    public static class ResourceAccessor
    {
        //- @Ctor -//
        static ResourceAccessor()
        {
            Nalarium.Globalization.ResourceAccessor.RegisterResourceManager(AssemblyInfo.AssemblyName, new[]
                                                                                                       {
                                                                                                           "en"
                                                                                                       });
        }

        //+
        //- @GetString -//
        public static String GetString(String key)
        {
            return Nalarium.Globalization.ResourceAccessor.GetString(key, AssemblyInfo.AssemblyName, Resource.ResourceManager);
        }
    }
}