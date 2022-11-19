using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Education.DataBase;

public class SqlServerDatabaseInstanceFactory : IDesignTimeDbContextFactory<EducationDbContext>
{
    public EducationDbContext CreateDbContext(string[] args)
        => new(new DbContextOptionsBuilder<EducationDbContext>().UseSqlServer().Options);
}