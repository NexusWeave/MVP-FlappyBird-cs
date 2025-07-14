using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyAPP
{
    public class Background
    {
       public static void SetBuffer(ref char[,] buffer, ref int offset, ref int intervalWidth)
        {
            int bufferY = buffer.GetLength(0);
            int bufferX = buffer.GetLength(1);

            for (int i = 0; i < bufferY; i++)
                for (int j = 0; j < bufferX; j++)
                    buffer[i, j] = ' ';

            Obstacle.DrawGround(ref buffer, ref offset, ref intervalWidth );
            Obstacle.MakeGroundAnimation(ref offset, ref intervalWidth);
        }
    }
}
