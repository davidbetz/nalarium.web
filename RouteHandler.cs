//#region Copyright
////+ Nalarium Pro 3.0 - Web Module
////+ Copyright © Jampad Technology, Inc. 2008-2010
//#endregion
//using System;
//using System.Collections.Generic;
////+
//using Nalarium.Activation;
//using Nalarium.Web.Configuration;
//using System.Web;
////+
//namespace Nalarium.Web.Processing
//{
//    public class RoutingIntegrationHttpHandler : HttpHandler
//    {
//        System.Web.Routing.RequestContext _requestContext;

//        public RoutingIntegrationHttpHandler(System.Web.Routing.RequestContext requestContext)
//        {
//            _requestContext = requestContext;
//        }

//        public override void Process()
//        {
//            //+ blank
//        }
//    }

//    public class RouteHandler : System.Web.Routing.IRouteHandler
//    {
//        public System.Web.IHttpHandler GetHttpHandler(System.Web.Routing.RequestContext requestContext)
//        {
//            System.Web.IHttpHandler hh = null;
//            if (CoreModule.IsExclusion)
//            {
//                hh = null;
//            }
//            //+
//            if (HttpData.GetScopedItem<Boolean>(CoreModule.Info.Scope, CoreModule.Info.DisableProcessing) == false)
//            {
//                HttpApplication ha = requestContext.HttpContext.ApplicationInstance;
//                HttpContext context = ha.Context;
//                //+
//                FlowControl.ActiveHandler = RouteActivator.Create(context);
//                if (FlowControl.ActiveHandler != null
//                    && !(FlowControl.ActiveHandler is PassThroughHttpHandler)
//                    && !(FlowControl.ActiveHandler is DummyHttpHandler))
//                {
//                    hh = FlowControl.ActiveHandler;
//                    //if (HttpRuntime.UsingIntegratedPipeline)
//                    //{
//                    //    ha.Context.RemapHandler(FlowControl.ActiveHandler);
//                    //}
//                    //else
//                    //{
//                    //    ha.Context.Handler = FlowControl.ActiveHandler;
//                    //}
//                }
//            }
//            //+ first send
//            if (WebProcessingReportController.Reporter.Initialized)
//            {
//                Boolean hasDataToSend = WebProcessingReportController.Reporter.HasDataToSend;
//                if (hasDataToSend)
//                {
//                    String name = Nalarium.Configuration.SystemSection.GetConfigSection().AppInfo.Name;
//                    if (!String.IsNullOrEmpty(name))
//                    {
//                        Map map = new Map();
//                        map.Add("App Name", name);
//                        WebProcessingReportController.Reporter.InsertMap(map, 0);
//                    }
//                    WebProcessingReportController.Reporter.Send(true);
//                    WebProcessingReportController.Reporter.ReportCreator.Clear();
//                }
//            }
//            //+
//            return hh;
//        }
//    }
//}