using System.ComponentModel.DataAnnotations;

namespace TopLine.Core.Models;

public class License
{
    public int Id { get; init; }
    [MaxLength(64)]
    public string Name { get; init; } = String.Empty;
    [MaxLength(64)]
    public string Client { get; init; } = String.Empty;
    [MaxLength(128)]
    public string? ContactInfo { get; init; }
    public bool AllRightsReserved { get; init; }
    public int Year { get; init; } = DateTime.Now.Year;
    public ICollection<ProjectLicense> ProjectLicenses { get; init; } = new List<ProjectLicense>();
}