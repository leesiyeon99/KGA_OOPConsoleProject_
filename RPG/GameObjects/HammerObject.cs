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
            Inventory.AddItem(LastScene.Item);
            removeWhenInteract = true;
            Console.SetCursorPosition(0, Console.WindowHeight - 15);
            Console.WriteLine("망치를 주웠습니다. 인벤토리에 보관하였습니다.");
            Thread.Sleep(1000);
        }
    }
}
