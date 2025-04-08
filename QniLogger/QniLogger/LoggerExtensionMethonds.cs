using System;

namespace Qni {

    public static class LoggerExtensionMethonds {

        public static void Log (this object obj, object msg) {
            QniLogger.Log(msg);
        }
        public static void Log (this object obj, string format, params object[] args) {
            QniLogger.Log(format, args);
        }


        public static void LogColor (this object obj, ELogColor color, object msg) {
            QniLogger.LogColor(color, msg);
        }
        public static void LogColor (this object obj, ELogColor color, string format, params object[] args) {
            QniLogger.LogColor(color, format, args);
        }


        public static void LogTrace (this object obj, object msg) {
            QniLogger.LogTrace(msg);
        }
        public static void LogTrace (this object obj, string format, params object[] args) {
            QniLogger.LogTrace(format, args);
        }


        public static void LogWarning (this object obj, object msg) {
            QniLogger.LogWarning(msg);
        }
        public static void LogWarning (this object obj, string format, params object[] args) {
            QniLogger.LogWarning(format, args);
        }


        public static void LogError (this object obj, object msg) {
            QniLogger.LogError(msg);
        }
        public static void LogError (this object obj, string format, params object[] args) {
            QniLogger.LogError(format, args);
        }

        public static void LogPrintBytes (byte[] bytes, string prefix = "", Action<string> printer = null) {
            QniLogger.LogPrintBytes(bytes, prefix, printer);
        }
    }
}