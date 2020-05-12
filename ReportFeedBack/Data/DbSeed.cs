using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportFeedBack.Data
{
    public class DbSeed
    {
        private readonly FeedBackDbContext _context;

        public DbSeed(FeedBackDbContext context)
        {
            _context = context;
        }
        public void Init()
        {
            if (!_context.User.Any())
            {
                _context.User.Add(new Entity.User
                {
                    UserName = "User",
                    RoleName = "Admin",


                });
                _context.User.Add(new Entity.User
                {
                    UserName = "User1",
                    RoleName = "Admin",
                }); ;
                _context.SaveChanges();
            }
            if (!_context.Post.Any())
            {
                _context.Post.Add(new Entity.Post
                {
                    UserId = 1,
                    Title = "Post1",
                    Description = "N/A",
                    EntryDate = DateTime.Now,
                    Comments = new List<Entity.Comment> { new Entity.Comment { Desc = "N/A", Like = 1, Dislike = 0, UserId = 1,EntryDate=DateTime.Now }, new Entity.Comment { Desc = "N/A", Like = 1, Dislike = 2, UserId = 2, EntryDate = DateTime.Now } }

                }); 
                _context.Post.Add(new Entity.Post
                {
                    UserId = 2,
                    Title = "Post2",
                    Description = "N/A",
                    EntryDate = DateTime.Now,
                    Comments = new List<Entity.Comment> { new Entity.Comment { Desc = "N/A", Like = 45, Dislike = 0, UserId = 2, EntryDate = DateTime.Now } }

                });
                _context.Post.Add(new Entity.Post
                {
                    UserId = 2,
                    Title = "Post3",
                    Description = "N/A",
                    EntryDate = DateTime.Now,
                    Comments = new List<Entity.Comment> { new Entity.Comment { Desc = "N/A", Like = 45, Dislike = 0, UserId = 2, EntryDate = DateTime.Now } }

                });
                _context.Post.Add(new Entity.Post
                {
                    UserId = 1,
                    Title = "Post4",
                    Description = "N/A",
                    EntryDate = DateTime.Now,
                    Comments = new List<Entity.Comment> { new Entity.Comment { Desc = "N/A", Like = 45, Dislike = 0, UserId = 1, EntryDate = DateTime.Now } }

                });
                _context.SaveChanges();
            }
        }
    }
}
