using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Score
{
    public int score;
    /*public bool InGap = false;
    private int score
    {
        get { return score; }
        set { score = value; }
    }

    public Score(int x = 0)
    {
        score = x;
    }

    public void Increment()
    {
        if (InGap)
        {
            score ++;
        }
    }
    private int GetScore()
    {
        return score;
    }
    public void PrintScore()
    {
        Console.SetCursorPosition(37, 0);
        Console.WriteLine("Score: " + GetScore(), Console.ForegroundColor = ConsoleColor.Black);
        Console.SetCursorPosition(0, 1);

    }*/

    static public void Increment(int hitboxEnd, int pipeX, Score Score, int pipeGapTop, int pipeGapBottom)
    {
        if (hitboxEnd == pipeX + 3)
        {
            Score.score += 1;
            if (pipeGapTop < 6)
            {
                pipeGapTop += 1;
                pipeGapBottom -= 1;
            }
        }
    }

    static private int GetScore(Score Score)
    {
        return Score.score;
    }

    static public void Reset(Score Score)
    {
        Score.score = 0;
    }

    static public void PrintScore(Score score, int x)
    {
        Console.SetCursorPosition(x, 0);
        Console.WriteLine($"{Score.GetScore(score)}", Console.ForegroundColor = ConsoleColor.Black);
        Console.SetCursorPosition(0, 1);

    }

}