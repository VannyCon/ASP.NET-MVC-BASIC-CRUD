// Data/ApplicationDbContext.cs

using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employee { get; set; }
    public DbSet<Designation> Designation { get; set; }
    public DbSet<UserAccount> UserAccount { get; set; }

}
