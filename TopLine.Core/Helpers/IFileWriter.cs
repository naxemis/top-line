namespace TopLine.Core.Helpers;

public interface IFileWriter
{
    Task<string> WriteFileAsync(string path, string content);
}