using Microsoft.EntityFrameworkCore;
using TopLine.Core.Models;

namespace TopLine.Core.Contexts;

public class DatabaseContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<License> Licenses { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectLicense> ProjectLicenses { get; set; }
    public DbSet<ProjectIgnore> ProjectIgnores { get; set; }

    private void ConfigureLicenses(ModelBuilder modelBuilder)
    {

    }

    private void ConfigureProjects(ModelBuilder modelBuilder)
    {

    }

    private void ConfigureProjectLicenses(ModelBuilder modelBuilder)
    {

    }

    private void ConfigureProjectIgnores(ModelBuilder modelBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}