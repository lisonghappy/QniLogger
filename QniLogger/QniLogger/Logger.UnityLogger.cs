using System;

namespace Qni {
    public class UnityLogger : ILogger {
        private readonly Type type = Type.GetType("UnityEngine.Debug, UnityEngine");

        public void Log (string msg, ELogColor logColor = ELogColor.None) {
            msg = ColorfulMsg(msg, logColor);
            type.GetMethod("Log", new Type[] { typeof(object) }).Invoke(null, new object[] { msg });
        }

        public void LogWarning (string msg) {
            type.GetMethod("LogWarning", new Type[] { typeof(object) }).Invoke(null, new object[] { msg });

        }

        public void LogError (string msg) {
            type.GetMethod("LogError", new Type[] { typeof(object) }).Invoke(null, new object[] { msg });
        }

        private string ColorfulMsg (string msg, ELogColor logColor = ELogColor.None) {
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
                    _colorVal = "FFFF00FF";
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
                return string.Format("<color={0}{1}</color>>", _colorVal, msg);
            }
        }
    }
}

