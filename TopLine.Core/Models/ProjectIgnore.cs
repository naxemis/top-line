namespace TopLine.Core.Models;

// ProjectId, TargetType, and Target are unique
public class ProjectIgnore
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public TargetType TargetType { get; set; }
    public string Target { get; set; } = String.Empty;
    public required Project Project { get; init; }
}