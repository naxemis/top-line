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
        modelBuilder.Entity<License>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(64);
            entity.Property(e => e.Client).IsRequired().HasMaxLength(64);
            entity.Property(e => e.ContactInfo).HasMaxLength(128);
            entity.Property(e => e.AllRightsReserved).HasDefaultValue(false);
            entity.Property(e => e.Year).IsRequired(); // current year is initialized with the model
        });
    }

    private void ConfigureProjects(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(64);
            entity.Property(e => e.Description).HasMaxLength(1024);
            entity.Property(e => e.Path).IsRequired().HasMaxLength(512);
        });
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