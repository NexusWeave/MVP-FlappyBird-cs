namespace FlappyAPP;

public class Sprite
{
    int y;
    int velocity;
    bool isElivated;

    public string Draw()
    {
        string[] wingUp = {
            "  \\   /  ",
            "   \\0/   ",
        };

        string[] wingDown = {
            "   /0\\   ",
            "  /   \\  "
        };

        return isElivated ? string.Join("\n", wingUp) : string.Join("\n", wingDown);
    }

    public void VerticalMovement()
    {
        if (isElivated)
        {
            velocity++;
            y -= velocity;
            
        }
        else
        {
            velocity--;
            y += velocity;
        }
    }

}