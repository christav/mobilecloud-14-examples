using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoServlet.Models
{
    /// <summary>
    /// This class describes the fields expected when
    /// posting to the /video URL and their validation
    /// rules.
    /// </summary>
    public class VideoPost
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Url { get; set; }

        [Required]
        public long Duration { get; set; }
    }
}
