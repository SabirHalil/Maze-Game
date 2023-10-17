using System;
using System.IO;

namespace maze_game
{
    internal class FileOperations
    {
       private  string dosya = @"file.txt";
        public char[,] grid;

        public  void dosyaOlustur()
        {
            GenerateMaze maze = new GenerateMaze();
            int[,] matrix = maze.generateMaze();
            StreamWriter write = null;
           try {
             write   = new StreamWriter(dosya, false );
               for (int i = 0; i < 30; i++)
               {
                   for (int j = 0; j < 30; j++)
                   {
                       write.Write(matrix[i,j]);

                   }
                   write.WriteLine();

               }
           }catch (Exception ex)
           {
               Console.WriteLine(ex.ToString());
           }
           finally
           {
               write.Close();

           }
           
        }

        public  void readFile()
        {
            string[] lines = File.ReadAllLines(dosya);
            int rows = lines.Length;
            int k = 0;
            grid = new char[30, 30];
            for (int i = 0; i < rows; i++)
            {
                string line = lines[i];
                char[] parts = line.ToCharArray();

                for (int j = 0; j < parts.Length; j++)
                {
                    if ((parts[j] == '1') || (parts[j] == '0'))
                    {

                        grid[i, k] = parts[j];
                        k++;
                    }
                }
                k = 0;


        }
    }
}
}
