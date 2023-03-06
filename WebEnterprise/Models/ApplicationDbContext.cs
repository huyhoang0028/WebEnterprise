using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;

using WebEnterprise.Models;


namespace WebEnterprise.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<Catogory> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CView> Views { get; set; }
        public DbSet<React> Reacts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<WebEnterprise.Models.CUser> CUser { get; set; } = default!;

    }
}