﻿#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

//+
//+
using System.Web.UI;

namespace Nalarium.Web
{
    public interface IHasPage
    {
        Page Page { get; set; }
    }
}