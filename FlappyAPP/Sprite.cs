using System.Runtime.CompilerServices;

namespace FlappyAPP;

public class Sprite
{
    public int[] pos = new int[2];
    public int velocity;
    public bool isElivated;

    public static void Draw(char[,] buffer)
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

    public static bool Toggle(Sprite sprite)
    {
        // Toggle the elevation state of the sprite
        sprite.isElivated = !sprite.isElivated;
      
        return sprite.isElivated;
    }

    public static int VerticalMovement(int birdrow, int velocity)
    {
        return birdrow += velocity;
    }

    // Helper method?
    public static bool IsBirdPixel(int x, int y, char[,] buffer)
    {

        return buffer[y, x] == '/' || buffer[y, x] == '\\' || buffer[y, x] == '0';
    }

    public static int ResetVelocity(int velocity)
    {
        velocity += 1;
            if (velocity > 1) velocity = 1;
        return velocity;
    }

}