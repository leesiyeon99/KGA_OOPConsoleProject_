using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Scenes
{
    internal class InventoryScene : Scene
    {
        static public Inventory Inventory;
        public Player Player;
        public ConsoleKey inputKey;
        public int inputValue;
        public InventoryScene(Game game) : base(game)
        {
            Inventory = new Inventory();
            Player = new Player();
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
        }

        public override void Input()
        {
            inputKey = Console.ReadKey().Key;
            Console.WriteLine();
            inputValue = (int)inputKey - (int)ConsoleKey.D0;
        }

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine("****************************");
            Console.WriteLine("*         인벤토리         *");
            Console.WriteLine("****************************");
            Console.WriteLine();
            Player.ShowState();
            Console.WriteLine();
            Inventory.ShowAllItem();
            Console.WriteLine();
            Console.Write("사용할 아이템을 선택하세요 (뒤로가기 0) : ");
        }

        public override void Update()
        {
            if (inputKey == ConsoleKey.D0)
            {
                game.ReturnScene();
            }
            else if (1 <= inputValue && inputValue <= Inventory.items.Count)
            {
                Player.UseItem(Inventory.items[inputValue - 1]);
            }
            else
            {
                Console.WriteLine("잘못입력했습니다.");
                Thread.Sleep(1000);
            }
        }
    }
}
