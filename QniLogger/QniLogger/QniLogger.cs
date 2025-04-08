using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Qni {

    public static class QniLogger {
        private const string QNI_LOGGER_LOCK = "Qni.Logger.Lock";


        private static bool isInit = false;

        private static ILogger logger = null;
        private static LogConfig logConfig = null;
        private static LogWriter logWriter = null;


        public static void Init (ELogChannel channel, LogConfig config = null) {
            if (isInit) {
                return;
            }
            isInit = true;


            if (channel == ELogChannel.Console) {
                logger = new ConsoleLogger();
            }
            else if (channel == ELogChannel.Unity) {
                logger = new UnityLogger();
            }

            if (config == null) {
                logConfig = new LogConfig();
            }
            else {
                logConfig = config;
            }

            if (logConfig.enableCache) {
                logWriter = new LogWriter(channel, logConfig);
            }

        }

        private static bool Enable {
            get {
                return logConfig.enable;
            }
        }

        #region --------------------- Log ---------------------

        public static void Log (object msg) {
            if (!Enable) {
                return;
            }
            var _msg = LogPackaging(msg.ToString(), logConfig.enableTrace);
            lock (QNI_LOGGER_LOCK) {
                logger.Log(_msg);
                WriteLogMsgToLocal("Log", _msg);
            }
        }

        public static void Log (string msg, params object[] args) {
            if (!Enable) {
                return;
            }
            var _msg = LogPackaging(string.Format(msg, args), logConfig.enableTrace);
            lock (QNI_LOGGER_LOCK) {
                logger.Log(_msg);
                WriteLogMsgToLocal("Log", _msg);
            }
        }
        #endregion


        #region --------------------- LogColor ---------------------
        public static void LogColor (ELogColor color, object msg) {
            if (!Enable) {
                return;
            }
            var _msg = LogPackaging(msg.ToString(), logConfig.enableTrace);
            lock (QNI_LOGGER_LOCK) {
                logger.Log(_msg, color);
                WriteLogMsgToLocal("Log", _msg);
            }
        }

        public static void LogColor (ELogColor color, string msg, params object[] args) {
            if (!Enable) {
                return;
            }
            var _msg = LogPackaging(string.Format(msg, args), logConfig.enableTrace);
            lock (QNI_LOGGER_LOCK) {
                logger.Log(_msg, color);
                WriteLogMsgToLocal("Log", _msg);
            }
        }

        #endregion


        #region --------------------- LogTrace ---------------------

        /// <summary>
        /// print log with trace info.
        /// </summary>
        /// <param name="msg"></param>
        public static void LogTrace (object msg) {
            if (!Enable) {
                return;
            }
            var _msg = LogPackaging(msg.ToString(), true);
            lock (QNI_LOGGER_LOCK) {
                logger.Log(_msg, ELogColor.Magenta);
                WriteLogMsgToLocal("Trace", _msg);
            }
        }

        /// <summary>
        /// print log with trace info.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        public static void LogTrace (string msg, params object[] args) {
            if (!Enable) {
                return;
            }
            var _msg = LogPackaging(string.Format(msg, args), true);
            lock (QNI_LOGGER_LOCK) {
                logger.Log(_msg, ELogColor.Magenta);
                WriteLogMsgToLocal("Trace", _msg);
            }
        }

        #endregion


        #region --------------------- LogWarning ---------------------

        public static void LogWarning (object msg) {
            if (!Enable) {
                return;
            }
            var _msg = LogPackaging(msg.ToString(), logConfig.enableTrace);
            lock (QNI_LOGGER_LOCK) {
                logger.LogWarning(_msg);
                WriteLogMsgToLocal("Warning", _msg);

            }
        }

        public static void LogWarning (string msg, params object[] args) {
            if (!Enable) {
                return;
            }
            var _msg = LogPackaging(string.Format(msg, args), logConfig.enableTrace);
            lock (QNI_LOGGER_LOCK) {
                logger.LogWarning(_msg);
                WriteLogMsgToLocal("Warning", _msg);
            }
        }
        #endregion


        #region --------------------- LogError ---------------------
        public static void LogError (object msg) {
            if (!Enable) {
                return;
            }
            var _msg = LogPackaging(msg.ToString(), true);
            lock (QNI_LOGGER_LOCK) {
                logger.LogError(_msg);
                WriteLogMsgToLocal("Error", _msg);

            }
        }
        public static void LogError (string msg, params object[] args) {
            if (!Enable) {
                return;
            }
            var _msg = LogPackaging(string.Format(msg, args), true);
            lock (QNI_LOGGER_LOCK) {
                logger.LogError(_msg);
                WriteLogMsgToLocal("Error", _msg);
            }
        }
        #endregion


        public static void LogPrintBytes (byte[] bytes, string prefix = "", Action<string> printer = null) {
            if (string.IsNullOrEmpty(prefix)) {
                prefix = "Byte Datas";
            }
            StringBuilder stringBuilder = new StringBuilder(prefix + "->\n");
            for (int i = 0; i < bytes.Length; i++) {
                if (i % 10 == 0) {
                    stringBuilder.AppendLine(bytes[i].ToString());
                }
                stringBuilder.Append(bytes[i] + " ");
            }
            if (printer != null) {
                printer(stringBuilder.ToString());
            }
            else {
                Log(stringBuilder.ToString());
            }
        }













        private static void WriteLogMsgToLocal (string label, string msg) {
            if (logConfig.enableCache) {
                logWriter.Write(string.Format("[{0}] {1}", label, msg));
            }
        }


        private static string LogPackaging (string msg, bool isTrace = false) {
            StringBuilder sb = new StringBuilder(logConfig.logPrefix, 100);
            if (logConfig.enableTime) {
                TimeZoneInfo currentTimeZone = TimeZoneInfo.Local;
                if (logConfig.enableUTCTime) {
                    sb.AppendFormat(" {0}(UTC,{1},{2})", DateTime.UtcNow.ToString("yyyy.MM.dd.HH:mm:ss.fff"), currentTimeZone.BaseUtcOffset, currentTimeZone.Id);
                }
                else {
                    sb.AppendFormat(" {0}({1})", DateTime.Now.ToString("yyyy.MM.dd.HH:mm:ss.fff"), currentTimeZone.Id);
                }
            }

            if (logConfig.enableThreadID) {
                sb.AppendFormat(" {0}", GetThreadID());
            }

            sb.AppendFormat(" {0} {1}", logConfig.logSeparator, msg);

            if (isTrace) {
                sb.AppendFormat("\nStackTrace:{0}", GetLogTraceInfo());
            }

            sb.AppendLine();
            return sb.ToString();
        }

        private static string GetThreadID () {
            return string.Format(" ThreadID:{0}", Thread.CurrentThread.ManagedThreadId);
        }

        private static string GetLogTraceInfo () {
            StackTrace st = new StackTrace(3, true);//skip 3 frames
            string traceInfo = "";
            for (int i = 0; i < st.FrameCount; i++) {
                StackFrame sf = st.GetFrame(i);
                traceInfo += string.Format("\n{0}::{1} Line:{2}", sf.GetFileName(), sf.GetMethod(), sf.GetFileLineNumber());
            }
            return traceInfo;
        }
    }
}

