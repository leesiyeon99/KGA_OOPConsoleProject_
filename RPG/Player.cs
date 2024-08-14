using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Player
    {
        public Point playerPos;
        public char[,] Map;
        public int money;
        public int attack;
        public int lucky;
        public int defense;
        public int hp;
        public int MaxHp = 100;
        public Player(int x, int y, char[,] maps)
        {
            Point point = new Point(3, 1);
            point.x = x;
            point.y = y;
            playerPos = point;
            Map = maps;
        }

        public Player()
        {
            money = 500;
            attack = 20;
            defense = 20;
            hp = 100;
        }

        public void GetMoney()
        {
            Random random = new Random();
            int ranMoney = random.Next(100, 1000);
            if (ranMoney <= 1000 && ranMoney > 800)
            {
                money += ranMoney;
                lucky += 10;
                Console.SetCursorPosition(0, Console.WindowHeight - 15);
                Console.WriteLine($"{ranMoney}원을 주웠습니다. 횡재했습니다!");
                Thread.Sleep(1000);
                Console.WriteLine($"플레이어의 기분이 좋아졌습니다. 운이 '10' 상승했습니다");
                Console.WriteLine($"현재 갖고 있는 돈은 {money}, 행운은 {lucky}입니다.");
                Thread.Sleep(2000);
            }
            else if (ranMoney <= 800 && ranMoney > 400)
            {
                money += ranMoney;
                lucky += 5;
                Console.SetCursorPosition(0, Console.WindowHeight - 15);
                Console.WriteLine($"{ranMoney}원을 주웠습니다. 평범합니다.");
                Thread.Sleep(1000);
                Console.WriteLine($"플레이어의 기분은 평범합니다. 운이 '5' 상승했습니다");
                Console.WriteLine($"현재 갖고 있는 돈은 {money}, 행운은 {lucky}입니다.");
                Thread.Sleep(2000);
            }
            else if (ranMoney <= 400 && ranMoney >= 100)
            {
                money += ranMoney;
                lucky -= 1;
                Console.SetCursorPosition(0, Console.WindowHeight - 15);
                Console.WriteLine($"{ranMoney}원을 주웠습니다. 운이 안좋았습니다.");
                Thread.Sleep(1000);
                Console.WriteLine($"플레이어의 기분이 안좋아졌습니다. 운이 '-1' 하락했습니다");
                Console.WriteLine($"현재 갖고 있는 돈은 {money}, 행운은 {lucky}입니다.");
                Thread.Sleep(2000);
            }

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
