using System;


namespace maze_game
{
    internal class Bomb
    {
        public char[,] bombs = new char[3,2];

        public void GenerateBombs(char[,] maze)
        {
            int x, y;
        
        Random r = new Random();
            int i = 0;
            while (i < 3)
            {
                x = r.Next(0,30);
                y = r.Next(0,30);

                if (maze[x, y] == '0')
                {
                    maze[x, y] = 'B';
                    i++;
                }
                    
            }
        }

    }
}
