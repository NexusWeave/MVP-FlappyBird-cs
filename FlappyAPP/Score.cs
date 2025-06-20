using System.Security.Cryptography.X509Certificates;

class Score
{
    public int score;

    static public void Increment(Score Score)
    {
        Score.score++;
    }

    static public int GetScore(Score Score)
    {
        return Score.score;
    }

    static public void Reset(Score Score)
    {
        Score.score = 0;
    }
    static public void PrintScore(Score score)
    {
        Console.SetCursorPosition(37, 0);
        Console.WriteLine("Score: " + Score.GetScore(score), Console.ForegroundColor = ConsoleColor.Black);
        Console.SetCursorPosition(0, 1);

    }

}