using Microsoft.Extensions.Logging;

namespace TopLine.Core.Helpers;

public class CommentStyleProvider(ILogger<CommentStyleProvider> logger)
{
    private static readonly List<string> DoubleSlashExtensions = [ ".cs", ".js", ".java", ".cpp", ".c", ".h", ".hpp", ".ts", ".go", ".rs", ".kt", ".swift" ];
    private static readonly List<string> HashExtensions = [ ".py", ".gd", ".sh", ".bash", ".yml", ".yaml", ".tf", ".rb", ".pl", ".pm" ];
    private static readonly List<string> SlashStarExtensions = [ ".css", ".scss", ".sass", ".less" ];
    private static readonly List<string> AngleBracketExtensions = [ ".html", ".htm", ".xml", ".svg", ".xaml", ".xsd", ".xslt", ".aspx", ".ascx" ];

    private readonly Dictionary<CommentStyle, List<string>> _styleExtensions = new()
    {
        { CommentStyle.DoubleSlash, DoubleSlashExtensions },
        { CommentStyle.Hash, HashExtensions },
        { CommentStyle.SlashStar, SlashStarExtensions },
        { CommentStyle.AngleBracket, AngleBracketExtensions }
    };

    private readonly Dictionary<CommentStyle, (string Start, string End)> _styleComments = new()
    {
        { CommentStyle.DoubleSlash, ("//", "") },
        { CommentStyle.Hash, ("#", "") },
        { CommentStyle.SlashStar, ("/*", "*/") },
        { CommentStyle.AngleBracket, ("<!--", "-->") }
    };

    public CommentStyle? GetCommentStyle(string fileExtension)
    {
        if (string.IsNullOrEmpty(fileExtension))
        {
            logger.LogWarning("File extension is null or empty!");
            return null;
        }

        string normalizedExtension = fileExtension.ToLower();
        foreach (var style in _styleExtensions)
        {
            if (style.Value.Contains(normalizedExtension))
            {
                return style.Key;
            }
        }

        logger.LogWarning("No comment style found for extension: {FileExtension}!", fileExtension);
        return null;
    }

    public string GetCommentStart(CommentStyle style) => _styleComments[style].Start;
    public string GetCommentEnd(CommentStyle style) => _styleComments[style].End;
}
