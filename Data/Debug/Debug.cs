using System;

namespace IsoGame;

public enum LogType
{
    System,
    Warning,
    Error
}

public class Debug
{
    private static Debug debug = new Debug();

    public delegate void LogEventHandler(DebugProperties properties);
    public static event LogEventHandler LogEvent;

    private Debug()
    {
        LogEvent += MainLog;
    }

    public static void Log(string log, LogType logType)
    {
        var properties = new DebugProperties(log, logType, DateTime.Now);
        LogEvent.Invoke(properties);
    }

    private static void MainLog(DebugProperties properties)
    {
        switch (properties.logType)
        {
            case (LogType.System):
                Console.WriteLine("[" + properties.time + "]" + "[SYSTEM] : " + properties.log);
                break;
            case (LogType.Warning):
                Console.WriteLine("[" + properties.time + "]" + "[WARNING] : " + properties.log);
                break;
            case (LogType.Error):
                Console.WriteLine("[" + properties.time + "]" + "[ERROR] : " + properties.log);
                break;
        }
    }
}