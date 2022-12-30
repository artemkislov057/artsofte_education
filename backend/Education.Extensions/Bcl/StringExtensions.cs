namespace Education.Extensions.Bcl;

public static class StringExtensions
{
    public static string WithUpperFirstLetter(this string source)
        => char.ToUpper(source[0]) + source[1..];
}