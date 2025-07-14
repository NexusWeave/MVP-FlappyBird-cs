using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyAPP
{
    internal class Background
    {
       public static void SetBuffer(ref int bufferHeight, ref int bufferWidth, ref char[,] buffer, ref char obstacleChar, ref int offset, ref int intervalWidth)
        {
            for (int y = 0; y < bufferHeight; y++)
                for (int x = 0; x < bufferWidth; x++)
                    buffer[y, x] = ' ';
            Obstacle.DrawGround(ref bufferWidth, ref bufferHeight, ref buffer, ref offset, ref intervalWidth );
            Obstacle.MakeGroundAnimation(ref offset, ref intervalWidth);
        }
    }
}
