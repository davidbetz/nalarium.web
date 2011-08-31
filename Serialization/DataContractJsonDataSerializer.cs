using System;
using System.IO;
using System.Runtime.Serialization.Json;
using Nalarium.IO;

namespace Nalarium.Web.Serialization
{
    public class DataContractJsonDataSerializer : DataSerializer
    {
        //- @Serialize -//
        public override String Serialize(Object data, Type type)
        {
            var serializer = new DataContractJsonSerializer(type);
            var stream = new MemoryStream();
            serializer.WriteObject(stream, data);
            //+
            return StreamConverter.GetStreamText(stream);
        }
    }
}