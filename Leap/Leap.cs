using System;

public static class Leap
{
    public static bool IsLeapYear(int year)
    {
        if (year <= 0)
            return false;
        else
            return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
    }
}