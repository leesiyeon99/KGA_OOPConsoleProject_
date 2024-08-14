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
            Input();
            Update();
        }

        public void Render()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 15);
            Console.WriteLine("문이 잠겨있습니다. 문을 열 방법을 선택해주세요");
            Console.WriteLine("1. 열쇠로 열기");
            Console.WriteLine("2. 그냥 열어보기");
            Console.WriteLine("3. 뒤로가기");
        }

        public void Input()
        {
            inputKey = Console.ReadKey(true).Key;
        }

        public void Update()
        {

        }
    }
}
