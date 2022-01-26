using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace MobileApp
{
    public class BlogginDbContext: DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public BlogginDbContext()
        {
            SQLitePCL.Batteries_V2.Init();

            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "blogs.db3");

            optionsBuilder
                .UseSqlite($"Filename={dbPath}");
        }

        public class Blog
        {
            public int BlogId { get; set; }
            public string Url { get; set; }
            public int Rating { get; set; }
        }
    }
}
