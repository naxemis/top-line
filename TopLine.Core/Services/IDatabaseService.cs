using TopLine.Core.Models;

namespace TopLine.Core.Services;

public interface IDatabaseService
{
    Task<Project?> GetProjectWithDetailsAsync(int projectId);
    Task<IEnumerable<Project>> GetAllProjectsAsync();
    Task<Project> AddProjectAsync(Project project);
    Task UpdateProjectAsync(Project project);
    Task DeleteProjectAsync(int projectId);
    Task<bool> ProjectExistsAsync(int projectId);

    Task<License?> GetLicenseByIdAsync(int licenseId);
    Task<IEnumerable<License>> GetAllLicensesAsync();
    Task<License> AddLicenseAsync(License license);
    Task UpdateLicenseAsync(License license);
    Task DeleteLicenseAsync(int licenseId);
    Task<bool> LicenseExistsAsync(int licenseId);
}