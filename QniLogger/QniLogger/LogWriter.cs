using System;
using System.IO;

namespace Qni {
    public class LogWriter {

        private StreamWriter fileWriter = null;
        private string cacheDir = "";
        private string cacheFileName = "log.txt";


        public LogWriter (ELogChannel channel, LogConfig cfg) {
            if (string.IsNullOrEmpty(cfg.cacheFileDir)) {
                cacheDir = LogConfig.DefalutCacheFileDir(channel);
            }
            else {
                cacheDir = cfg.cacheFileDir;
            }

            if (!string.IsNullOrEmpty(cfg.cacheFileName)) {
                cacheFileName = cfg.cacheFileName;
            }

            if (cfg.enableCacheCover) {
                string filPath = Path.Combine(cacheDir, cacheFileName);
                try {
                    if (Directory.Exists(cacheDir)) {
                        if (File.Exists(filPath)) {
                            File.Delete(filPath);
                        }
                    }
                    else {
                        Directory.CreateDirectory(cacheDir);
                    }
                    fileWriter = File.AppendText(filPath);
                    fileWriter.AutoFlush = true;
                }
                catch (Exception) {
                    fileWriter = null;
                }
            }
            else {
                string prefix = DateTime.Now.ToString("yyyyMMdd@HH-mm-ss-fff");
                string path = Path.Combine(cacheDir, prefix, cacheFileName);
                try {
                    if (!Directory.Exists(cacheDir)) {
                        Directory.CreateDirectory(cacheDir);
                    }
                    fileWriter = File.AppendText(path);
                    fileWriter.AutoFlush = true;
                }
                catch (Exception) {
                    fileWriter = null;
                }
            }

        }

        public void Write (string msg) {
            if (fileWriter != null) {
                try {
                    fileWriter.WriteLine(msg);
                }
                catch (Exception) {
                    fileWriter = null;
                    return;
                }
            }
        }





    }
}

