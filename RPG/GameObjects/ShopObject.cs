using RPG.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.GameObjects
{
    public class ShopObject : GameObject
    {
        public ShopObject(Scene scene) : base(scene)
        {
        }

        public override void Interaction(Player player)
        {
            game.ChangeScene(SceneType.ShopMenu);
            removeWhenInteract = false;
            Console.Clear();
            Console.WriteLine("****************************");
            Console.WriteLine("     상점 들어가는 중...     ");
            Console.WriteLine("****************************");
            Thread.Sleep(1000);
        }
    }
}
