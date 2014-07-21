using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleServlet.Controllers
{
    public class EchoController : Controller
    {
        // GET: Echo
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
