using System;
using System.Web.Script.Serialization;
//+
namespace Nalarium.Web.Serialization
{
    public class DynamicJavaScriptDataSerializer : DataSerializer
    {
        //- @Serialize -//
        public override String Serialize(Object data, Type type)
        {
            return new JavaScriptSerializer().Serialize(data);
        }
    }
}