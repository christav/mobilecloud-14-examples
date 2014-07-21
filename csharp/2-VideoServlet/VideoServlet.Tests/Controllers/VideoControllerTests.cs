using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using VideoServlet.Controllers;
using VideoServlet.Models;
using VideoServlet.Tests.TestSupport;
using Xunit;

namespace VideoServlet.Tests.Controllers
{
    public class VideoControllerTests
    {
        [Fact]
        public void VideoAddAndList()
        {
            // Information about the video
            // We create a random string for the title so we can ensure
            // that the video is added after every run of this test.
            string myRandomId = Guid.NewGuid().ToString();
            string title = string.Format("Video - {0}", myRandomId);
            string videoUrl = string.Format("http://coursera.org/some/video-{0}", myRandomId);
            long duration = 60*10*1000; // 10min in milliseconds

            // Create the post data
            var post = new VideoPost
            {
                Name = title,
                Url = videoUrl,
                Duration = duration
            };

            // Send the post request to the controller.
            var c1 = new VideoController();
            var response = (HttpStatusCodeResult) c1.Index(post);

            // Check that we got an HTTP 200 OK status response code
            Assert.Equal(200, response.StatusCode);

            // Make sure the response is what we expect. Rather than trying to
            // keep th respose message from the VideoController in sync with this
            // test, we simply use a public constant on the VideoController so
            // that we can refer to the message in both places and avoid the
            // test and controller definition of the message drifting out of sync.
            Assert.Equal(VideoController.VideoAdded, response.StatusDescription);

            // Now that we have posted the video to the server, we contruct a
            // GET request to fetch the list of videos from the controller.

            // Note: Using a second controller to simulate the request lifetime of a
            // controller.
            var c2 = new VideoController();
            var getResponse = (ContentResult) c2.Index();

            // Construct a representation of the text that we are expecting
            // to see in the response representing our video.
            string expectedVideoEntry = string.Format("{0}: {1}\n", title, videoUrl);

            // Check that our video shows up in the list by searching for the
            // expectedVideoEntry in the text of the response body.
            Assert.Contains(expectedVideoEntry, getResponse.Content);
        }

        [Fact]
        public void DetectingMissingInputParameters()
        {
            var controller = new VideoController();
            var post = new VideoPost()
            {
                Name = "",
                Url = string.Format("http://coursera.org/some/video-{0}", Guid.NewGuid()),
                Duration = 10*60*1000
            };

            controller.ValidateModel(post);
            var result = controller.Index(post);

            Assert.IsType<HttpStatusCodeResult>(result);
            Assert.Equal(400, ((HttpStatusCodeResult)result).StatusCode);
        }
    }
}
