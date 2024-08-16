using RPG.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.GameObjects
{
    public class HammerObject : GameObject
    {
        Inventory Inventory;
        public HammerObject(Scene scene) : base(scene)
        {
            Inventory = new Inventory();
        }

        public override void Interaction(Player player)
        {
            if (Inventory.AddItem(LastScene.Item))
            {
                removeWhenInteract = true;
                Console.SetCursorPosition(0, Console.WindowHeight - 15);
                Console.WriteLine("망치를 주웠습니다. 인벤토리에 보관하였습니다.");
                Thread.Sleep(1000);
            }
            else
            {
                Player.playerPos.x = 13;
                Player.playerPos.y = 3;
                removeWhenInteract = false;
                Console.SetCursorPosition(0, Console.WindowHeight - 15);
                Console.WriteLine("인벤토리가 가득 찼습니다. 망치를 주울 수 없습니다.");
                Console.WriteLine("인벤토리에 있는 아이템을 사용하거나 상점에 판매해주세요.");
                Thread.Sleep(2000);
            }
        }
    }
}
