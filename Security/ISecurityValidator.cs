using System;

namespace Nalarium.Web.Security
{
    public interface ISecurityValidator
    {
        //- IsValid -//
        Boolean IsValid();

        //- Logout -//
        void Logout();
    }
}