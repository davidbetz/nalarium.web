#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System.Configuration;
using System.Diagnostics;
using Nalarium.Configuration.AppConfig;
using Nalarium.Web.Configuration.TypeCache._Shortcut;

namespace Nalarium.Web.Configuration.TypeCache
{
    [DebuggerDisplay("{Name}")]
    public class TypeCacheElement : CommentableElement
    {
        //- @Shortcuts -//
        [ConfigurationProperty("shortcuts")]
        [ConfigurationCollection(typeof(ShortcutElement), AddItemName = "add")]
        public ShortcutCollection Shortcuts
        {
            get
            {
                return (ShortcutCollection)this["shortcuts"];
            }
        }
    }
}