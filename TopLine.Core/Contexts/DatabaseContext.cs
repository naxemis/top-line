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
        modelBuilder.Entity<ProjectLicense>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ProjectId).IsRequired();
            entity.Property(e => e.LicenseId).IsRequired();
            entity.Property(e => e.TargetType).IsRequired();
            entity.Property(e => e.Target).IsRequired().HasMaxLength(512);

            entity.HasIndex(e => new { e.ProjectId, e.TargetType, e.Target }).IsUnique();

            entity.HasOne(pl => pl.Project)
                .WithMany(p => p.ProjectLicenses)
                .HasForeignKey(pl => pl.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(pl => pl.License)
                .WithMany(l => l.ProjectLicenses)
                .HasForeignKey(pl => pl.LicenseId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private void ConfigureProjectIgnores(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectIgnore>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ProjectId).IsRequired();
            entity.Property(e => e.TargetType).IsRequired();
            entity.Property(e => e.Target).IsRequired().HasMaxLength(512);

            entity.HasOne(pi => pi.Project)
                .WithMany(p => p.ProjectIgnores)
                .HasForeignKey(pi => pi.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}