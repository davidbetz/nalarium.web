#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

//+
using System.Collections.Generic;
using Nalarium.Reflection;

namespace Nalarium.Web
{
    /// <summary>
    /// Used to handle specific HTTP verbs.
    /// </summary>
    public abstract class VerbHttpHandler : SessionHttpHandler
    {
        //- Process -//
        public override sealed void Process()
        {
            List<MethodAttributeInformation<RunForVerbsAttribute>> methodAttributeInformationArray = AttributeReader.FindMethodsWithAttribute<RunForVerbsAttribute>(this);
            if (methodAttributeInformationArray == null)
            {
                return;
            }
            foreach (var mai in methodAttributeInformationArray)
            {
                HttpVerbs httpVerbs = mai.Attribute.HttpVerbs;
                if ((Http.Method == HttpVerbs.Get && (httpVerbs & HttpVerbs.Get) == HttpVerbs.Get) ||
                    (Http.Method == HttpVerbs.Post && (httpVerbs & HttpVerbs.Post) == HttpVerbs.Post) ||
                    (Http.Method == HttpVerbs.Post && (httpVerbs & HttpVerbs.Head) == HttpVerbs.Head) ||
                    (Http.Method == HttpVerbs.Post && (httpVerbs & HttpVerbs.Delete) == HttpVerbs.Delete) ||
                    (Http.Method == HttpVerbs.Post && (httpVerbs & HttpVerbs.Put) == HttpVerbs.Put))
                {
                    mai.MethodInfo.Invoke(this, null);
                }
            }
            //+
            return;
        }
    }
}