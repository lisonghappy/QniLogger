
namespace Qni {
    internal interface ILogger {
        void Log (string msg, ELogColor logColor = ELogColor.None);
        void LogWarning (string msg);
        void LogError (string msg);
    }
}