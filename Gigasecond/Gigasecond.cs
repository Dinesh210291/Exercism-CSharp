using System;

public static class Gigasecond
{
    private const int _gigaSeconds = 1000000000;

    public static DateTime Add(DateTime moment)
    {
        //Calculate total ticks from 'moment' datetime parameter and constant giga seconds
        var totalTicks = TimeSpan.FromSeconds(_gigaSeconds).Ticks + moment.Ticks;
        return new DateTime(totalTicks);
    }
}