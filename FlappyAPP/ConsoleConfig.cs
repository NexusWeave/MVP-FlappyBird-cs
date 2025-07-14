using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyAPP
{
    internal class ConsoleConfig
    {
        public static void ConsoleConfigs()
        {
            Console.Title = "FlappyAPP";
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }
    }
}
