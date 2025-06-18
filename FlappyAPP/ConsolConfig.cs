namespace FlappyAPP;

public class ConsoleSettings
{
    public static void ConsoleConfig()
    {
        Console.CursorVisible = false;
        Console.Title = "FlappyAPP";
        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
    }
}