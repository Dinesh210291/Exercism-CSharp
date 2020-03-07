using System;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        var str = input.ToCharArray();
        Array.Reverse(str);
        return new string(str);
    }
}