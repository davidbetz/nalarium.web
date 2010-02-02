using System;
using System.Runtime.Serialization;
//+
namespace Nalarium.Web.Serialization
{
    public class DataContractDataSerializer : DataSerializer
    {
        //- @Serialize -//
        public override String Serialize(Object data, Type type)
        {
            DataContractSerializer serializer = new DataContractSerializer(type);
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            serializer.WriteObject(stream, data);
            //+
            return Nalarium.IO.StreamConverter.GetStreamText(stream);
        }
    }
}