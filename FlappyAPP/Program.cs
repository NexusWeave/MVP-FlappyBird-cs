namespace FlappyAPP;
class Program
{
    static string[] wingUp = {
        "  \\   /  ",
        "   \\0/   ",
        "         "
    };

    static string[] wingDown = {
        "         ",
        "   /0\\   ",
        "  /   \\  "
    };

    static int birdRow = 6;
    static int birdCol = 10;
    static int velocity = 0;
    static bool isWingUp = true;
    static int pipeX;
    static readonly int pipeGapTop = 4;
    static readonly int pipeGapBottom = 14;

    static void Main(string[] args)
    {
        ConsoleConfig();
        Console.Clear();

        Console.WriteLine("Welcome to FlappyAPP!");
        Console.WriteLine("Press any key to start...");
        Console.ReadKey(true);

        int row = 20;
        int column = 73;
        pipeX = column - 1;

        DrawGameArea(row, column, '█');
    }

    static void DrawGameArea(int row, int column, char obstacleChar)
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
                    isWingUp = true;
                }
                while (Console.KeyAvailable) Console.ReadKey(true);
            }
            
            velocity += 1;
            if (velocity > 1) velocity = 1;
            birdRow += velocity;
            if (birdRow < 1) birdRow = 1;
            if (birdRow > row - 4) birdRow = row - 4;

            if (velocity > 0) isWingUp = false;
            
            pipeX--;
            if (pipeX < -3)
                pipeX = bufferWidth;
            
            int birdHitboxStart = birdCol + 1; 
            int birdHitboxEnd = birdCol + 1;

            if ((pipeX <= birdHitboxEnd && pipeX + 2 >= birdHitboxStart) &&
                (birdRow <= pipeGapTop || birdRow + 2 >= pipeGapBottom))
            {
                GameOver();
                return;
            }
            if (birdRow + 2 >= row - 1)
            {
                GameOver();
                return;
            }
            
            for (int y = 0; y < bufferHeight; y++)
                for (int x = 0; x < bufferWidth; x++)
                    buffer[y, x] = ' ';
            
            for (int x = 0; x < bufferWidth; x++)
            {
                buffer[0, x] = obstacleChar;
                buffer[bufferHeight - 1, x] = obstacleChar;
            }
            
            DrawPipeInBuffer(buffer, pipeX, pipeGapTop, pipeGapBottom, obstacleChar);
            DrawBirdInBuffer(buffer, birdCol, birdRow);
            
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < bufferHeight; y++)
            {
                for (int x = 0; x < bufferWidth; x++)
                {
                    if (IsBirdPixel(buffer, y, x))
                        Console.ForegroundColor = ConsoleColor.Black;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(buffer[y, x]);
                }
                Console.WriteLine();
            }

            Thread.Sleep(100);
        }
    }

    static bool IsBirdPixel(char[,] buffer, int y, int x)
    {
        return buffer[y, x] == '/' || buffer[y, x] == '\\' || buffer[y, x] == '0';
    }

    static void DrawBirdInBuffer(char[,] buffer, int x, int y)
    {
        string[] sprite = isWingUp ? wingUp : wingDown;

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

    static void DrawPipeInBuffer(char[,] buffer, int pipeX, int gapTop, int gapBottom, char obstacleChar)
    {
        for (int y = 1; y < buffer.GetLength(0) - 1; y++)
        {
            if (y < gapTop || y > gapBottom)
            {
                for (int x = 0; x < 3; x++)
                {
                    int px = pipeX + x;
                    if (px >= 0 && px < buffer.GetLength(1))
                        buffer[y, px] = obstacleChar;
                }
            }
        }
    }

    static void GameOver()
    {
        Console.SetCursorPosition(20, 10);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("GAME OVER!");
        Console.SetCursorPosition(20, 11);
        Console.WriteLine("Press any key to exit");
        Console.ReadKey(true);
    }

    static void ConsoleConfig()
    {
        Console.Title = "FlappyAPP";
        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
    }
}
