using eDnevnik.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eDnevnik.Infrastructure
{
    //public class AuthContext : IdentityDbContext<IdentityUser>
    //{
    //    public AuthContext() : base("AuthContext") { }
    //}

    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext() : base("AuthContext")
        {
            Database.SetInitializer<AuthContext>(new DataSeedClass());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Mark>().ToTable("Marks");
            modelBuilder.Entity<Parent>().ToTable("Parents");
            modelBuilder.Entity<Pupil>().ToTable("Pupils");
            modelBuilder.Entity<Subject>().ToTable("Subjects");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            modelBuilder.Entity<Class>().ToTable("Classes");

        }
        public new DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }        
    }
}