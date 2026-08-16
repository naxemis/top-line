namespace TopLine.Core.Models;

public class License
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Client { get; set; } = String.Empty;
    public string? ContactInfo { get; set; }
    public bool AllRightsReserved { get; set; } = false;
    public int Year { get; set; } = DateTime.Now.Year;
    public ICollection<ProjectLicense> ProjectLicenses { get; init; } = new List<ProjectLicense>();
}