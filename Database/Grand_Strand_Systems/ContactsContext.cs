using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grand_Strand_Systems
{
    class ContactsContext : DbContext
    {
        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=C:\contacts.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactModel>().Ignore(c => c.Appointments);
        }
    }
}
