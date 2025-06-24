namespace FlappyAPP;

public class GameLogic
{
    static string[] wingUp = {
        "  \\   /  ",
        "   \\0/   ",
    };

    static string[] wingDown = {
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

    //Sprite sprite = new Sprite();

    static public void Start()
    {
        char[,] buffer = new char[row, column];
        Screen.StartScreen(buffer, '█');

        UpdateFrame(buffer, '█');
    }

    static public void UpdateFrame(char[,] buffer, char obstacleChar)
    {
        Score score = new Score();

        while (true)
        {
            //  ConsoleUtils
            ConsoleUtilsAvailable();

            //  Bird movement Logic
            velocity = Sprite.ResetVelocity(velocity);
            birdRow = Sprite.VerticalMovement(birdRow, velocity);

            CollisionCheck(birdCol + 1, birdCol + 1, pipeX + 2);

            Score.Increment(birdCol + 1, pipeX + 3, score, pipeGapTop, pipeGapBottom);

            buffer = Screen.ResetScreen(buffer, ' ', obstacleChar);

            //  Obstacle Draw / movement Logic
            HorizontalMovement(buffer.GetLength(1));
            Obstacle.DrawPipeInBuffer(buffer, pipeX, pipeGapTop, pipeGapBottom, obstacleChar);
            DrawBirdInBuffer(buffer, birdCol, birdRow);

            // Score Logic
            Score.PrintScore(score, buffer.GetLength(1) / 2);

            Sprite.DrawFrame(buffer);
            Thread.Sleep(100);
        }
    }

    static public void CollisionCheck(int hitboxStart, int hitboxEnd, int ObstacleX)
    {
        if (birdRow > row - 4) birdRow = row - 4;
        if (velocity > 0) isWingUp = false;

        if (ObstacleX <= hitboxEnd && ObstacleX + 2 >= hitboxStart &&
            (birdRow <= pipeGapTop || birdRow + 2 >= pipeGapBottom))
            GameOver();

        if (birdRow + 1 >= row - 3) GameOver();
    }

    // Helper method: Reset Game
    static public void ResetGame()
    {
        score = 0;
        birdRow = 6;
        birdCol = 10;
        velocity = 0;
        isWingUp = true;
        pipeX = 72;
        GameLogic.Start();
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
        Screen.GameOverScreen(score);

        if (Console.ReadKey(true).Key == ConsoleKey.Escape) return;
        else
        {
            ResetGame();
        }
    }

    //  Console Utils
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

    // Obstacle Movement Logic
    static void HorizontalMovement(int x)
    {
        pipeX--;
        if (pipeX < -3)
            pipeX = x;
    }


}