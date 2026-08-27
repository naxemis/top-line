namespace TopLine.Core.Helpers;

public interface IFileReader
{
    Task<string> ReadFileAsync(string path);
}