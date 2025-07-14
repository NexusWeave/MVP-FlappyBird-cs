using System;
using System.Collections.Generic;
using System.Linq;
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

        public static void DrawGround(ref int bufferWidth, ref int bufferHeight, ref char[,] buffer, ref int offset, ref int intervalWidth)
        {
            char obstacleChar = '#';
           ConsoleColor color1 = ConsoleColor.DarkGreen;
            ConsoleColor color2 = ConsoleColor.Green;

            Console.SetCursorPosition(0, bufferHeight - 1);
            var color = offset < intervalWidth ? color1 : color2;
            Console.ForegroundColor = color;
            Console.Write(new string(obstacleChar, offset % intervalWidth));
            var coloumnsLeft = bufferWidth - Console.CursorLeft - 1;
            while (coloumnsLeft > 0)
            {
                color = color == color1 ? color2 : color1;
                Console.ForegroundColor = color;
                Console.Write(new string(obstacleChar, Math.Min(intervalWidth, coloumnsLeft )));
                coloumnsLeft -= intervalWidth;
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