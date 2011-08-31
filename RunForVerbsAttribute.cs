#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;

namespace Nalarium.Web
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RunForVerbsAttribute : Attribute
    {
        //- @HttpVerbs -//

        //+
        //- @Ctor -//
        public RunForVerbsAttribute(HttpVerbs httpVerbs)
        {
            HttpVerbs = httpVerbs;
        }

        public HttpVerbs HttpVerbs { get; set; }
    }
}