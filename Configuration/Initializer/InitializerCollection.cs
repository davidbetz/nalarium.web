#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Configuration;
using Nalarium.Configuration.AppConfig;

namespace Nalarium.Web.Configuration.Initializer
{
    public class InitializerCollection : CommentableCollection<InitializerElement>
    {
        //- #GetElementKey -//
        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((InitializerElement)element).InitializerType;
        }
    }
}