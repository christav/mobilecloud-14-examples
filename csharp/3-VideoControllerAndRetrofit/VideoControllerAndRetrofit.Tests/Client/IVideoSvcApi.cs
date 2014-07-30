using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using VideoControllerAndRetrofit.Models;

namespace VideoControllerAndRetrofit.Tests.Client
{
    public interface IVideoSvcApi
    {
        [Get("/video")]
        Task<List<Video>> GetVideoList();

        // Unfortunately, refit doesn't handle
        // bool as a response type, so
        // we'll just take a string.
        [Post("/video")]
        Task<string> AddVideo([Body] Video v);
    }
}
