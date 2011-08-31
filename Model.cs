#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Reflection;

namespace Nalarium.Web
{
    public abstract class Model
    {
        private static Object _lock = new Object();
        private Type _type;

        //+
        //- #Data -//
        protected Object ModelData { get; set; }

        public Object this[String propertyName]
        {
            get
            {
                if (_type == null)
                {
                    _type = GetType();
                }
                //+
                PropertyInfo pi = _type.GetProperty(propertyName);
                if (pi == null)
                {
                    return null;
                }
                //+
                return pi.GetValue(this, null);
            }
        }

        //+
        //- ~Init -//
        internal void Init()
        {
            ModelData = InitModelData();
        }

        //- @InitModelData -//
        protected virtual Object InitModelData()
        {
            return null;
        }

        //- @LoadData -//
        public TData LoadModel<TData>() where TData : class
        {
            return ModelData as TData;
        }
    }
}