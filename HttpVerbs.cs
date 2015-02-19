#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;

namespace Nalarium.Web
{
    /// <summary>
    /// Represents the HTTP verbs.
    /// </summary>
    [Flags]
    public enum HttpVerbs
    {
        Unknown = 0x00,
        Get = 0x01,
        Post = 0x02,
        Head = 0x04,
        Delete = 0x08,
        Put = 0x10
    }
}