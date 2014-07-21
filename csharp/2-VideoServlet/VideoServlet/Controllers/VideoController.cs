using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VideoServlet.Models;

namespace VideoServlet.Controllers
{
    public class VideoController : Controller
    {
        public const string VideoAdded = "Video added.";

        // An in-memory list that the controller uses to store the
        // videos that are sent to it by clients.
        //
        // This is static because controllers are typically created
        // on the fly per request by the MVC framework, so this
        // data will be lost between requests if it's per-instance.
        private static List<Video> videos = new List<Video>(); 

        // A lock that will be used to synchronize access - different
        // requests will be running on different threads.
        private static object padlock = new object();

        // GET: Video
        /// <summary>
        /// This method processes the HTTP GET requests to the
        /// /video url.
        /// </summary>
        /// <returns>The ActionResult representing the resulting
        /// HTTP response.</returns>
        public ActionResult Index()
        {
            lock (padlock)
            {
                return new ContentResult
                {
                    ContentType = "text/plain",
                    Content = string.Join("", 
                        videos.Select(v => string.Format("{0}: {1}\n", v.Name, v.Url)))
                };
            }
        }

        /// <summary>
        /// This method processes the HTTP POST requests to the
        /// /video url.
        /// </summary>
        /// <param name="postData">This is the request data from the
        /// post body. The MVC model binder takes care of the required
        /// validations, and set the ModelState.IsValid property based on
        /// the results of validation.</param>
        /// <returns>The post result.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(VideoPost postData)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(400, "Missing ['name','duration','url'].");
            }

            var v = new Video(postData.Name, postData.Url, postData.Duration);
            lock (padlock)
            {
                videos.Add(v);
            }

            return new HttpStatusCodeResult(200, VideoAdded);
        }
    }
}
