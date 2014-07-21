namespace VideoServlet.Models
{
    /// <summary>
    /// A simple class to represent a video and its URL for viewing.
    /// </summary>
    public class Video
    {
        public Video()
        {
            
        }

        public Video(string name, string url, long duration)
        {
            Name = name;
            Url = url;
            Duration = duration;
        }

        public string Name { get; set; }
        public string Url { get; set; }
        public long Duration { get; set; }
    }
}