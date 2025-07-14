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
        public static void DrawStartScreen(ref int row, ref int column)
        {
            int bufferHeight = row;
            int bufferWidth = column;
            char[,] buffer = new char[bufferHeight, bufferWidth];

            ConsoleConfig.ConsoleConfigs();
            Console.CursorVisible = false;

            while (true)
            {
                for (int y = 0; y < bufferHeight; y++)
                    for (int x = 0; x < bufferWidth; x++)
                        buffer[y, x] = ' ';

                ScreenText.MainScreenText(buffer);
                Sprite.LetsFlap(buffer);

               
                Console.SetCursorPosition(0, 0);
                DrawScreenFromBuffer(ref bufferHeight, ref bufferWidth, ref buffer);

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                    break;

                Thread.Sleep(100);
            }
        }


        public static void DrawGameArea(ref int row,ref int column,ref char obstacleChar,ref int velocity,ref int birdRow,ref bool isWingUp,ref int pipeX,ref int birdCol, ref int pipeGapTop, ref int pipeGapBottom,ref int score, ref int offset, ref int intervalWidth)
        {
            int bufferHeight = row;
            int bufferWidth = column;
            char[,] buffer = new char[bufferHeight, bufferWidth];

            while (true)
            {

                if (Console.KeyAvailable)
                {
                    if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                    {
                        velocity = -2;

                        if (isWingUp) isWingUp = false;
                        else isWingUp = true;
                    }
                    while (Console.KeyAvailable) Console.ReadKey(true);
                }

                BirdSpeed(ref velocity,ref birdRow,ref row,ref isWingUp);

                Score.ScoreLogic(ref pipeX,ref bufferWidth,ref birdCol,ref birdRow,ref pipeGapTop,ref pipeGapBottom,ref score);


                if (birdRow >= row -1 ) Program.GameOver();

                Background.SetBuffer(ref bufferHeight, ref bufferWidth, ref buffer, ref obstacleChar, ref offset, ref intervalWidth);

                Obstacle.DrawPipeInBuffer(buffer, pipeX, pipeGapTop, pipeGapBottom, obstacleChar);
                Sprite.DrawBirdInBuffer(buffer, birdCol, birdRow, velocity);

                Console.SetCursorPosition(37, 0);
                Console.WriteLine("Score: " + score, Console.ForegroundColor = ConsoleColor.Black);
                
                Console.SetCursorPosition(0, 1);
                DrawScreenFromBuffer(ref bufferHeight,ref bufferWidth,ref buffer);
                
                Thread.Sleep(50);
            }
        }

        static void DrawScreenFromBuffer(ref int bufferHeight,ref int bufferWidth,ref char[,] buffer) 
        {
            for (int y = 0; y < bufferHeight; y++)
            {
                for (int x = 0; x < bufferWidth; x++)
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

        static void BirdSpeed(ref int velocity, ref int birdRow, ref int row,ref  bool isWingUp) 
        {
            velocity += 1;

            if (velocity > 3) velocity = 3;
            birdRow += velocity;
        }

    }
}
