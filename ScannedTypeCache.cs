#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Collections.Generic;

namespace Nalarium.Web
{
    public static class ScannedTypeCache
    {
        internal static Map<String, List<Type>> TypeData = new Map<String, List<Type>>();

        //- @GetTypeData -//
        public static List<Type> GetTypeData(String key)
        {
            return TypeData[key];
        }

        //- @IsTypeListLoaded -//
        public static Boolean IsTypeListLoaded(String key)
        {
            return TypeData.ContainsKey(key);
        }

        //- @SetTypeData -//
        public static void SetTypeData(String key, List<Type> typeList)
        {
            TypeData.Add(key, typeList);
        }
    }
}