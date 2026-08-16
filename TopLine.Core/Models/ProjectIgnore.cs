using System.ComponentModel.DataAnnotations;

namespace TopLine.Core.Models;

// ProjectId, TargetType, and Target are unique
public class ProjectIgnore
{
    public int Id { get; init; }
    public int ProjectId { get; init; }
    public TargetType TargetType { get; init; }
    [MaxLength(512)]
    public string Target { get; init; } = String.Empty;
    public required Project Project { get; init; }
}