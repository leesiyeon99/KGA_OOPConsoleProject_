using RPG.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static RPG.Scenes.ShopMenuScene;

namespace RPG.Scenes
{
    public class ShopPurchaseScene : Scene
    {
        Item[] items = new Item[4];
        public Inventory Inventory;
        public Player player;
        public ConsoleKey inputKey;
        public ShopPurchaseScene(Game game) : base(game)
        {
            player = new Player();
            Inventory = new Inventory();
            items[0] = Item.ItemFactory.Create(ItemType.Potion);
            items[1] = Item.ItemFactory.Create(ItemType.Weapon);
            items[2] = Item.ItemFactory.Create(ItemType.Armor);
            items[3] = Item.ItemFactory.Create(ItemType.RandomPotion);
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
        }

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine("****************************");
            Console.WriteLine("*        아이템 구매       *");
            Console.WriteLine("****************************");
            Console.WriteLine();
            Console.WriteLine($"플레이어 현재 골드: {Player.money}");
            Console.WriteLine("========= 상점 메뉴 =========");
            Console.WriteLine();
            Console.WriteLine($"1. {items[0].name} ({items[0].cost})");
            Console.WriteLine($"   {items[0].explain}");
            Console.WriteLine($"2. {items[1].name} ({items[1].cost})");
            Console.WriteLine($"   {items[1].explain}");
            Console.WriteLine($"3. {items[2].name} ({items[2].cost})");
            Console.WriteLine($"   {items[2].explain}");
            Console.WriteLine($"4. {items[3].name} ({items[3].cost})");
            Console.WriteLine($"   {items[3].explain}");
            Console.WriteLine();
            Console.Write("메뉴를 선택하세요(뒤로가기 0) : ");
        }

        public override void Update()
        {
            Purchase();
        }

        public void Purchase()
        {
            Item item = null;
            switch (inputKey)
            {
                case ConsoleKey.D0:
                    game.ChangeScene(SceneType.ShopMenu);
                    return;
                case ConsoleKey.D1:
                    item = items[0];
                    break;
                case ConsoleKey.D2:
                    item = items[1];
                    break;
                case ConsoleKey.D3:
                    item = items[2];
                    break;
                case ConsoleKey.D4:
                    item = items[3];
                    break;
                default:
                    Console.WriteLine("잘못 입력하셨습니다.");
                    break;
            }

            if (Player.money < item.cost)
            {
                Console.WriteLine("플레이어의 골드가 충분하지 않습니다.");
                Thread.Sleep(1000);
                return;
            }

            if (player.GainItem(item) == false)
            {
                Console.WriteLine("아이템이 가득차서 살 수 없습니다.");
                Thread.Sleep(2000);
                return;
            }

            player.LoseGold(item.cost);
            Console.WriteLine($"{item.name} 을 구매합니다.");
            Console.WriteLine($"보유한 골드가 {item.cost} 감소하여 {Player.money}가 됩니다.");
            Thread.Sleep(2000);

        }

    }
}
