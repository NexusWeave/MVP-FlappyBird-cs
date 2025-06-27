namespace FlappyAPP;

public class Screen
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

    static public void StartScreen(char[,] buffer, char obstacleChar, int offset, int intervalX)
    {

        while (!Console.KeyAvailable)
        {
            Console.Clear();
            ConsoleSettings.ConsoleConfig();
            Console.WriteLine("Welcome to FlappyAPP!");
            Console.WriteLine("Press any key to start...");
            // Wait for user to press a key
            Background.GenerateBackground(buffer, obstacleChar, ref offset, ref intervalX);
            Thread.Sleep(50);
            
        }
        

        Bird.DrawFrame(ref buffer);
        

        //Bird.DrawFrame(ref buffer);
        //Console.ReadKey(true);

        //return buffer;
    }

    static public char[,] ResetScreen(char[,] buffer, char space, char obstacleChar, int offset, int intervalX)
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
        Ground.DrawGround(ref buffer, obstacleChar, offset, intervalX);

        return buffer;
    }

}