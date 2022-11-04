using UnityEngine;
using System;

public class Timer
{
    private DateTime _start;
    private DateTime _end;

    public void StartTimer() => _start = DateTime.Now;
    public void StopTimer() => _end = DateTime.Now;

    public double CalcDifference()
    {
        TimeSpan difference =  _end - _start;
        return difference.TotalSeconds;
    }
}
