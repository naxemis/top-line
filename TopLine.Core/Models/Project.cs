using System.ComponentModel.DataAnnotations;

namespace TopLine.Core.Models;

public class Project
{
    public int Id { get; init; }
    [MaxLength(64)]
    public string Name { get; init; } = String.Empty;
    [MaxLength(1024)]
    public string? Description { get; init; }
    [MaxLength(512)]
    public string Path { get; init; } = String.Empty;
    public ICollection<ProjectLicense> ProjectLicenses { get; init; } = new List<ProjectLicense>();
    public ICollection<ProjectIgnore> ProjectIgnores { get; init; } = new List<ProjectIgnore>();
}