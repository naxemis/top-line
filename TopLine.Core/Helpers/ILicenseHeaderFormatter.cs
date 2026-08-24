using TopLine.Core.Models;

namespace TopLine.Core.Helpers;

public interface ILicenseHeaderFormatter
{
    string Format(License license, CommentStyle commentStyle);
}