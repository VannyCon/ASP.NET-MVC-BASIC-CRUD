// Data/ApplicationDbContext.cs

using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<UserDetails> UserInfo { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employee { get; set; }
    public DbSet<Designation> Designation { get; set; }
    public DbSet<UserAccount> UserAccount { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Map the UserDetails entity to the "userinfo" table
        modelBuilder.Entity<UserDetails>().ToTable("userinfo");
    }
}
