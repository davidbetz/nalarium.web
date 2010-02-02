using System;
using System.Runtime.Serialization.Json;
//+
namespace Nalarium.Web.Serialization
{
    public class DataContractJsonDataSerializer : DataSerializer
    {
        //- @Serialize -//
        public override String Serialize(Object data, Type type)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(type);
            System.IO.MemoryStream stream = new System.IO.MemoryStream( );
            serializer.WriteObject(stream, data);
            //+
            return Nalarium.IO.StreamConverter.GetStreamText(stream);
        }
    }
}