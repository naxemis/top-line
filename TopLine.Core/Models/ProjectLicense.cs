namespace TopLine.Core.Models;

// ProjectId, TargetType, and Target are unique
public class ProjectLicense
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public int LicenseId { get; set; }
    public TargetType TargetType { get; set; }
    public string Target { get; set; } = String.Empty;
    public required Project Project { get; init; }
    public required License License { get; init; }
}