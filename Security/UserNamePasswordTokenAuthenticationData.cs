using System;

namespace Nalarium.Web.Security
{
    public class UserNamePasswordTokenAuthenticationData : UserNamePasswordAuthenticationData
    {
        //- @TokenSource -//
        /// <summary>
        /// Represents the category, group, or general source to which a token associates.  This may be a web site ID, a token service ID, or anything else.  It's essentially a way of identifying different token groups.
        /// </summary>
        public String TokenSource { get; set; }

        //- @Token -//
        public String Token { get; set; }

        //- @HasToken -//
        public Boolean HasToken
        {
            get
            {
                return !String.IsNullOrEmpty(Token);
            }
        }
    }
}