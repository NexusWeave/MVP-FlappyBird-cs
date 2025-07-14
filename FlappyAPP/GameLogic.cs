using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyAPP
{
    internal class GameLogic
    {
        private static char[,] InitializeBuffer(int y, int x)
        {
            return new char[y, x];
        }
        public static void DrawStartScreen(ref int bufferY, ref int bufferX)
        {
            char[,] buffer = InitializeBuffer(bufferY, bufferX);

            ConsoleConfig.ConsoleConfigs();

            while (true)
            {
                for (int y = 0; y < bufferY; y++)
                    for (int x = 0; x < bufferX; x++)
                        buffer[y, x] = ' ';

                ScreenText.MainScreenText(buffer);

                Sprite.LetsFlap(buffer);

                Console.SetCursorPosition(0, 0);
                DrawScreenFromBuffer(buffer, bufferY, bufferX);

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar) break;

                Thread.Sleep(100);
            }
        }


        public static void DrawGameArea(int bufferY, int bufferX, char obstacleChar,ref int velocity,ref int birdRow,ref bool isWingUp,ref int pipeX,ref int birdCol, ref int pipeGapTop, ref int pipeGapBottom,ref int score, ref int offset, ref int intervalWidth)
        {
            char[,] buffer = InitializeBuffer(bufferY, bufferX);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                    {
                        velocity = -2;
                        if (isWingUp) isWingUp = false; else isWingUp = true;
                    }
                    while (Console.KeyAvailable) Console.ReadKey(true);
                }

                BirdSpeed(ref velocity,ref birdRow);

                Score.ScoreLogic(ref pipeX,ref bufferX,ref birdCol,ref birdRow,ref pipeGapTop,ref pipeGapBottom,ref score);

                if (birdRow >= bufferY -1 ) Program.GameOver();

                Background.SetBuffer( ref buffer,ref offset, ref intervalWidth);

                Obstacle.DrawPipeInBuffer(buffer, pipeX, pipeGapTop, pipeGapBottom, obstacleChar);
                Sprite.DrawBirdInBuffer(buffer, birdCol, birdRow, velocity);

                Console.SetCursorPosition(37, 0);
                Console.WriteLine("Score: " + score, Console.ForegroundColor = ConsoleColor.Black);
                
                Console.SetCursorPosition(0, 1);
                DrawScreenFromBuffer(buffer, bufferY, bufferX);
                
                Thread.Sleep(50);
            }
        }

        static void DrawScreenFromBuffer(char[,] buffer, int bufferY,int bufferX) 
        {
            for (int y = 0; y < bufferY; y++)
            {
                for (int x = 0; x < bufferX; x++)
                {
                    if (Sprite.IsBirdPixel(buffer, y, x))
                        Console.ForegroundColor = ConsoleColor.Black;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(buffer[y, x]);
                }
                Console.WriteLine();
            }
        }

        static void BirdSpeed(ref int velocity, ref int birdRow) 
        {
            velocity += 1;

            if (velocity > 3) velocity = 3;
            birdRow += velocity;
        }

    }
}
