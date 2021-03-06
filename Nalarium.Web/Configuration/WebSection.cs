﻿#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System.Configuration;
using Nalarium.Web.Configuration.Initializer;
using Nalarium.Web.Configuration.Profiling;
using Nalarium.Web.Configuration.TypeCache;
using ConfigurationSection = Nalarium.Configuration.AppConfig.ConfigurationSection;

namespace Nalarium.Web.Configuration
{
    /// <summary>
    /// Provides access to the configuration section.
    /// </summary>
    public class WebSection : ConfigurationSection
    {
        //- @ApplicationProcessors -//
        [ConfigurationProperty("applicationInitializers")]
        [ConfigurationCollection(typeof(InitializerElement), AddItemName = "add")]
        public InitializerCollection ApplicationInitializers
        {
            get
            {
                return (InitializerCollection)this["applicationInitializers"];
            }
        }

        //- @Profiling -//
        [ConfigurationProperty("profiling")]
        public ProfilingElement Profiling
        {
            get
            {
                return (ProfilingElement)this["profiling"];
            }
        }

        //- @TypeCache -//
        [ConfigurationProperty("typeCache")]
        public TypeCacheElement TypeCache
        {
            get
            {
                return (TypeCacheElement)this["typeCache"];
            }
        }

        //+
        //- @GetConfigSection -//
        /// <summary>
        /// Gets the config section.
        /// </summary>
        /// <returns>Configuration section</returns>
        public static WebSection GetConfigSection()
        {
            return GetConfigSection<WebSection>("nalarium/web");
        }
    }
}