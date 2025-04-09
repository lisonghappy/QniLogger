using System;

namespace Qni {

    public static class LoggerExtensionMethonds {

        public static void Log (this object obj, object msg) {
            QniLogger.Log(msg);
        }
        public static void LogFormat (this object obj, string format, params object[] args) {
            QniLogger.LogFormat(format, args);
        }


        public static void LogColor (this object obj, ELogColor color, object msg) {
            QniLogger.LogColor(color, msg);
        }
        public static void LogColorFormat (this object obj, ELogColor color, string format, params object[] args) {
            QniLogger.LogColorFormat(color, format, args);
        }


        public static void LogTrace (this object obj, object msg) {
            QniLogger.LogTrace(msg);
        }
        public static void LogTraceFormat (this object obj, string format, params object[] args) {
            QniLogger.LogTraceFormat(format, args);
        }


        public static void LogWarning (this object obj, object msg) {
            QniLogger.LogWarning(msg);
        }
        public static void LogWarningFormat (this object obj, string format, params object[] args) {
            QniLogger.LogWarningFormat(format, args);
        }


        public static void LogError (this object obj, object msg) {
            QniLogger.LogError(msg);
        }
        public static void LogErrorFormat (this object obj, string format, params object[] args) {
            QniLogger.LogErrorFormat(format, args);
        }

        public static void LogPrintBytes (byte[] bytes, string prefix = "", Action<string> printer = null) {
            QniLogger.LogPrintBytes(bytes, prefix, printer);
        }
    }
}