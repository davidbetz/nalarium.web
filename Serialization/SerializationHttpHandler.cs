using System;
using Nalarium.Reflection;
//+

//+
//+

namespace Nalarium.Web.Serialization
{
    public abstract class SerializationHttpHandler : ReusableHttpHandler
    {
        //- @SerializationMode -//
        public SerializationMode SerializationMode { get; set; }

        //- @Type -//
        public Type Type { get; set; }

        //- @Data -//
        public Object Data { get; set; }

        //- @Serializer -//
        public DataSerializer Serializer { get; set; }

        //+
        //- @ProcessInternal -//
        public void ProcessInternal()
        {
            //+ run
            SetupData();
            //+ check
            if (Data == null)
            {
                return;
            }
            if (Type == null)
            {
                Type = Data.GetType();
            }
            //+ serialize
            if (Serializer == null)
            {
                Serializer = DataSerializerFactory.GetDataSerializer(SerializationMode);
                if (Serializer == null)
                {
                    return;
                }
            }
            Output.Append(Serializer.Serialize(Data, Type));
        }

        //- @Process -//
        public override void Process()
        {
            RunForVerb();
        }

        //- @SetupData -//
        public abstract void SetupData();

        //- $RunProcessorForVerb -//
        internal void RunForVerb()
        {
            var runForVerbAttribute = AttributeReader.ReadTypeAttribute<RunForVerbsAttribute>(this);
            if (runForVerbAttribute == null)
            {
                return;
            }
            HttpVerbs httpVerbs = runForVerbAttribute.HttpVerbs;
            if (Http.Method == HttpVerbs.Get && (httpVerbs & HttpVerbs.Get) == HttpVerbs.Get)
            {
                ProcessInternal();
            }
            if (Http.Method == HttpVerbs.Post && (httpVerbs & HttpVerbs.Post) == HttpVerbs.Post)
            {
                ProcessInternal();
            }
        }
    }
}