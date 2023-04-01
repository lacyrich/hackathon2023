using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Hackathon2023.Models;

namespace Hackathon2023.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Hackathon2023.Models.Tags>? Tags { get; set; }
        public DbSet<Hackathon2023.Models.Applicants>? Applicants { get; set; }
        public DbSet<Hackathon2023.Models.TagsApplicants>? TagsApplicants { get; set; }
    }
}