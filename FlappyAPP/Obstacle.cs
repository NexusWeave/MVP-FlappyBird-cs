namespace FlappyAPP;

public class Obstacle
{
    public static void DrawPipeInBuffer(char[,] buffer, int pipeX, int gapTop, int gapBottom, char obstacleChar)
    {
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
}