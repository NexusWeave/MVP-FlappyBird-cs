using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyAPP
{
    internal class ScreenText
    {
        public static void MainScreenText(char[,] buffer)
        {
            string[] lines = new string[]
            {
        "Welcome to Flappy Bird!",
        "Press [SPACE] to flap your wings.",
        "Avoid the pipes and score points!",
        "Hold [SPACE] to start..."
            };

            int startY = 7;
            int startX = 23;

            for (int y = 0; y < lines.Length; y++)
            {
                string line = lines[y];
                for (int x = 0; x < line.Length; x++)
                {
                    int bufferY = startY + y;
                    int bufferX = startX + x;

                    if (bufferY >= 0 && bufferY < buffer.GetLength(0) &&
                        bufferX >= 0 && bufferX < buffer.GetLength(1))
                    {
                        buffer[bufferY, bufferX] = line[x];
                    }
                }
            }
        }


        public static void DrawGameOverScreen(int score)
        {
            Console.SetCursorPosition(25, 8);
            Console.WriteLine("Score: " + score, Console.ForegroundColor = ConsoleColor.Black);

            Console.SetCursorPosition(25, 10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("GAME OVER!");

            Console.SetCursorPosition(25, 11);
            Console.Write("Press Escape key to exit");

            Console.SetCursorPosition(25, 12);
            Console.WriteLine("Press any other Key to restart Game");
        }

    }
}
