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


    static void DrawGameStartScreen()
    {
        Console.Clear();
        Console.WriteLine("Welcome to FlappyAPP!");
        Console.WriteLine("Press any key to start...");
        Console.ReadKey(true);

        // Cursor position for the Sprite

    }

}