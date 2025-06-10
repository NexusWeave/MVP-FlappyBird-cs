// See https://aka.ms/new-console-template for more information
using System;
using System.Runtime.InteropServices;

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
        int CylinderColumn = 5;
        string newlineCharacter = "(space)";

        //  Row
        for (int i = 0; i < row; i++)
        {
            if (i == 0 || i == row - 1)
            {
                //  Column
                BlockStartColumns(column, Obstacle);
            }
            else if (i == 1)
            {
                BlockEndCylinderPipe(CylinderRow, CylinderColumn, Obstacle);
            }
            else if (i == row - 2)
            {
                BlockStartCylinderPipe(CylinderRow, CylinderColumn, Obstacle);
            }
            else
            {
                BlockStartColumns(1, newlineCharacter);
            }
        }
    }

    static void BlockStartColumns(int column, string Obstacle)
    {
        for (int i = 0; i < column; i++)
        {
            Console.Write(Obstacle);
        }
        Console.Write("\n");
    }

    static void BlockEndColumns(int column, string Obstacle)
    {
        for (int i = column; i > 0; i--)
        {
            Console.Write(Obstacle);
        }
        Console.Write("\n");
    }

    static void BlockEndCylinderPipe(int row, int column, string Obstacle)
    {
        //  Rows
        for (int i = 0; i < row; i++)
        {
            BlockEndColumns(column, Obstacle);
        }
    }
    static void BlockStartCylinderPipe(int row, int column, string Obstacle)
    {
        //  Rows
        for (int i = 0; i < row; i++)
        {
            BlockStartColumns(column, Obstacle);
        }
    }
}