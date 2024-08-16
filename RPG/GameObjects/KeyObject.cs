using RPG.Scenes;

namespace RPG.GameObjects
{
    public class KeyObject : GameObject
    {
        Inventory Inventory;
        public KeyObject(Scene scene) : base(scene)
        {
            Inventory = new Inventory();
        }

        public override void Interaction(Player player)
        {
            if (Inventory.AddItem(FirstScene.Item))
            {
                removeWhenInteract = true;
                Console.SetCursorPosition(0, Console.WindowHeight - 15);
                Console.WriteLine("열쇠를 주웠습니다. 인벤토리에 보관하였습니다.");
                Thread.Sleep(1000);
            }
            else
            {
                Player.playerPos.x = 4;
                Player.playerPos.y = 9;
                removeWhenInteract = false;
                Console.SetCursorPosition(0, Console.WindowHeight - 15);
                Console.WriteLine("인벤토리가 가득 찼습니다. 열쇠를 주울 수 없습니다.");
                Console.WriteLine("인벤토리에 있는 아이템을 사용하거나 상점에 판매해주세요.");
                Thread.Sleep(2000);
            }


        }
    }
}
