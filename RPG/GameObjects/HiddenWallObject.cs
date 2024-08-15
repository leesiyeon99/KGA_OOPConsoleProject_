using RPG.Items;
using RPG.Scenes;

namespace RPG.GameObjects
{
    public class HiddenWallObject : GameObject
    {
        ConsoleKey inputKey;
        public HiddenWallObject(Scene scene) : base(scene)
        {
        }

        public override void Interaction(Player player)
        {
            Render();

            if (WallBreak(LastScene.Item))
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
            Console.WriteLine("깰 수 있는 벽인거 같습니다. 벽을 깨트리겠습니까? (Y / N)");
        }

        public bool WallBreak(Item item)
        {
            while (true)
            {
                ConsoleKey input = Console.ReadKey(true).Key;
                if (input == ConsoleKey.Y)
                {
                    if (Inventory.items.Contains(item))
                    {
                        Player.playerPos.x = 4;
                        Player.playerPos.y = 6;
                        Console.SetCursorPosition(0, Console.WindowHeight - 13);
                        Console.Write("벽을 부수는 중...");
                        Thread.Sleep(1000);
                        Console.Write("벽이 부서졌습니다.");
                        Thread.Sleep(1000);
                        Inventory.items.Remove(item);
                        return true;
                    }
                    else
                    {
                        Player.playerPos.x = 3;
                        Player.playerPos.y = 6;
                        Console.SetCursorPosition(0, Console.WindowHeight - 13);
                        Console.WriteLine("망치가 없습니다.");
                        Thread.Sleep(1000);
                        return false;
                    }
                }
                else if (input == ConsoleKey.N)
                {
                    Player.playerPos.x = 3;
                    Player.playerPos.y = 6;
                    return false;
                }
                else
                {
                    Console.SetCursorPosition(0, Console.WindowHeight - 14);
                    Console.Write("잘못입력하셨습니다. 예(Y)/아니요(N)로 입력해주세요");
                    Thread.Sleep(1000);
                }
            }

        }
    }
}
