#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
//+
namespace Nalarium.Web
{
    /// <summary>
    /// Represents a selector type.
    /// </summary>
    public enum SelectorType
    {
        UserAgent = 1,
        Referrer,
        IPAddress,
        //+
        CatchAll,
        Equals,
        Contains,
        EndsWith,
        StartsWith,
        WebDomainPathStartsWith,
        WebDomainPathEquals,
        PathStartsWith,
        PathContains,
        PathEquals,
    }
}