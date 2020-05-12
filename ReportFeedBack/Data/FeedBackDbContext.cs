using Microsoft.EntityFrameworkCore;
using ReportFeedBack.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportFeedBack.Data
{
    public class FeedBackDbContext:DbContext
    {
        public FeedBackDbContext(DbContextOptions<FeedBackDbContext> options):base(options)
        {

        }
        public DbSet<Post> Post { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<User> User { get; set; }

    }
}
