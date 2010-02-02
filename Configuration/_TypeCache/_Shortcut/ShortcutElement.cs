#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
using System.Configuration;
//+
namespace Nalarium.Web.Configuration
{
    [System.Diagnostics.DebuggerDisplay("{Name}, {BaseType}")]
    public class ShortcutElement : Nalarium.Configuration.CommentableElement
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