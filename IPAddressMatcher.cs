#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Text.RegularExpressions;

namespace Nalarium.Web
{
    /// <summary>
    /// Used to patch a pattern against the current user's IP address.
    /// </summary>
    public static class IPAddressMatcher
    {
        //- ~Match -//
        public static Boolean Match(String pattern)
        {
            if (String.IsNullOrEmpty(pattern))
            {
                return false;
            }
            pattern = pattern.Replace(".", "\\.").Replace("*", "[0-9]+");
            //+
            return new Regex(pattern, RegexOptions.IgnoreCase).IsMatch(Http.IPAddress);
        }
    }
}