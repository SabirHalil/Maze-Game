using System;
using static System.Console;
using Pastel;

namespace maze_game
{
    internal class SolveMaze
    {
        private static FileOperations  fileOperation;
        private static char[,] temp;
        private static char[,] tempO;
        private static bool bom= false;
       private static bool solved;
        public void start()
        {

            Clear();
            WriteLine("-------Game started!-------");
            fileOperation = new FileOperations();
            fileOperation.readFile();
            tempO= (char[,])fileOperation.grid.Clone();
            Bomb bomb = new Bomb();
            bomb.GenerateBombs(fileOperation.grid);
             temp = (char[,])fileOperation.grid.Clone();
           
             solved = false;
             int i = 0;
            while (i <=29 && !solved)
            {
                if (traverse(fileOperation.grid, i, 0) )
                {
                    solved = true;
                    adjustMaze(fileOperation.grid);
                    
                    WriteLine("Maze Solved");
                    DisplayOutro();

                }
                else
                    fileOperation.grid = (char[,])temp.Clone();

                i++;    
            }
            DisplayOutro();
            if (!solved)
                WriteLine("Maze not Solved");




        }
        static void DisplayOutro()
        {
            ConsoleKeyInfo keyInfo;
            ConsoleKey key;

            do
            {
                
                WriteLine("Press (L) to draw the original maze.".Pastel("#07B419"));
                WriteLine("Press (B) to draw the coordinates of the bombs.".Pastel("#07B419"));
                WriteLine("Press (X) to draw the game's path coordinates.".Pastel("#07B419"));
                WriteLine("Press (Esc) to exit the game.".Pastel("#07B419"));
                keyInfo = ReadKey();
                key = keyInfo.Key;
                if (key == ConsoleKey.X)
                        printMaze(fileOperation.grid);
                
                else if (key == ConsoleKey.L)
                    printMaze(tempO);
               else if(key == ConsoleKey.B)
                    printMaze(temp);



            } while (key != ConsoleKey.Escape);
        
        }
        static void adjustMaze(char [,] maze)
        {
            for(int i = 0; i < maze.GetLength(0); i++)
            {
                for( int j = 0; j < maze.GetLength(1); j++)
                {
                    if (solved)
                    {
                        if (maze[i, j] == '-')
                            maze[i, j] = 'X';
                    }
                    if (maze[i, j] == '*' )
                        maze[i, j] = '0';
                 
                }
            }
        }

        static void printMaze(char [,] maze)
        {
            Clear();
            Console.WriteLine();
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if(maze[i, j] == 'B')
                        Console.Write("{0}".Pastel("#ff0000"),maze[i,j]);
                    else if(maze[i, j] == 'X' || maze[i, j] == '*')
                        Console.Write("{0}".Pastel("#07B419"), maze[i, j]);
                    else
                        Console.Write(maze[i, j]);
                }
                Console.WriteLine();

            }
            Console.WriteLine();
        }
         
        public static bool isValidSpot(char [,] maze, int r, int c) {

            if (r >= 0 && r < 30 && c >= 0 && c < 30)
                return maze[r,c] == '0' || maze[r,c] == 'B';

            return false; 
        }

        public static bool traverse(char[,] maze, int r, int c)
        {
            if (isValidSpot(maze, r, c))
            {
                if(maze[r,c] == 'B')
                {
                    bom = true;
                    bomm();
                }
                //it is a valid spot
                if ( c == 29)
                {
                    maze[r, c] = '-';
                    return true;
                }

                maze[r,c] ='*';

                
                //right
                bool returnValue = traverse(maze, r, c + 1);


                
                //down
                if (!returnValue)
                {
                    returnValue = traverse(maze, r + 1, c);
                   
                }

                //up
                if (!returnValue)
                {
                    returnValue = traverse(maze, r - 1, c);
                }

                //left
                if (!returnValue)
                {
                    returnValue = traverse(maze, r, c - 1);
                }

                if (returnValue)
                {
                  //  WriteLine(r + ", " + c);
                    maze[r,c] = '-';
                }
                return returnValue;
            }

            return false;
        }
        private static void bomm()
        {
            Beep();
            DisplayOutro();
        }
    }
}
