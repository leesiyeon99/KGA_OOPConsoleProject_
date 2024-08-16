using RPG.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.GameObjects
{
    public class BuffObject : GameObject
    {
        ConsoleKey inputKey;
        public BuffObject(Scene scene) : base(scene)
        {
        }

        public override void Interaction(Player player)
        {

                Render();
                Input();
                Update();
            
        }

        public void Render()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 15);
            Console.WriteLine("플레이어의 운을 -1로 만드는 대신 풀회복, 공격력 20증가, 방어력 20증가 버프를 얻게 됩니다.");
            Console.WriteLine("버프를 얻으시겠습니까? (Y / N)");
        }

        public void Input()
        {
            inputKey = Console.ReadKey(true).Key;
        }

        public void Update()
        {
                if (inputKey == ConsoleKey.Y)
                {
                    Player.hp = 100;
                    Player.attack += 20;
                    Player.defense += 20;
                    Player.lucky = -1;
                    Console.SetCursorPosition(0, Console.WindowHeight - 13);
                    Console.WriteLine("버프를 획득하셨습니다.");
                    Console.WriteLine($"플레이어 체력은 {Player.hp} / 100, 공격력은 {Player.attack}, 방어력은 {Player.defense}이 됩니다.");
                    Thread.Sleep(2000);
                    removeWhenInteract = true;
                    return;
                }
                else if (inputKey == ConsoleKey.N)
                {
                    Player.playerPos.x = 5;
                    Player.playerPos.y = 2;
                    return;
                }
                else
                {
                    Player.playerPos.x = 5;
                    Player.playerPos.y = 2;
                    Console.SetCursorPosition(0, Console.WindowHeight - 13);
                    Console.WriteLine("잘못 입력하셨습니다.");
                    Thread.Sleep(1000);
                }
        }
    }
}
