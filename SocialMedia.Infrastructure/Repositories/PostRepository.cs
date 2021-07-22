﻿using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = Enumerable.Range(1, 10).Select(p => new Post
            {
                PostId = p,
                Description = $"Description {p}",
                Date = DateTime.Now,
                Image = $"https://miaspis.com/{p}",
                UserId = p + 1
            });

            await Task.Delay(10);

            return posts;
        }
    }
}