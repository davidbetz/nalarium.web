using System;
using System.IO;
using System.Runtime.Serialization;
using Nalarium.IO;

namespace Nalarium.Web.Serialization
{
    public class DataContractDataSerializer : DataSerializer
    {
        //- @Serialize -//
        public override String Serialize(Object data, Type type)
        {
            var serializer = new DataContractSerializer(type);
            var stream = new MemoryStream();
            serializer.WriteObject(stream, data);
            //+
            return StreamConverter.GetStreamText(stream);
        }
    }
}