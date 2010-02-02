#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
using System.Text;
using System.Web;
//+
namespace Nalarium.Web
{
    public abstract class HttpHandler : System.Web.IHttpHandler
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

        //- #Context -//
        protected HttpContext Context { get; set; }

        //- #Request -//
        protected HttpRequest Request { get; set; }

        //- #Response -//
        protected HttpResponse Response { get; set; }

        //- #Server -//
        protected HttpServerUtility Server { get; set; }

        //- #ContentType -//
        protected String ContentType
        {
            get
            {
                return Response.ContentType;
            }
            set
            {
                Response.ContentType = value;
            }
        }

        //- @IsReusable -//
        public virtual Boolean IsReusable
        {
            get { return false; }
        }

        //- $ProcessRequest -//
        void System.Web.IHttpHandler.ProcessRequest(System.Web.HttpContext context)
        {
            Context = context;
            Request = context.Request;
            Response = context.Response;
            Server = context.Server;
            //+
            Process();
            //+
            if (Output.Length > 0)
            {
                Response.Write(Output.ToString());
            }
        }

        //- @Process  -//
        public abstract void Process( );
    }
}