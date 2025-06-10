// See https://aka.ms/new-console-template for more information
using System;
using System.Runtime.InteropServices;
using System.Xml;

namespace FlappyAPP;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to FlappyAPP!");
        Console.WriteLine("This is a simple console application that simulates a flappy bird game.");
        Console.WriteLine("This application has the obstacle generation feature enabled.");

        int row = 12;
        int column = 73;

        DrawGameArea(row, column, "#");
    }

    static void DrawGameArea(int row, int column, string Obstacle)
    {

        int CylinderRow = 6;
        string newlineCharacter = "(space)";

        //  Row
        for (int i = 0; i < row; i++)
        {
            if (i == 0 || i == row - 1)
            {
                //  Column
                BlockStartColumns(column, Obstacle);
                Console.Write("\n");
            }

            else if (i == 1)
            {
                BlockEndCylinderPipe(CylinderRow, column, Obstacle);
                Console.Write("\n");
            }
            else if (i == row - 2)
            {
                BlockStartCylinderPipe(CylinderRow, column, Obstacle);
                Console.Write("\n");
            }
            else
            {
                //  TODO: Add a Figure to the game area
                BlockStartColumns(1, newlineCharacter);
                Console.Write("\n");
            }
        }
    }

    static void BlockStartColumns(int column, string Obstacle)
    {
        for (int i = 0; i < column; i++)
        {
            Console.Write(Obstacle);
        }
        
    }

    static void BlockEndColumns(int column, string Obstacle)
    {
        for (int i = column; i > 0; i--)
        {
            Console.Write(Obstacle);
        }
    }

    static void BlockEndCylinderPipe(int row, int column, string Obstacle)
    {
        column /= 2;
        int CylinderColumn = 5;

        Random random = new Random();
        var space = random.Next(1, column);

        //  Rows
        for (int i = 0; i < row; i++)
        {
            // For every 25th column, draw a pipe
            BlockEndColumns(space, " ");
            BlockEndColumns(CylinderColumn, Obstacle);
            Console.Write("\n");
        }

    }

    static void BlockStartCylinderPipe(int row, int column, string Obstacle)
    {
        column /= 2;
        int CylinderColumn = 5;

        Random random = new Random();
        var space = random.Next(1, column);

        //  Rows
        for (int i = 0; i < row; i++)
        {

            // For every 25th column, draw a pipe
            BlockEndColumns(space, " ");
            BlockEndColumns(CylinderColumn, Obstacle);
            Console.Write("\n");
        }
    }
}