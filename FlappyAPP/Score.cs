using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyAPP
{
    internal class Score
    {
        public static void ScoreLogic(ref int pipeX, int bufferX, int birdCol, int birdRow, int pipeGapTop, int pipeGapBottom, ref int score)
        {
            pipeX--;
            if (pipeX < -3)
                pipeX = bufferX;

            int birdHitboxEnd = birdCol + 1;
            int birdHitboxStart = birdCol + 1;

            if (pipeX <= birdHitboxEnd && pipeX + 1 >= birdHitboxStart &&
                (birdRow <= pipeGapTop || birdRow + 1 >= pipeGapBottom))
                Program.GameOver();

            if (birdHitboxEnd == pipeX + 2)
            {
                score += 1;
            }
        }
        public static void DrawScore(int score)
        {
            Console.SetCursorPosition(37, 0);
            Console.WriteLine("Score: " + score, Console.ForegroundColor = ConsoleColor.Black);
            Console.SetCursorPosition(0, 1);
        }
    }
}
