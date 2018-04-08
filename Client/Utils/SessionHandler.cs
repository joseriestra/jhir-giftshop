using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;

namespace Client.Utils
{
    public class SessionHandler : HttpControllerHandler, IRequiresSessionState
    {
        public SessionHandler(RouteData routeData) : base(routeData) { }
    }
}