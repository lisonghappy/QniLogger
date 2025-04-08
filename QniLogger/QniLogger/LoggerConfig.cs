using System;
namespace Qni {
	public class LogConfig
	{
		/// <summary>
		/// enable logger
		/// </summary>
		public bool enable = true;

		/// <summary>
		/// enable logger to write date.
		/// </summary>
		public bool enableTime = true;
        /// <summary>
        /// enable logger to write UTC date.
        /// </summary>
        public bool enableUTCTime = false;
        /// <summary>
        /// enable logger to Write tread id.
        /// </summary>
        public bool enableThreadID = true;
        /// <summary>
        /// enable logger to Write trace info.
        /// </summary>
        public bool enableTrace = true;
        /// <summary>
        /// enable logger to Write log info cache to local.
        /// </summary>
		public bool enableCache = true;
        /// <summary>
        /// enable logger to override Write log info cache to local.
        /// </summary>
		public bool enableCacheCover = true;


		public string logPrefix = "#";
		public string logSeparator = ">";
		public string cacheFileDir = "";
		public string cacheFileName = "Log.txt";


		public static string DefalutCacheFileDir(ELogChannel channel) {
            if (channel == ELogChannel.Console) {
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            }
            else if (channel == ELogChannel.Unity) {
                Type type = Type.GetType("UnityEngine.Application, UnityEngine");
                return System.IO.Path.Combine(type.GetProperty("persistentDataPath").GetValue(null).ToString(), "Logs");
            }

            return "";
        }
    }
}

