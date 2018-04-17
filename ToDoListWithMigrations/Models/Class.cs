using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoListWithMigrations.Models
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext()
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=ToDoListWithMigrations;uid=root;pwd=root;");
        }

        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}