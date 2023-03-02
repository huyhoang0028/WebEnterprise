using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;

using WebEnterprise.Models;


namespace WebEnterprise.Data
{
    public class ApplicationDbContext : IdentityDbContext<CUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<Catogory> Catogories { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<Comment> Comment { get; set; }

        public DbSet<CView> Views { get; set; }
        public DbSet<React> Reacts { get; set; }
        public DbSet<Department> Departments { get; set; }
    }

    
   

}