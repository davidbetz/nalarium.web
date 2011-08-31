//+

namespace Nalarium.Web.Serialization
{
    public static class DataSerializerFactory
    {
        public static DataSerializer GetDataSerializer(SerializationMode mode)
        {
            switch (mode)
            {
                    //+ json
                case SerializationMode.DataContractJson:
                    return new DataContractJsonDataSerializer();

                    //+ xml
                case SerializationMode.DataContract:
                    return new DataContractDataSerializer();

                    //+ javascript
                case SerializationMode.DynamicJavaScript:
                    return new DynamicJavaScriptDataSerializer();
            }
            //+
            return null;
        }
    }
}