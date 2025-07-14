
namespace FlappyAPP
{
    internal class Obstacle
    {

        public static void DrawPipeInBuffer(char[,] buffer, int pipeX, int gapTop, int gapBottom, char obstacleChar, ref bool obstacleBlock)
        {
            SetObstacleHeight(gapTop, ref gapBottom, ref pipeX, ref obstacleBlock);

            int bufferY = buffer.GetLength(0);
            int bufferX = buffer.GetLength(1);

            for (int y = 0; y < bufferY; y++)
            {
                if (y < gapTop || y > gapBottom)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        int px = pipeX + x;
                        if (px >= 0 && px < bufferX)
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

        static void SetObstacleHeight(int pipeGapTop, ref int pipeGapBottom, ref int pipeX, ref bool obstacleBlock)
        {

            int r = new Random().Next(3, 10);


            if (pipeX > 71 && !obstacleBlock)
            {
                pipeGapBottom = r + 8;
            }
            else if (pipeX < 1 && obstacleBlock)
            {
                // Reset the pipe gap to default values
                pipeGapTop = 4;
                pipeGapBottom = 14;
            }
            obstacleBlock = !obstacleBlock;
        }
    }
}