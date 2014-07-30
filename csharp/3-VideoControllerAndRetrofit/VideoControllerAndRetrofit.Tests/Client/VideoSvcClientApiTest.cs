using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;
using VideoControllerAndRetrofit.Models;
using Xunit;

namespace VideoControllerAndRetrofit.Tests.Client
{
    //
    // This test sends a POST request to the VideoServlet to add a new video and
    // then sends a second GET request to check that the video showed up in the list
    // of videos.
    // 
    // The test requires that the application be running first (see the directions in
    // the README.md file for how to launch the application.
    // 
    // This test uses the Refit library (https://github.com/paulcbetts/refit), a
    // .NET library inspired by Retrofit.
    // 
    public class VideoSvcClientApiTest
    {
        private const string testUrl = "http://localhost:8080";

        // Set up the proxy by calling Refit.
        private readonly IVideoSvcApi videoService = RestService.For<IVideoSvcApi>(testUrl);

        [Fact]
        public async Task TestVideoAddAndList()
        {
            var video = new Video
            {
                Name = "Programming Cloud Services for Android Handheld Systems",
                Duration = 60*10*1000,
                Url = "http://coursera.org/some/video"
            };

            bool ok = bool.Parse(await videoService.AddVideo(video));
            Assert.True(ok);

            List<Video> videos = await videoService.GetVideoList();
            Assert.True(videos.Contains(video));
        }
    }
}
