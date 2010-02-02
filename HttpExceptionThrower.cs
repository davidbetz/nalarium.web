#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
using System.Web;
//+
namespace Nalarium.Web
{
    public static class HttpExceptionThrower
    {
        //- @Throw404 -//
        public static void Throw404(String message)
        {
            throw new HttpException(404, message);
        }

        //- @Throw500 -//
        public static void Throw500(String message)
        {
            throw new HttpException(500, message);
        }
    }
}