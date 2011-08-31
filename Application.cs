#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using Nalarium.Activation;
using Nalarium.Web.Configuration;
//+

//using Nalarium.Web.Configuration;
//+

namespace Nalarium.Web
{
    /// <summary>
    /// Represents a Nalarium Pro web-based application.
    /// </summary>
    public class Application : HttpApplication
    {
        private static readonly Object _lock = new Object();
        private static Int32 _totalUserCount;
        private static DateTime _appStartDateTime;
        private static List<GlobalApplicationInitializer> _appLifeCycleInitializerList;
        private static List<SessionApplicationInitializer> _sessionLifeCycleInitializerList;

        //+
        //- @AppStartDateTime -//
        /// <summary>
        /// Represents the start date/time of the application.
        /// </summary>
        public static DateTime AppStartDateTime
        {
            get
            {
                return _appStartDateTime;
            }
        }

        //- @UserCount -//
        /// <summary>
        /// Represents the number of users currently on the system.
        /// </summary>
        public static Int32 TotalUserCount
        {
            get
            {
                return _totalUserCount;
            }
        }

        //- @TimeRunning -//
        /// <summary>
        /// Represents the number of seconds the application has been running.
        /// </summary>
        public static Double TimeRunning
        {
            get
            {
                return (DateTime.Now - _appStartDateTime).TotalSeconds;
            }
        }

        //+
        //- #Application_Start -//
        protected void Application_Start(Object sender, EventArgs e)
        {
            _appStartDateTime = DateTime.Now;
            //+ cache
            _appLifeCycleInitializerList = new List<GlobalApplicationInitializer>();
            _sessionLifeCycleInitializerList = new List<SessionApplicationInitializer>();
            foreach (InitializerElement element in WebSection.GetConfigSection().ApplicationInitializers)
            {
                CacheProcessor(element);
            }
            //+
            _appLifeCycleInitializerList.ForEach(p => p.OnStartup());
        }

        //- #Application_End -//
        protected void Application_End(Object sender, EventArgs e)
        {
            _appLifeCycleInitializerList.ForEach(p => p.OnShutdown());
        }

        //- #Session_Start -//
        protected void Session_Start(Object sender, EventArgs e)
        {
            lock (_lock)
            {
                _totalUserCount++;
                _sessionLifeCycleInitializerList.ForEach(p => p.OnStartup());
            }
        }

        //- #Session_End -//
        protected void Session_End(Object sender, EventArgs e)
        {
            lock (_lock)
            {
                _totalUserCount--;
                _sessionLifeCycleInitializerList.ForEach(p => p.OnShutdown());
            }
        }

        //- $CacheProcessor -//
        private void CacheProcessor(InitializerElement processorElement)
        {
            lock (_lock)
            {
                try
                {
                    ApplicationInitializer processor;
                    if (!processorElement.InitializerType.Contains(","))
                    {
                        throw new ConfigurationErrorsException(Resource.Processor_LifeCycleTypeAndAssemblyRequired);
                    }
                    processor = ObjectCreator.CreateAs<ApplicationInitializer>(processorElement.InitializerType);
                    //+
                    if (processor != null)
                    {
                        var appLifeCycleProcessor = processor as GlobalApplicationInitializer;
                        if (appLifeCycleProcessor != null)
                        {
                            _appLifeCycleInitializerList.Add(appLifeCycleProcessor);
                        }
                        else
                        {
                            var sessionApplicationProcessor = processor as SessionApplicationInitializer;
                            if (sessionApplicationProcessor != null)
                            {
                                _sessionLifeCycleInitializerList.Add(sessionApplicationProcessor);
                            }
                        }
                    }
                }
                catch (FileNotFoundException ex)
                {
                    throw new ConfigurationErrorsException(String.Format(Resource.Processor_LifeCycleAssemblyInvalid, ex.Message));
                }
            }
        }
    }
}