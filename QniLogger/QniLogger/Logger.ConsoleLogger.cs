using System;
using System.Drawing;

namespace Qni {
    public class ConsoleLogger : ILogger {
        public ConsoleLogger () {
        }


        public void Log (string msg, ELogColor logColor = ELogColor.None) {
            WriteConsoleLog(msg, logColor);
        }

        public void LogWarning (string msg) {
            WriteConsoleLog(msg, ELogColor.Yellow);
        }

        public void LogError (string msg) {
            WriteConsoleLog(msg, ELogColor.Red);
        }


        private void WriteConsoleLog (string msg, ELogColor color) {
                var _color = Console.ForegroundColor;
            switch (color) {
                case ELogColor.Red:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(msg);
                    Console.ForegroundColor = _color;
                    break;
                case ELogColor.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(msg);
                    Console.ForegroundColor = _color;
                    break;
                case ELogColor.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(msg);
                    Console.ForegroundColor = _color;
                    break;
                case ELogColor.Cyan:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(msg);
                    Console.ForegroundColor = _color;
                    break;
                case ELogColor.Magenta:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(msg);
                    Console.ForegroundColor = _color;
                    break;
                case ELogColor.Yellow:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(msg);
                    Console.ForegroundColor = _color;
                    break;
                case ELogColor.White:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(msg);
                    Console.ForegroundColor = _color;
                    break;
                case ELogColor.Gray:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(msg);
                    Console.ForegroundColor = _color;
                    break;
                case ELogColor.Black:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(msg);
                    Console.ForegroundColor = _color;
                    break;
                case ELogColor.None:
                default:
                    Console.WriteLine(msg);
                    break;
            }
        }
    }
}

