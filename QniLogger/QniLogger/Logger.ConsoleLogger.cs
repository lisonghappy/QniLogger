using System;

namespace Qni {

    internal class ConsoleLogger : ILogger {
        public ConsoleLogger () {
        }


        public void Log (string msg, ELogColor logColor = ELogColor.None) {
            ConsoleLog(msg, logColor);
        }

        public void LogWarning (string msg) {
            ConsoleLog(msg, ELogColor.Yellow);
        }

        public void LogError (string msg) {
            ConsoleLog(msg, ELogColor.Red);
        }


        private void ConsoleLog (string msg, ELogColor color) {
            var _beforeColor = Console.ForegroundColor;
            var _newColor = _beforeColor;

            switch (color) {
                case ELogColor.Red:
                    _newColor = ConsoleColor.DarkRed;
                    break;
                case ELogColor.Green:
                    _newColor = ConsoleColor.Green;
                    break;
                case ELogColor.Blue:
                    _newColor = ConsoleColor.Blue;
                    break;
                case ELogColor.Cyan:
                    _newColor = ConsoleColor.Cyan;
                    break;
                case ELogColor.Magenta:
                    _newColor = ConsoleColor.Magenta;
                    break;
                case ELogColor.Yellow:
                    _newColor = ConsoleColor.DarkYellow;
                    break;
                case ELogColor.White:
                    _newColor = ConsoleColor.White;
                    break;
                case ELogColor.Gray:
                    _newColor = ConsoleColor.Gray;
                    break;
                case ELogColor.Black:
                    _newColor = ConsoleColor.Black;
                    break;
                case ELogColor.None:
                default:
                    break;
            }


            Console.ForegroundColor = _newColor;
            Console.WriteLine(msg);
            Console.ForegroundColor = _beforeColor;
        }
    }
}

