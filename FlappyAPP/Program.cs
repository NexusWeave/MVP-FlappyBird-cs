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
        int n = column / 3;
        int CylinderRow = 6;
        string newlineCharacter = "(space)";

        while (true)
        {
            for (int i = 0; i < row; i++)
            {
                if (i == 0 || i == row - 1)
                {
                    //  Column
                    DrawColumns(column, Obstacle);
                    Console.Write("\n");
                }
                else if (i == 1 || i == row - 2)
                {

                    DrawCylinder(CylinderRow, n, Obstacle);
                }

                else
                {
                    //  TODO: Add a Figure to the game area
                    DrawColumns(1, newlineCharacter);
                    Console.Write("\n");

                }
            }

            Thread.Sleep(250);
            Console.Clear();

            n--;

            if (n == 16)
            {
                n = column; // Reset the column count to the original value
                // Add a new obstacle
                //DrawCylinder(CylinderRow, column, Obstacle);
            }

        }
    }

    static void DrawColumns(int column, string Obstacle)
    {
        for (int i = 0; i < column; i++)
        {
            Console.Write(Obstacle);
        }
    }


    static void DrawCylinder(int row, int column, string Obstacle)
    {
        int CylinderColumn = 5;

        var space = column-10;
        space--;

        for (int i = 0; i < row; i++)
        {
            // For every 25th column, draw a pipe
            DrawColumns(space, " ");
            DrawColumns(CylinderColumn, Obstacle);
            Console.Write("\n");
        }
    }
}

