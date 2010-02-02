#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System.Configuration;
//+
namespace Nalarium.Web.Configuration
{
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class TypeCacheElement : Nalarium.Configuration.CommentableElement
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