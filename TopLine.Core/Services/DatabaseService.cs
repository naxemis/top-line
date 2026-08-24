using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TopLine.Core.Contexts;
using TopLine.Core.Models;

namespace TopLine.Core.Services;

public class DatabaseService(ILogger<DatabaseService> logger, DatabaseContext context) : IDatabaseService
{
    public async Task<Project?> GetProjectWithDetailsAsync(int projectId)
    {
        return await context.Projects
            .Include(p => p.ProjectLicenses)
            .ThenInclude(pl => pl.License)
            .Include(p => p.ProjectIgnores)
            .FirstOrDefaultAsync(p => p.Id == projectId);
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync()
    {
        return await context.Projects.OrderBy(p => p.Name).ToListAsync();
    }

    public async Task<Project> AddProjectAsync(Project project)
    {
        context.Projects.Add(project);
        await context.SaveChangesAsync();
        return project;
    }

    public async Task UpdateProjectAsync(Project project)
    {
        context.Projects.Update(project);
        await context.SaveChangesAsync();
    }

    public async Task DeleteProjectAsync(int projectId)
    {
        var project = await context.Projects.FindAsync(projectId);
        if (project == null)
        {
            logger.LogWarning("Project with ID {ProjectId} was not found!", projectId);
            return;
        }
        context.Projects.Remove(project);
        await context.SaveChangesAsync();
    }

    public async Task<bool> ProjectExistsAsync(int projectId)
    {
        return await context.Projects.AnyAsync(p => p.Id == projectId);
    }

    public async Task<License?> GetLicenseByIdAsync(int licenseId)
    {
        return await context.Licenses.FindAsync(licenseId);
    }

    public async Task<IEnumerable<License>> GetAllLicensesAsync()
    {
        return await context.Licenses.OrderBy(l => l.Name).ToListAsync();
    }

    public async Task<License> AddLicenseAsync(License license)
    {
        context.Licenses.Add(license);
        await context.SaveChangesAsync();
        return license;
    }

    public async Task UpdateLicenseAsync(License license)
    {
        context.Licenses.Update(license);
        await context.SaveChangesAsync();
    }

    public async Task DeleteLicenseAsync(int licenseId)
    {
        var license = await context.Licenses.FindAsync(licenseId);
        if (license == null)
        {
            logger.LogWarning("License with ID {LicenseID} not found!", licenseId);
            return;
        }

        context.Licenses.Remove(license);
        await context.SaveChangesAsync();
    }

    public async Task<bool> LicenseExistsAsync(int licenseId)
    {
        return await context.Licenses.AnyAsync(l => l.Id == licenseId);
    }
}