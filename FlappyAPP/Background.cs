namespace FlappyAPP;

public class Background
{
    public static void GenerateBackground(char[,] buffer, char obstacle, ref int offset, ref int intervalX)
    {
        Ground.GroundAnimation(ref offset, ref intervalX);
        Ground.DrawGround(ref buffer, obstacle, offset, intervalX);
    }

}

