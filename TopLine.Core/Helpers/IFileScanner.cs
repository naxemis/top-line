namespace TopLine.Core.Helpers;

public interface IFileScanner
{
    IEnumerable<string> GetFiles(string directory, bool recursive = true);
}