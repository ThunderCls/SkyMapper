using System.Text.RegularExpressions;

namespace SkyMapper.Utils;

public static class StringUtils
{
    public static bool IsValidRegexPattern(string pattern)
    {
        try
        {
            _ = new Regex(pattern);
            return true;
        }
        catch (RegexParseException)
        {
            return false;
        }
    }
}