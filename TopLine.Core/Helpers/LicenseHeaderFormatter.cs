using Microsoft.Extensions.Logging;
using TopLine.Core.Models;

namespace TopLine.Core.Helpers;

public class LicenseHeaderFormatter(ILogger<LicenseHeaderFormatter> logger, CommentStyleProvider commentStyleProvider) : ILicenseHeaderFormatter
{
    private List<string> BuildHeaderLines(License license)
    {
        var lines = new List<string>();

        string copyrightLine = $"Copyright (c) {license.Year} {license.Client}.";
        if (license.AllRightsReserved) copyrightLine += " All rights reserved.";
        lines.Add(copyrightLine);

        if (!string.IsNullOrWhiteSpace(license.ContactInfo)) lines.Add($"Contact: {license.ContactInfo}");

        return lines;
    }

    private string FormatWithLinePrefix(string commentStart, string commentEnd, List<string> lines)
    {
        for (int index = 0; index < lines.Count; index++)
        {
            lines[index] = $"{commentStart} {lines[index]}";
        }
        return string.Join(Environment.NewLine, lines);
    }

    private string FormatWithBlockWrapper(string commentStart, string commentEnd, List<string> lines)
    {
        var wrapped = new List<string> { commentStart };
        wrapped.AddRange(lines);
        wrapped.Add(commentEnd);
        return string.Join(Environment.NewLine, wrapped);
    }

    private string FormatWithAsteriskWrapper(string commentStart, string commentEnd, List<string> lines)
    {
        var wrapped = new List<string> { commentStart };
        foreach (var line in lines) wrapped.Add($" * {line}");
        wrapped.Add(commentEnd);
        return string.Join(Environment.NewLine, wrapped);
    }

    public string Format(License license, CommentStyle commentStyle)
    {
        var lines = BuildHeaderLines(license);

        string commentStart = commentStyleProvider.GetCommentStart(commentStyle);
        string commentEnd = commentStyleProvider.GetCommentEnd(commentStyle);

        switch (commentStyle)
        {
            case CommentStyle.DoubleSlash:
                return FormatWithLinePrefix(commentStart, commentEnd, lines);
            case CommentStyle.Hash:
                return FormatWithLinePrefix(commentStart, commentEnd, lines);
            case CommentStyle.AngleBracket:
                return FormatWithBlockWrapper(commentStart, commentEnd, lines);
            case CommentStyle.SlashStar:
                return FormatWithAsteriskWrapper(commentStart, commentEnd, lines);
            default:
                logger.LogWarning("Unsupported comment style: {CommentStyle}. Returning unformatted license header.", commentStyle);
                return string.Join(Environment.NewLine, lines);
        }
    }
}