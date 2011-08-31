#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System.Web.SessionState;

namespace Nalarium.Web
{
    public abstract class ReusableSessionHttpHandler : ReusableHttpHandler, IRequiresSessionState
    {
    }
}