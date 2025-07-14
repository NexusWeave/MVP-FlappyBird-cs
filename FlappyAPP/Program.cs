namespace FlappyAPP;
class Program
{
    static int offset = 1;
    static int intervalWidth = 5;
    static int row = 20;
    static int column = 75;
    static int score = 0;
    static int birdRow = 6;
    static int birdCol = 20                                              ;
    static int velocity = 0;
    static bool isWingUp = true;
    static int pipeX = 72;
    static int pipeGapTop = 4;
    static int pipeGapBottom = 14;                         
    static char obstacle = '█';
    static void Main()
    {
        bool startGame = true;

        while (startGame)
        {
            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar)
            {
                startGame = false;
                pipeX = column - 1;
                GameLogic.DrawGameArea(row, column, obstacle, ref velocity, ref birdRow, ref isWingUp, ref pipeX, ref birdCol, ref pipeGapTop, ref pipeGapBottom, ref score, ref offset, ref intervalWidth);
            }
            else {
                ConsoleConfig.ConsoleConfigs();
                GameLogic.DrawStartScreen(row, column, obstacle, offset, intervalWidth);
               }
        }

    }

    public static void GameOver()
    {
        ScreenText.DrawGameOverScreen(score);

        if (Console.ReadKey(true).Key == ConsoleKey.Escape) return;
        else 
        {
            Console.Clear();
            ResetGame();
        }
    }
    static void ResetGame()
    {
        score = 0;
        birdRow = 6;
        birdCol = 20;
        velocity = 0;
        isWingUp = true;
        pipeX = 72;
        Main();
    }


}
