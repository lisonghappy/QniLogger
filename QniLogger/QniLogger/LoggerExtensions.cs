using System;

public static class LoggerExtensions {

    public static void Log (this object obj, object msg) {
        Qni.QniLogger.Log(msg);
    }
    public static void Log (this object obj, string msg, params object[] args) {
        Qni.QniLogger.Log(string.Format(msg, args));
    }
    public static void LogColor (this object obj, Qni.ELogColor color, object msg) {
        Qni.QniLogger.LogColor(color, msg);
    }
    public static void LogColor (this object obj, Qni.ELogColor color, string msg, params object[] args) {
        Qni.QniLogger.LogColor(color, string.Format(msg, args));
    }
    public static void LogTrace (this object obj, object msg) {
        Qni.QniLogger.LogTrace(msg);
    }
    public static void LogTrace (this object obj, string msg, params object[] args) {
        Qni.QniLogger.LogTrace(string.Format(msg, args));
    }
    public static void LogWarning (this object obj, object msg) {
        Qni.QniLogger.LogWarning(msg);
    }
    public static void LogWarning (this object obj, string msg, params object[] args) {
        Qni.QniLogger.LogWarning(string.Format(msg, args));
    }
    public static void LogError (this object obj, string msg) {
        Qni.QniLogger.LogError(msg);
    }
    public static void LogError (this object obj, string msg, params object[] args) {
        Qni.QniLogger.LogError(string.Format(msg, args));
    }

    public static void LogPrintBytes (byte[] bytes, string prefix = "", Action<string> printer = null) {
        Qni.QniLogger.LogPrintBytes(bytes, prefix, printer);
    }
}