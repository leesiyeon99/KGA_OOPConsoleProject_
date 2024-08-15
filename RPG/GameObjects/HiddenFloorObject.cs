using RPG.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.GameObjects
{
    public class HiddenFloorObject : GameObject
    {
        public HiddenFloorObject(Scene scene) : base(scene)
        {
        }

        public override void Interaction(Player player)
        {
            removeWhenInteract = true;
            Console.SetCursorPosition(0, Console.WindowHeight - 15);
            Console.WriteLine("근처에 무슨 소리가 들립니다. 망치로 부술 수 있는 벽이 있을거 같습니다.");
            Thread.Sleep(1000);
        }
    }
}
