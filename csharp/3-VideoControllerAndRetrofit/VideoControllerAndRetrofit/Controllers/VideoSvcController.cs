using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using VideoControllerAndRetrofit.Models;

namespace VideoControllerAndRetrofit.Controllers
{
    public class VideoSvcController : Controller
    {
        private static readonly List<Video> videos = new List<Video>();

        public ActionResult Video()
        {
            return Content(JsonConvert.SerializeObject(videos));
        }

        [HttpPost]
        public ActionResult Video(Video video)
        {
            videos.Add(video);
            return Json(true);
        }
    }
}
