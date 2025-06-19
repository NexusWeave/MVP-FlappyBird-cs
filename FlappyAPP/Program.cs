using System.Threading.Tasks.Dataflow;

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

    static int row = 20;
    static int column = 73;
    static int score = 0;
    static int birdRow = 6;
    static int birdCol = 10;
    static int velocity = 0;
    static bool isWingUp = true;
    static int pipeX;
    static int pipeGapTop = 4;
    static int pipeGapBottom = 14;

    static void Main()
    {   Background.MakeBackground();
        Console.Clear();
        DrawGameStartScreen();
        Console.ReadKey(true);

        pipeX = column - 1;

        DrawGameArea(row, column, '█');
    }

    static void DrawGameArea(int bufferHeight, int bufferWidth, char obstacleChar)
    {
        char[,] buffer = new char[bufferHeight, bufferWidth];

        while (true)
        {
            //  ConsoleUtils
            ConsoleUtilsAvailable();

            ResetVelocity();
            
            pipeX--;

            if (pipeX < -3)
                pipeX = bufferWidth;

            birdRow += velocity;

            if (birdRow < 1) birdRow = 1;

            if (birdRow > row - 4) birdRow = row - 4;

            if (velocity > 0) isWingUp = false;

            CollisionCheck(birdCol + 1, birdCol + 1);
            ScoreIncrement(pipeX);

            for (int y = 0; y < bufferHeight; y++)
                for (int x = 0; x < bufferWidth; x++)
                    buffer[y, x] = ' ';
            
            for (int x = 0; x < bufferWidth; x++)
            {
                buffer[0, x] = obstacleChar;
                buffer[bufferHeight - 1, x] = obstacleChar;
            }
            
            Obstacle.DrawPipeInBuffer(buffer, pipeX, pipeGapTop, pipeGapBottom, obstacleChar);
            DrawBirdInBuffer(buffer, birdCol, birdRow);

            printScore();
            

            DrawSprite(bufferHeight, bufferWidth, buffer);
            Thread.Sleep(100);
        }
    }
    static void DrawSprite(int bufferHeight, int bufferWidth, char[,] buffer)
    {
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
    }
    static void ResetVelocity()
        {
            velocity++;
            if (velocity > 1) velocity = 1;
        }
    static void printScore()
    {
        Console.SetCursorPosition(37, 0);
        Console.WriteLine("Score: " + score, Console.ForegroundColor = ConsoleColor.Black);
        Console.SetCursorPosition(0, 1);

    }
    static void ScoreIncrement(int hitboxEnd)
    {
        if (hitboxEnd == pipeX + 3)
        {
            score += 1;
            if (pipeGapTop < 6)
            {
                pipeGapTop += 1;
                pipeGapBottom -= 1;
            }
        }
    }

    static void ConsoleUtilsAvailable()
    {
        if (Console.KeyAvailable)
        {
            if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
            {
                velocity = -2;

                if (isWingUp) isWingUp = false;
                else isWingUp = true;
            }
            while (Console.KeyAvailable) Console.ReadKey(true);
        }
    }

    static void DrawGameStartScreen()
    {
        Console.Clear();
        Console.WriteLine("Welcome to FlappyAPP!");
        Console.WriteLine("Press any key to start...");
        Console.ReadKey(true);

        pipeX = column - 1;

        DrawGameArea(row, column, '█');
    }

    static void Vertical_Movement(int bufferHeight)
    {
        if (birdRow < 1) birdRow = 1;

    }
    static void Horizontal_Movement(int bufferWidth)
    {

    }
    static void Movement()
    {

    }
    static void CollisionCheck(int hitboxStart, int hitboxEnd)
    {

        if (pipeX <= hitboxEnd && pipeX + 2 >= hitboxStart &&
            (birdRow <= pipeGapTop || birdRow + 2 >= pipeGapBottom))
            GameOver();

        if (birdRow + 1 >= row - 3) GameOver();
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

    static void GameOver()
    {
        ScreenText.DrawGameOverScreen(score);

        if (Console.ReadKey(true).Key == ConsoleKey.Escape) return;
        else 
        {
            ResetGame();
        }
    }
    
    static void ResetGame()
    {
        score = 0;
        birdRow = 6;
        birdCol = 10;
        velocity = 0;
        isWingUp = true;
        pipeX = 72;
        Main();
    }

    
}
