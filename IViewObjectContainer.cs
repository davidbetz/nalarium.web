#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
using System.Text.RegularExpressions;
//+
namespace Nalarium.Web
{
    public interface IViewObjectContainer
    {
        Map<String, Object> ViewObjectMap { get; set; }
    }
}