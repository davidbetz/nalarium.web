using System;
//+
namespace Nalarium.Web.Serialization
{
    public abstract class DataSerializer
    {
        //- @Serialize -//
        public abstract String Serialize(Object data, Type type);
    }
}