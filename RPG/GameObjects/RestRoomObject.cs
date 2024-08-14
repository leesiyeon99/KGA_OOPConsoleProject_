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
            Input();
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

        public void Input()
        {
            inputKey = Console.ReadKey(true).Key;
        }

        public bool Update()
        {
            if (inputKey == ConsoleKey.Y)
            {
                Player.hp = 100;
                Console.SetCursorPosition(0, Console.WindowHeight - 13);
                Console.WriteLine("체력이 MAX로 회복되었습니다.");
                Thread.Sleep(1000);
                return true;
            }
            else
            {
                Player.playerPos.x = 7;
                Player.playerPos.y = 7;
                return false;
            }
        }
    }
}
