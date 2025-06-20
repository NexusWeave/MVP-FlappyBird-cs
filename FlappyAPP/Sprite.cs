namespace FlappyAPP;

public class Sprite
{
    public int[] pos = new int[2];
    public int velocity;
    public bool isElivated;
    
    public static void Draw(int y, int x, char[,] buffer, Sprite sprite)
    {

        for (int i = 0; i < sprite.pos[1]; i++)
        {
            for (int j = 0; j < buffer.GetLength(1); j++)
            {
                Console.ForegroundColor = IsBirdPixel(buffer, sprite) ? ConsoleColor.Black : ConsoleColor.Green;

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

    public static void VerticalMovement(Sprite sprite)
    {
        sprite.pos[1] += sprite.velocity;
    }

    // Helper method?
    public static bool IsBirdPixel(char[,] buffer, Sprite sprite)
    {
        int x = sprite.pos[0];
        int y = sprite.pos[1];

        return buffer[y, x] == '/' || buffer[y, x] == '\\' || buffer[y, x] == '0';
    }

    public static void ResetVelocity(Sprite sprite)
        {
            sprite.velocity++;
            if (sprite.velocity > 1) sprite.velocity = 1;
        }

}