using RPG.Items;
using RPG.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.GameObjects
{
    public class DoorObject : GameObject
    {
        ConsoleKey inputKey;
        public DoorObject(Scene scene) : base(scene)
        {

        }

        public override void Interaction(Player player)
        {
            Render();

            if (DoorOpen(FirstScene.Item))
            {
                removeWhenInteract = true;
            }
            else
            {
                removeWhenInteract = false;
            }
        }

        public void Render()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 15);
            Console.WriteLine("문이 잠겨있습니다. 문을 열 방법을 선택해주세요");
            Console.WriteLine("1. 열쇠로 열기");
            Console.WriteLine("2. 그냥 열어보기");
            Console.WriteLine("3. 뒤로가기");
        }

        public bool DoorOpen(Item item)
        {
            while (true)
            {
                ConsoleKey input = Console.ReadKey(true).Key;
                if (input == ConsoleKey.D1)
                {
                    if (Inventory.items.Contains(item))
                    {
                        Player.playerPos.x = 8;
                        Player.playerPos.y = 10;
                        Console.SetCursorPosition(0, Console.WindowHeight - 11);
                        Console.Write("잠금을 푸는 중 ...");
                        Thread.Sleep(1000);
                        Console.Write("문이 열렸습니다.");
                        Thread.Sleep(1000);
                        Inventory.items.Remove(item);
                        return true;
                    }
                    else
                    {
                        Player.playerPos.x = 8;
                        Player.playerPos.y = 9;
                        Console.SetCursorPosition(0, Console.WindowHeight - 11);
                        Console.WriteLine("열쇠가 없습니다.");
                        Thread.Sleep(1000);
                        return false;
                    }
                }
                else if (input == ConsoleKey.D2)
                {
                    if (Player.lucky >= 100)
                    {
                        Player.playerPos.x = 8;
                        Player.playerPos.y = 10;
                        Console.SetCursorPosition(0, Console.WindowHeight - 11);
                        Console.Write("운이 좋습니다. 갑자기 문이 열렸습니다.");
                        Thread.Sleep(1000);
                        return true;
                    }
                    else
                    {
                        Player.playerPos.x = 8;
                        Player.playerPos.y = 9;
                        Console.SetCursorPosition(0, Console.WindowHeight - 11);
                        Console.WriteLine("문을 열지 못했습니다. 열쇠를 찾아오거나 행운을 늘리세요");
                        Thread.Sleep(1000);
                        return false;
                    }
                }
                else if (input == ConsoleKey.D3)
                {
                    Player.playerPos.x = 8;
                    Player.playerPos.y = 9;
                    return false;
                }
                else
                {
                    Console.SetCursorPosition(0, Console.WindowHeight - 14);
                    Console.Write("잘못입력하셨습니다.");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
