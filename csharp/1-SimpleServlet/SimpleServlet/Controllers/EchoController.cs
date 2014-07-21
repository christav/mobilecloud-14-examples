using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleServlet.Controllers
{
    /// <summary>
    /// An example of a very simple controller that looks for a single request
    /// parameter and echos the parameter value back to the client using
    /// the "text/plain" content type.
    /// </summary>
    public class EchoController : Controller
    {
        // GET: Echo
        /// <summary>
        /// This method is called when a GET request for the /echo route
        /// is routed to this controller (see the RouteConfig.cs file for details
        /// on how routing is set up).
        /// </summary>
        /// <param name="msg">The message to echo. The ASP.NET MVC model binder
        /// looks for this field in the query parameters or in a url encoded form
        /// body. If the field is not found null will be passed to the controller.
        /// </param>
        /// <returns>A ContentResult object that contains the content type and string
        /// to return. The MVC framework takes this object and renders it into the
        /// actual HTTP response.
        /// </returns>
        public ActionResult Index(string msg)
        {
            return new ContentResult()
            {
                Content = "Echo:" + msg,
                ContentType = "text/plain"
            };
        }
    }
}
