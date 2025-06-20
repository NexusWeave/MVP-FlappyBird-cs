namespace FlappyAPP;

public class GameLogic
{
    //Sprite sprite = new Sprite();
    Background background = new Background();


    static public void Start(int x, int y, char obstacleChar)
    {
        ScreenText.DrawGameStartScreen(x, y, obstacleChar);
        

    }
    static public void Update()
    {

    }
    
   /* static public void CollisionCheck(int hitboxStart, int hitboxEnd)
     {

         if (birdRow > row - 4) birdRow = row - 4;
         if (velocity > 0) isWingUp = false;

         if (pipeX <= hitboxEnd && pipeX + 2 >= hitboxStart &&
             (birdRow <= pipeGapTop || birdRow + 2 >= pipeGapBottom))
             GameOver();

         if (birdRow + 1 >= row - 3) GameOver();
     }

    /* static void ResetGame()
     {
         score = 0;
         birdRow = 6;
         birdCol = 10;
         velocity = 0;
         isWingUp = true;
         pipeX = 72;
         Main();
     }*/

}