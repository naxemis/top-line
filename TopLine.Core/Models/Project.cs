namespace TopLine.Core.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string? Description { get; set; }
    public string Path { get; set; } = String.Empty;
}