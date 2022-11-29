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
    public delegate void LogEventHandler(DebugProperties properties);
    public static event LogEventHandler LogEvent;

    public static void Log(string log, LogType logType)
    {
        switch (logType)
        {
            case (LogType.System):
                Console.WriteLine("[" + DateTime.Now + "]" + "[SYSTEM] : " + log);
                break;
            case (LogType.Warning):
                Console.WriteLine("[" + DateTime.Now + "]" + "[WARNING] : " + log);
                break;
            case (LogType.Error):
                Console.WriteLine("[" + DateTime.Now + "]" + "[ERROR] : " + log);
                break;
        }

        //TODO:イベント用にDebugPropertiesのパラメーターを作成する
        //例: new DebugProperties(logType, DateTime.Now, Log);
        var properties = new DebugProperties();
        LogEvent.Invoke(properties);
    }
}