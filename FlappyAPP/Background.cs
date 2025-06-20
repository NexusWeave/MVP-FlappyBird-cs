namespace FlappyAPP;

public class Background
{
    public static void MakeBackground()
    {
        ConsoleSettings.ConsoleConfig();
    }
    public static char[,] SetGameBorders(char[,] buffer, int y, char obstacleChar)
    {
        for (int i = 0; i < buffer.GetLength(1); i++)
        {
            buffer[y -1, i] = obstacleChar;
        }
        return buffer;
    }
}