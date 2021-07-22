using System;

namespace SocialMedia.Core.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public String Description { get; set; }
        public String Image { get; set; }

    }
}
