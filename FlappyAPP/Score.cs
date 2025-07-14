using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyAPP
{
    internal class Score
    {
      public static void ScoreLogic(ref int pipeX, ref int bufferWidth, ref int birdCol, ref int birdRow, ref int pipeGapTop, ref int pipeGapBottom, ref int score)
        {
            pipeX--;
            if (pipeX < -3)
                pipeX = bufferWidth;

            int birdHitboxStart = birdCol + 1;
            int birdHitboxEnd = birdCol + 1;
            if ((pipeX <= birdHitboxEnd && pipeX + 1 >= birdHitboxStart) &&
                (birdRow <= pipeGapTop || birdRow + 1 >= pipeGapBottom))
                Program.GameOver();

            if (birdHitboxEnd == pipeX + 2)
            {
                score += 1;
            }
        }
    }
}
