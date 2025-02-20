namespace Learn_Code_2025.Helpers;

public static class StringHelper
{
    public static string ToUpperSpecial(this string text)
    {
        return text.ToUpper() + "Special";
    }
}