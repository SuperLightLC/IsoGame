using System;
namespace IsoGame;

public class DebugProperties
{
    public readonly string log;
    public readonly LogType logType;
    public readonly DateTime time;

    public DebugProperties(string log, LogType logType, DateTime time)
    {
        this.log = log;
        this.logType = logType;
        this.time = time;
    }
}