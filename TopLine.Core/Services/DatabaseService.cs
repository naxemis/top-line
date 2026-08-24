using TopLine.Core.Contexts;
using TopLine.Core.Models;

namespace TopLine.Core.Services;

public class DatabaseService(DatabaseContext context) : IDatabaseService
{
    public async Task<Project?> GetProjectWithDetailsAsync(int projectId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Project> AddProjectAsync(Project project)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateProjectAsync(Project project)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteProjectAsync(int projectId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ProjectExistsAsync(int projectId)
    {
        throw new NotImplementedException();
    }

    public async Task<License?> GetLicenseByIdAsync(int licenseId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<License>> GetAllLicensesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<License> AddLicenseAsync(License license)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateLicenseAsync(License license)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteLicenseAsync(int licenseId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> LicenseExistsAsync(int licenseId)
    {
        throw new NotImplementedException();
    }
}