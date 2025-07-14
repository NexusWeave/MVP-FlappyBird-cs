using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyAPP
{
    internal class Sprite
    {
        public static string[] wingUp = {
        "  \\   /  ",
        "   \\0/   ",
        
    };

       public static string[] wingDown = {
              
        "   /0\\   ",
        "  /   \\  "
    };
       static bool isWingDown = true;

        public static string[] WingPosition(bool isWingUp)
        {
            return isWingUp ? wingUp : wingDown;
        }
        public static bool IsBirdPixel(char[,] buffer, int y, int x)
        {
            return buffer[y, x] == '/' || buffer[y, x] == '\\' || buffer[y, x] == '0';
        }

        public static void LetsFlap(char[,] buffer)
        {
            int posX = 10;
            int posY = 9;
            isWingDown = !isWingDown;

            string[] sprite = isWingDown ? wingDown : wingUp;

            for (int y = 0; y < sprite.Length; y++)
            {
                string line = sprite[y];
                for (int x = 0; x < line.Length; x++)
                {
                    int bufferY = posY + y;
                    int bufferX = posX + x;

                    if (bufferY >= 0 && bufferY < buffer.GetLength(0) &&
                        bufferX >= 0 && bufferX < buffer.GetLength(1))
                    {
                        buffer[bufferY, bufferX] = line[x];
                    }
                }
            }
        }

        public static void DrawBirdInBuffer(char[,] buffer, int x, int y, int velocity)
        {
            if (velocity < 0)isWingDown = !isWingDown;
            else isWingDown = true;
            string[] sprite = WingPosition(isWingDown);

            for (int i = 0; i < sprite.Length; i++)
            {
                int drawY = y + i;
                if (drawY >= 0 && drawY < buffer.GetLength(0))
                {
                    for (int j = 0; j < sprite[i].Length; j++)
                    {
                        int drawX = x + j;
                        if (drawX >= 0 && drawX < buffer.GetLength(1))
                            buffer[drawY, drawX] = sprite[i][j];
                    }
                }
            }
        }
    }
}
