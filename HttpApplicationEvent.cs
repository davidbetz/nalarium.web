#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

//+
namespace Nalarium.Web
{
    public enum HttpApplicationEvent
    {
        BeginRequest,
        AuthenticateRequest,
        PostAuthenticateRequest,
        AuthorizeRequest,
        PostAuthorizeRequest,
        ResolveRequestCache,
        PostResolveRequestCache,
        MapRequestHandler,
        PostMapRequestHandler,
        AcquireRequestState,
        PostAcquireRequestState,
        PreRequestHandlerExecute,
        PostRequestHandlerExecute,
        ReleaseRequestState,
        PostReleaseRequestState,
        UpdateRequestCache,
        PostUpdateRequestCache,
        LogRequest,
        PostLogRequest,
        EndRequest
    }
}