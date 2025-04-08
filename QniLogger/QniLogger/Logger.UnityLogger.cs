using System;
using System.Reflection;

namespace Qni
{
    internal class UnityLogger : ILogger {
        private static readonly Type type = Type.GetType("UnityEngine.Debug, UnityEngine");
        private static readonly MethodInfo logMethod = type.GetMethod("Log", new Type[] { typeof(object) });
        private static readonly MethodInfo logWarningMethod = type.GetMethod("LogWarning", new Type[] { typeof(object) });
        private static readonly MethodInfo logErrorMethod = type.GetMethod("LogError", new Type[] { typeof(object) });

        public void Log (string msg, ELogColor logColor = ELogColor.None) {
            msg = MsgColorful(msg, logColor);
            logMethod?.Invoke(null, new object[] { msg });
        }

        public void LogWarning (string msg) {
            msg = MsgColorful(msg, ELogColor.Yellow);
            logWarningMethod?.Invoke(null, new object[] { msg });
        }

        public void LogError (string msg) {
            msg = MsgColorful(msg, ELogColor.Red);
            logErrorMethod?.Invoke(null, new object[] { msg });
        }

        private string MsgColorful (string msg, ELogColor logColor = ELogColor.None) {
            var _colorVal = "";
            switch (logColor) {
                case ELogColor.Red:
                    _colorVal = "FF0000FF";
                    break;
                case ELogColor.Green:
                    _colorVal = "00FF00FF";
                    break;
                case ELogColor.Blue:
                    _colorVal = "0000FFFF";
                    break;
                case ELogColor.Cyan:
                    _colorVal = "00FFFFFF";
                    break;
                case ELogColor.Magenta:
                    _colorVal = "FF00FFFF";
                    break;
                case ELogColor.Yellow:
                    _colorVal = "CC9A06FF";
                    break;
                case ELogColor.White:
                    _colorVal = "FFFFFFFF";
                    break;
                case ELogColor.Gray:
                    _colorVal = "777777FF";
                    break;
                case ELogColor.Black:
                    _colorVal = "000000FF";
                    break;
                case ELogColor.None:
                default:
                    break;
            }

            if (string.IsNullOrEmpty(_colorVal)) {
                return msg;
            }
            else {
                return string.Format("<color=#{0}>{1}</color>", _colorVal, msg);
            }
        }
    }
}

