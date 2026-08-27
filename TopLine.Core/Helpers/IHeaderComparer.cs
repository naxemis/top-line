namespace TopLine.Core.Helpers;

public interface IHeaderComparer
{
    bool IsHeaderValid(string fileContent, string header);
    string ReplaceHeader(string fileContent, string header);
}