using RPG.Scenes;

namespace RPG.GameObjects
{
    public class RestRoomObject : GameObject
    {
        ConsoleKey inputKey;
        GameObject GameObject;
        public RestRoomObject(Scene scene) : base(scene)
        {
        }

        public override void Interaction(Player player)
        {
            Render();
            if (Update())
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
            Console.WriteLine("단 한 번 이용할 수 있는 휴식공간입니다.");
            Console.SetCursorPosition(0, Console.WindowHeight - 14);
            Console.WriteLine("체력을 회복하실 수 있습니다. 회복하시겠습니까? (Y / N)");
        }

        public bool Update()
        {
            while (true)
            {
                inputKey = Console.ReadKey(true).Key;
                if (inputKey == ConsoleKey.Y)
                {
                    Player.hp = 100;
                    Console.SetCursorPosition(0, Console.WindowHeight - 12);
                    Console.WriteLine("체력이 MAX로 회복되었습니다.");
                    Thread.Sleep(1000);
                    return true;
                }
                else if (inputKey == ConsoleKey.N)
                {
                    if (Player.playerPos.x == 8 &&  Player.playerPos.y == 7)
                    {
                        Player.playerPos.x = 7;
                        Player.playerPos.y = 7;
                    }
                    else
                    {
                        Player.playerPos.x = 10;
                        Player.playerPos.y = 7;
                    }

                    return false;
                }
                else
                {
                    Console.SetCursorPosition(0, Console.WindowHeight - 13);
                    Console.WriteLine("잘못입력하셨습니다. 다시입력해주세요");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
