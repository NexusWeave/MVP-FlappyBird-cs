namespace FlappyAPP;

public class Screen // Fame
{
    public static void GameOverScreen(int score)
    {
        Console.Clear();
        Console.SetCursorPosition(16, 8);
        Console.WriteLine("Score: " + score, Console.ForegroundColor = ConsoleColor.Black);
        Console.SetCursorPosition(20, 10);

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("GAME OVER!");
        Console.SetCursorPosition(20, 11);
        Console.WriteLine("Press Escape key to exit");
        Console.WriteLine("Press any other Key to restart Game");
    }

    static public char[,] StartScreen(char[,] buffer, char obstacleChar)
    {
        Background.MakeBackground();

        Console.Clear();
        Console.WriteLine("Welcome to FlappyAPP!");
        Console.WriteLine("Press any key to start...");

        buffer = Ground.SetGround(buffer, obstacleChar);

        Utils.DrawFrame(buffer);
        Console.ReadKey(true);

        return buffer;
    }

    static public char[,] ResetScreen(char[,] buffer, char space, char obstacleChar)
    {
        int x = buffer.GetLength(1);
        int y = buffer.GetLength(0);

        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                buffer[i, j] = space;
            }
        }
        buffer = Ground.SetGround(buffer, obstacleChar);

        return buffer;
    }

}