using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Core.Entities.Entity;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework.Contexts
{
    public class ChatContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ChatDb;Trusted_Connection=true");
        }
        public DbSet<User> User { get; set; }
        public DbSet<Message> Message { get; set; }
    }
}
