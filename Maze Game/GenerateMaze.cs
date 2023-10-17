using System;


namespace maze_game
{
    internal class GenerateMaze
    {
        private int[,] maze;
        Random random = new Random();

        public  int [,] generateMaze()
        {
            maze = new int[30, 30];
            for (int i = 0; i < 30; i++)
                for (int j = 0; j < 30; j++)
                    maze[i, j] = 1;

             

            int r = random.Next(30);
            while(r % 2 == 1)
                r = random.Next(30);

            int c = random.Next(30);
            while(c % 2 == 1)
                c = random.Next(30);
           maze[r, c] = 0;

            recursion(r, c);
            adjustMaze();
            return maze;
        }
        private void adjustMaze()
        {
            for(int i = 0;i < 30; i++)
            {
                int k = random.Next(0, 2);
                maze[29, i] = k;
            }
                for(int j = 0;j < 30; j++)
                {
                    int k = random.Next(0, 2);
                    maze[j,29] = k;

                }
            
        }

        private void recursion(int r, int c)
        {

            int [] randDirs = generateRandomDirections();

            for (int i = 0; i < randDirs.Length; i++)
            {

                 switch (randDirs[i])
                {
                    case 1:  // Right
                        // Whether 2 cells to the right is out or not
                        if (c + 2 <= 29)
                            //continue;
                            if (maze[r, c + 2] != 0)
                            {
                                maze[r, c + 2] = 0;
                                maze[r, c + 1] = 0;
                                recursion(r, c + 2);
                            }
                        break;
                    case 2:  // Down
                        // Whether 2 cells down is out or not
                        if (r + 2 <= 29)
                            // continue;
                            if (maze[r + 2, c] != 0)
                            {
                                maze[r + 2, c] = 0;
                                maze[r + 1, c] = 0;
                                recursion(r + 2, c);
                            }
                        break;

                    case 3: // Up
                            //　Whether 2 cells up is out or not
                        if (r - 2 >= 0)
                            // continue;
                            if (maze[r - 2, c] != 0)
                            {
                                maze[r - 2, c] = 0;
                                maze[r - 1, c] = 0;
                                recursion(r - 2, c);
                            }
                        break;
                    case 4:
                        // Left
                            // Whether 2 cells to the left is out or not
                        if (c - 2 >= 0)
                           // continue;
                        if (maze[r,c - 2] != 0)
                        {
                            maze[r,c - 2] = 0;
                            maze[r,c - 1] = 0;
                            recursion(r, c - 2);
                        }
                        break;
                }
            }


        }

        private int[] generateRandomDirections()
        {
            int [] list = new int[4];
            for (int i = 0; i < 4; i++)
                list[i] = i + 1;

           
            for (int i = 0; i < 4; i++)
            {
                int k = random.Next(4);
                int value = list[k];
                list[k] = list[i];
                list[i] = value;
                
            }
   
            return list;
        }
    }
}
