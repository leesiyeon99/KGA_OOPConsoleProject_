using RPG.Items;

namespace RPG.Scenes
{
    public class ShopMenuScene : Scene
    {
        public ConsoleKey inputKey;
        Game Game;
        public ShopMenuScene(Game game) : base(game)
        {

        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
            if (Player.playerPos.x == 14 &&  Player.playerPos.y == 1 || Player.playerPos.x == 14 && Player.playerPos.y == 2)
            {
                Player.playerPos.x = 14;
                Player.playerPos.y = 2;
            }
            else
            {
                Player.playerPos.x = 2;
                Player.playerPos.y = 11;
            }

        }

        public override void Input()
        {
            inputKey = Console.ReadKey().Key;
        }

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine("****************************");
            Console.WriteLine("*        아이템 상점       *");
            Console.WriteLine("****************************");
            Console.WriteLine();
            Console.WriteLine($"플레이어 현재 골드: {Player.money}");
            Console.WriteLine("========= 상점 메뉴 =========");
            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine();
            Console.Write("메뉴를 선택하세요(뒤로가기 0) : ");
        }

        public override void Update()
        {
            if (inputKey == ConsoleKey.D1)
            {
                game.ChangeScene(SceneType.ShopPurchase);
            }
            else if (inputKey == ConsoleKey.D2)
            {
                game.ChangeScene(SceneType.ShopSale);
            }
            else if (inputKey == ConsoleKey.D0)
            {
                if (Player.playerPos.x == 14 && Player.playerPos.y == 2 || Player.playerPos.x == 14 && Player.playerPos.y == 1)
                {
                    game.ChangeScene(SceneType.FirstMap);
                }
                else
                {
                    game.ChangeScene(SceneType.LastMap);
                }
                    
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("잘못입력하셨습니다.");
                Thread.Sleep(1000);
            }
        }

    }
}
