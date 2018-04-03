using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YAS.Models.Interfaces;
using YAS.Models.Records;

namespace YAS.Models.Repositories
{
    public class PostRepository : IPostRepository
    {
        private ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<PostRecord> Posts => _context.Posts;

        public async Task Post(PostRecord post)
        {
            post.DateAdded = DateTime.Now;
            _context.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task Put(PostRecord post)
        {
            //var p = _context.Posts.First(a => a.Id == post.Id);
            //p.Title = post.Title;
            //p.Description = post.Description;
            foreach(var p in _context.Posts)
            {
                if(p.Id == post.Id)
                {
                    p.Title = post.Title;
                    p.Description = post.Description;
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var p = _context.Posts.Find(id);
            _context.Posts.Remove(p);
            await _context.SaveChangesAsync();
        }
    }
}