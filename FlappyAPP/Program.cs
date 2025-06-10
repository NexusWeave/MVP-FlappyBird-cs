// See https://aka.ms/new-console-template for more information
using System;

namespace FlappyAPP;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to FlappyAPP!");
        Console.WriteLine("This is a simple console application that simulates a flappy bird game.");
        Console.WriteLine("This application has the obstacle generation feature enabled.");

        DrawGameArea();

    }

    static void DrawGameArea()
    {
        int blockSize = 21;
        int inlineSize = 73;
        char newlineCharacter = '\n';

        //  Row
        for (int i = 0; i < blockSize; i++)
        {
            if (i == 0 || i == blockSize - 1)
            {
                //  Column
                Columns(inlineSize);
            }
            else
            {
                Columns(Obstacle: newlineCharacter);
            }
        }
    }

    static void Columns(int inlineSize = 1, char Obstacle = '#')
    {
        for (int j = 0; j < inlineSize; j++)
        {
            Console.Write(Obstacle);
        }
    }
}
 

