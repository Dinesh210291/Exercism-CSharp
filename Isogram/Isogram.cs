using System;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        word = word.ToLower();
        char[] arr = word.ToCharArray();
        Array.Sort(arr);
        for (int i = 0; i < word.Length - 1; i++)
        {
             if (char.IsLetter(arr[i]) && arr[i] == arr[i + 1])
                 return false;
        }
        return true;
    }
}
