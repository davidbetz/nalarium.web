#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Runtime.Serialization;

namespace Nalarium.Web
{
    [Serializable]
    public class InvalidLicenseException : Exception
    {
        //- @Ctor -//
        public InvalidLicenseException()
        {
        }

        public InvalidLicenseException(String message)
            : base(message)
        {
        }

        public InvalidLicenseException(String message, Exception inner)
            : base(message, inner)
        {
        }

        protected InvalidLicenseException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}