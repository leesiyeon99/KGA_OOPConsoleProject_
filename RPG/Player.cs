using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Player
    {
        static public Point playerPos;
        public char[,] Map;
        public Player(int x, int y, char[,] maps)
        {
            Point point = new Point(3, 1);
            point.x = x;
            point.y = y;
            playerPos = point;
            Map = maps;
        }
        public void MovePlayer(ConsoleKey inputKey)
        {
            switch (inputKey)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    MoveUp();
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    MoveDown();
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    MoveLeft();
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    MoveRight();
                    break;
            }
        }

        public void MoveUp()
        {
            if (playerPos.y - 1 == 0)
                return;
            if (Map[playerPos.y - 1, playerPos.x] != 'f')
            {
                playerPos.x = playerPos.x;
                playerPos.y = playerPos.y - 1;
            }
        }

        public void MoveDown()
        {
            if (Map[playerPos.y + 1, playerPos.x] != 'f')
            {
                playerPos.x = playerPos.x;
                playerPos.y = playerPos.y + 1;
            }
        }

        public void MoveLeft()
        {
            if (playerPos.x - 1 == 0)
                return;

            if (Map[playerPos.y, playerPos.x - 1] != 'f')
            {
                playerPos.x = playerPos.x - 1;
                playerPos.y = playerPos.y;
            }
        }

        public void MoveRight()
        {
            if (Map[playerPos.y, playerPos.x + 1] != 'f')
            {
                playerPos.x = playerPos.x + 1;
                playerPos.y = playerPos.y;
            }
        }
    }
}
