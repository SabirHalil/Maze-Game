using System;

using static System.Console;
using Pastel;
using Figgle;


namespace maze_game
{
    internal class Program
    {

        
        static void Main(string[] args)
        {
            Title = "Maze Game";
            CursorVisible = false;
            
            WriteLine(FiggleFonts.Larry3d.Render("  Welcome to  ")); 
            WriteLine(FiggleFonts.Larry3d.Render("the Maze Game "));

            DisplayIntro();

            SolveMaze solveMaze = new SolveMaze();
            solveMaze.start(); 

        }
      private static void DisplayIntro()
        {
            ConsoleKeyInfo keyInfo;
            ConsoleKey key;
            do
            {
                WriteLine("Press (Y) to Create a new maze:".Pastel("#07B419"));
                WriteLine("Press (C) to solve the current maze:".Pastel("#07B419"));
                keyInfo = ReadKey();
                key = keyInfo.Key;
                WriteLine();
                if (key == ConsoleKey.Y)
                {
                    Clear();
                    FileOperations dosyaIslem = new FileOperations();
                    dosyaIslem.dosyaOlustur();
                    WriteLine("New maze created");
                }
            } while(key != ConsoleKey.C);

        }

       
    }
}
