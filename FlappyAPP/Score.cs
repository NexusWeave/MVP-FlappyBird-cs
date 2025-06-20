using System.Security.Cryptography.X509Certificates;

class Score
{
    public int score;

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