namespace RPG.Scenes
{
    public class ShopSaleScene : Scene
    {
        public ConsoleKey inputKey;
        public int inputValue;
        Inventory inventory;
        public ShopSaleScene(Game game) : base(game)
        {
            inventory = new Inventory();
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
            Console.WriteLine("*        아이템 판매       *");
            Console.WriteLine("****************************");
            Console.WriteLine();
            Console.WriteLine($"플레이어 현재 골드: {Player.money}");
            Console.WriteLine("======= 인벤토리 목록 =======");
            Console.WriteLine();
            inventory.ShowAllItem();
            Console.WriteLine();
            Console.Write("메뉴를 선택하세요(뒤로가기 0) : ");
        }

        public override void Update()
        {
            if (inputKey == ConsoleKey.D0)
            {
                game.ChangeScene(SceneType.ShopMenu);
            }
            Sell();
        }

        public void Sell()
        {
            if (Inventory.items.Count > 0)
            {
                Player.money += Inventory.items[inputValue - 1].cost;
                Console.WriteLine($"{Inventory.items[inputValue - 1].name}을 판매하셨습니다. {Inventory.items[inputValue - 1].cost}를 얻었습니다.");
                Thread.Sleep(1000);
                Inventory.items.RemoveAt(inputValue - 1);
            }
            else
            {
                return;
            }
        }
    }
}
