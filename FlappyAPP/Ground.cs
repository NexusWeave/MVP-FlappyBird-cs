public class Ground
{
    public static char[,] SetGround(char[,] buffer, char groundChar)
    {
        int x = buffer.GetLength(1);
        int y = buffer.GetLength(0);

        for (int i = 0; i < x; i++)
        {
            buffer[y - 2, i] = groundChar;
        }
        return buffer;
    }
}