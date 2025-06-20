namespace FlappyAPP;

public class Background
{
    public static void MakeBackground()
    {
        ConsoleSettings.ConsoleConfig();
    }
    public static char[,] SetGameBorders(char[,] buffer, char obstacleChar)
    {
        int x = buffer.GetLength(1);
        int y = buffer.GetLength(0);

        for (int i = 0; i < x; i++)
        {
            buffer[y - 1, i] = obstacleChar;
        }
        return buffer;
    }
}