using FlappyAPP;

public class Ground
{
    public static void DrawGround(ref char[,] buffer, char Obstacle, int offset, int gapX)
    {
        int x = buffer.GetLength(1);
        int y = buffer.GetLength(0);
        int n = x - 1;

        ConsoleColor color = offset < gapX ? ConsoleColor.Green : ConsoleColor.Yellow;

        for (int i = n; i >= 0; i--)
        {
            Console.ForegroundColor = color;
            if (i % gapX == 0)
            {
                color = color == ConsoleColor.Yellow ? ConsoleColor.Green : ConsoleColor.Yellow;

            }
            Console.Write(Obstacle);
        }

        

    }

        public static void GroundAnimation( ref int offset, ref int gapX) 
        {
              offset = (offset + gapX * 2 - 1) % (gapX * 2);
        }
}