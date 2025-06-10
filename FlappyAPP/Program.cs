// See https://aka.ms/new-console-template for more information
using System;

namespace FlappyAPP;
class Program
{

    string[] wingUp = {
    "  \\   /  ",
    "   \\0/   ",
    "          "
};
    string[] wingDown = {
    "         ",
    "   /0\\  ",
    "  /   \\ "
};

    int oldHeight = 10;
    int Height = 10;
    int newHeight = 10;
    bool isWingUp = true;
    int blockSize = 21;
    int inlineSize = 73;
    char newlineCharacter = '\n';
       
   static void Main(string[] args)
    {

        Console.WriteLine("Welcome to FlappyAPP!");
        Console.WriteLine("This is a simple console application that simulates a flappy bird game.");
        Console.WriteLine("This application has the obstacle generation feature enabled.");
        Console.ReadKey();
       var program = new Program();
        program.Game();

    }

    void Game()
    {
        while (true)
        {
            Console.Write(Height);
            DrawFlight();
            DrawGameArea();
            Thread.Sleep(300);
            Console.Clear();
        }
    }

    void DrawBird()
    {
        if (!isWingUp && oldHeight >= newHeight)
        {
            isWingUp = true; foreach (var line in wingUp) Console.WriteLine(line);
        }

        else
        {
            isWingUp = false; foreach (var line in wingDown) Console.WriteLine(line);
        }
        oldHeight = newHeight;
    }

    int SetFlightHight()
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Spacebar) { Height--; }
            while (Console.KeyAvailable) Console.ReadKey(true);
        }
        else
        {
            Height++;
        }
        return Height;
    }

    void DrawFlight()
    {
        int newFlightHight = SetFlightHight();
        if (newFlightHight < 2) Height = 2;
        if (newFlightHight > 18) Height = 18;
        newHeight = newFlightHight;
    }


    void DrawGameArea()
    {
        for (int i = 0; i < blockSize; i++)
        {
            if (i == 0 || i == blockSize - 1)
            {
                Columns(inlineSize);
            }
            else if (newHeight == i)
            {
                DrawBird();
            }
            else Columns(Obstacle: newlineCharacter);
        }
    }


    void Columns(int inlineSize = 1, char Obstacle = '#')
    {
        for (int j = 0; j < inlineSize; j++)
        {
            Console.Write(Obstacle);
        }
    }
}
