#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Configuration;
using System.Diagnostics;
using Nalarium.Configuration.AppConfig;

namespace Nalarium.Web.Configuration.TypeCache._Shortcut
{
    [DebuggerDisplay("{Name}, {BaseType}")]
    public class ShortcutElement : CommentableElement
    {
        //- @Name -//
        [ConfigurationProperty("name", IsRequired = true)]
        public String Name
        {
            get
            {
                return (String)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

        //- @BaseType -//
        [ConfigurationProperty("baseType", IsRequired = true)]
        public String BaseType
        {
            get
            {
                return (String)this["baseType"];
            }
            set
            {
                this["baseType"] = value;
            }
        }
    }
}