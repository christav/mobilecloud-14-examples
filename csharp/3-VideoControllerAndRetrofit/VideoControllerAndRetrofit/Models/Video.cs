using System;
using Newtonsoft.Json;

namespace VideoControllerAndRetrofit.Models
{
    /// <summary>
    /// A simple object to represent a video and its URL for viewing.
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

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("url")]
        public String Url { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        protected bool Equals(Video other)
        {
            return string.Equals(Name, other.Name) && 
                string.Equals(Url, other.Url) && 
                Duration == other.Duration;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Video) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Url != null ? Url.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ Duration.GetHashCode();
                return hashCode;
            }
        }
    }
}
