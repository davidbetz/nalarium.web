#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Text;
using System.Web;

namespace Nalarium.Web
{
    public abstract class HttpModule : IHttpModule
    {
        private StringBuilder _output = new StringBuilder();

        //+
        //- #OutputBuilder -//
        protected StringBuilder Output
        {
            get
            {
                return _output;
            }
            set
            {
                _output = new StringBuilder();
            }
        }

        //- #Application -//
        protected HttpApplication Application { get; set; }

        //- @EnableBeginRequest -//
        public Boolean EnableBeginRequest { get; set; }

        //- @Dispose -//

        #region IHttpModule Members

        public virtual void Dispose()
        {
        }

        //- $ProcessRequest -//
        void IHttpModule.Init(HttpApplication application)
        {
            Application = application;
            //+
            StartUp();
            //+
            if (EnableBeginRequest)
            {
                Application.BeginRequest += delegate
                                            {
                                                BeginRequest();
                                                //+
                                                if (Output.Length > 0)
                                                {
                                                    Http.Response.Write(Output.ToString());
                                                }
                                            };
            }
        }

        #endregion

        //- #StartUp  -//
        protected virtual void StartUp()
        {
            //+ blank
        }

        //- #BeginRequest -//
        protected virtual void BeginRequest()
        {
        }
    }
}