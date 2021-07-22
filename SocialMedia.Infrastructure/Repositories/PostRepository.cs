using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository
    {
        public IEnumerable<Post> GetPosts()
        {
            var posts = Enumerable.Range(1, 10).Select(p => new Post
            {
                PostId = p,
                Description = $"Description {p}",
                Date = DateTime.Now,
                Image = $"https://miaspis.com/{p}",
                UserId = p + 1
            });

            return posts;
        }
    }
}
