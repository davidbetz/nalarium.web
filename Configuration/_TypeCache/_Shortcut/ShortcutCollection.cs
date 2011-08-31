#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Configuration;
using Nalarium.Configuration;

namespace Nalarium.Web.Configuration
{
    public class ShortcutCollection : CommentableCollection<ShortcutElement>
    {
        //- #GetElementKey -//
        protected override Object GetElementKey(ConfigurationElement element)
        {
            return (element as ShortcutElement).Name;
        }
    }
}