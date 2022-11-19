using Education.DataBase.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Education.DataBase;

public class EducationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public EducationDbContext(DbContextOptions<EducationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
}