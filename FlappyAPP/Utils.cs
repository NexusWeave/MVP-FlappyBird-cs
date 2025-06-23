class Utils
{

    public static void DrawFrame(char[,] buffer)
    {
        int x = buffer.GetLength(1);
        int y = buffer.GetLength(0);

        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                Console.ForegroundColor = IsBirdPixel(j, i, buffer) ? ConsoleColor.Black : ConsoleColor.Green;

                Console.Write(buffer[i, j]);
            }
            Console.WriteLine();
        }
    }

    private static bool IsBirdPixel(int x, int y, char[,] buffer)
    {
        return buffer[y, x] == '/' || buffer[y, x] == '\\' || buffer[y, x] == '0';
    }
}
