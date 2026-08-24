namespace TopLine.Core.Helpers;

public interface ICommentStyleProvider
{
    CommentStyle? GetCommentStyle(string fileExtension);
    string GetCommentStart(CommentStyle style);
    string GetCommentEnd(CommentStyle style);
}