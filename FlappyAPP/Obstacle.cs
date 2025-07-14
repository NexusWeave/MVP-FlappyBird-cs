using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FlappyAPP
{
    internal class Obstacle
    {

        public static void DrawPipeInBuffer(char[,] buffer, int pipeX, int gapTop, int gapBottom, char obstacleChar)
        {
            SetObstacleHeight(ref gapTop, ref gapBottom, ref pipeX);
            for (int y = 1; y < buffer.GetLength(0) - 1; y++)
            {
                if (y < gapTop || y > gapBottom)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        int px = pipeX + x;
                        if (px >= 0 && px < buffer.GetLength(1))
                            buffer[y, px] = obstacleChar;
                    }
                }
            }
        }

        public static void DrawGround(int bufferY, int bufferX, char obstacle, int offset, int gapX)
        {
            int n = bufferX - 1;

            ConsoleColor color = offset < gapX ? ConsoleColor.Green : ConsoleColor.Yellow;

            for (int i = n; i >= 0; i--)
            {
                Console.ForegroundColor = color;
                if (i % gapX == 0)
                {
                    color = color == ConsoleColor.Yellow ? ConsoleColor.Green : ConsoleColor.Yellow;

                }
                Console.Write(obstacle);
            }
        }
        public static void MakeGroundAnimation(ref int offset, ref int intervalwidth) 
        {
              offset = (offset + intervalwidth * 2 - 1) % (intervalwidth * 2);
        }

        static void SetObstacleHeight(ref int pipeGapTop, ref int pipeGapBottom, ref int pipeX)
        {
            bool isPipeHeightSet = false;

            var random = new Random();

            int rand = random.Next(3, 10);

            if (pipeX > 71 && !isPipeHeightSet)
            {
                isPipeHeightSet = true;
                pipeGapTop = rand;

                pipeGapBottom = pipeGapTop + 8;
            }
            else if (pipeX < 1 && isPipeHeightSet)
            {
                isPipeHeightSet = false;
                pipeGapTop = 4;
                pipeGapBottom = 14;
            }
        }


    }
}