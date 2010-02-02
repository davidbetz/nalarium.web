#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RunForVerbsAttribute : System.Attribute
    {
        //- @HttpVerbs -//
        public HttpVerbs HttpVerbs { get; set; }

        //+
        //- @Ctor -//
        public RunForVerbsAttribute(HttpVerbs httpVerbs)
        {
            HttpVerbs = httpVerbs;
        }
    }
}