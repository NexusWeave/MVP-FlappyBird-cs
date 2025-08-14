namespace FlappyAPP;

public class ScreenText
{
    public static void DrawGameOverScreen(int score)
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


    static public char[,] DrawGameStartScreen(char[,] buffer, int y, int x, char obstacleChar)
    {
        Background.MakeBackground();

        Console.Clear();
        Console.WriteLine("Welcome to FlappyAPP!");
        Console.WriteLine("Press any key to start...");
        buffer = Background.SetGameBorders(buffer, obstacleChar);

        Sprite.Draw(buffer);
        Console.ReadKey(true);
        return buffer;
    }

}