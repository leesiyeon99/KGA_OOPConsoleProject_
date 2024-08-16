using RPG.GameObjects;
using RPG.Items;
using RPG.Monsters;

namespace RPG.Scenes
{
    public class FirstScene : Scene
    {
        private char[,] Map;
        private Point playerPos;
        public ConsoleKey inputKey;
        private Player Player;
        private Inventory inventory;
        static public Item Item;
        public Monster monster;

        public List<GameObject> gameObjects;

        public FirstScene(Game game) : base(game)
        {
            Map = new char[,]
           {
                // 0   1   2   3   4   5   6   7   8   9  10  11  12  13  14  15
                { 'f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f'}, //0
                { 'f','t','t','t','f','t','t','t','t','t','t','t','t','f','s','f'}, //1
                { 'f','t','f','f','f','t','f','f','f','f','f','f','t','f','t','f'}, //2
                { 'f','t','f','t','t','t','f','t','t','t','t','t','m','f','t','f'}, //3
                { 'f','t','f','t','f','f','f','t','f','f','f','f','f','f','t','f'}, //4
                { 'f','t','t','t','t','m','f','t','t','t','t','t','t','t','t','f'}, //5
                { 'f','t','f','f','f','f','f','t','f','f','t','f','f','f','t','f'}, //6
                { 'f','t','t','t','t','t','t','t','r','f','t','t','t','f','t','f'}, //7
                { 'f','z','f','f','f','f','f','f','f','f','f','f','z','f','t','f'}, //8
                { 'f','t','t','t','t','k','f','t','t','t','t','t','t','f','m','f'}, //9
                { 'f','f','f','f','f','f','f','f','d','f','f','f','f','f','f','f'}, //10
                { 'f','f','f','f','f','f','f','t','t','t','f','f','f','f','f','f'}, //11
                { 'f','f','f','f','f','f','f','t','t','t','f','f','f','f','f','f'}, //12
                { 'f','f','f','f','f','f','f','t','P','t','f','f','f','f','f','f'}, //13
                { 'f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f'}
           };
            Item = Item.ItemFactory.Create(ItemType.Key);

            Player = new Player(3, 1, Map);
            gameObjects = new List<GameObject>();

            MoneyObject money1 = new MoneyObject(this);
            money1.pos = new Point(5, 5);
            money1.simbol = "M";
            money1.color = ConsoleColor.Yellow;
            gameObjects.Add(money1);


            MoneyObject money2 = new MoneyObject(this);
            money2.pos = new Point(12, 3);
            money2.simbol = "M";
            money2.color = ConsoleColor.Yellow;
            gameObjects.Add(money2);

            MoneyObject money3 = new MoneyObject(this);
            money3.pos = new Point(14, 9);
            money3.simbol = "M";
            money3.color = ConsoleColor.Yellow;
            gameObjects.Add(money3);

            KeyObject key = new KeyObject(this);
            key.pos = new Point(5, 9);
            key.simbol = "K";
            key.color = ConsoleColor.DarkYellow;
            gameObjects.Add(key);

            PrincessObject princess = new PrincessObject(this);
            princess.pos = new Point(8, 13);
            princess.simbol = "P";
            princess.color = ConsoleColor.Magenta;
            gameObjects.Add(princess);

            RestRoomObject restRoom = new RestRoomObject(this);
            restRoom.pos = new Point(8, 7);
            restRoom.simbol = "R";
            restRoom.color = ConsoleColor.Blue;
            gameObjects.Add(restRoom);

            DoorObject door = new DoorObject(this);
            door.pos = new Point(8, 10);
            door.simbol = "D";
            door.color = ConsoleColor.Gray;
            gameObjects.Add(door);

            ShopObject shop = new ShopObject(this);
            shop.pos = new Point(14, 1);
            shop.simbol = "S";
            shop.color = ConsoleColor.Cyan;
            gameObjects.Add(shop);

            MonsterObject monster1 = new MonsterObject(this, monster);
            monster1.pos = new Point(1, 8);
            monster1.simbol = "Z";
            monster1.color = ConsoleColor.Red;
            gameObjects.Add(monster1);

            MonsterObject monster2 = new MonsterObject(this, monster);
            monster2.pos = new Point(12, 8);
            monster2.simbol = "Z";
            monster2.color = ConsoleColor.Red;
            gameObjects.Add(monster2);

        }

        private void PrintMap()
        {
            Console.Clear();
            for (int x = 0; x < Map.GetLength(0); x++)
            {
                for (int y = 0; y < Map.GetLength(1); y++)
                {
                    if (Map[x, y] == 'f')
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, Console.WindowHeight - 15);
            Console.WriteLine("인벤토리 열기: E");
        }

        public override void Enter()
        {

        }

        public override void Exit()
        {

        }

        public override void Input()
        {
            inputKey = Console.ReadKey(true).Key;
        }

        public override void Render()
        {
            PrintMap();
            PrintPlayer();
            PrintGameObject();
            game.MapChange(this);
        }

        public void PrintPlayer()
        {
            Console.SetCursorPosition(Player.playerPos.x, Player.playerPos.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("P");
            Console.ResetColor();
        }

        private void PrintGameObject()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                Console.SetCursorPosition(gameObject.pos.x, gameObject.pos.y);
                Console.ForegroundColor = gameObject.color;
                Console.Write(gameObject.simbol);
                Console.ResetColor();
            }
        }

        private void OpenInventory()
        {
            if (inputKey == ConsoleKey.E)
            {
                game.ChangeScene(SceneType.Inventory);
            }
        }

        public override void Update()
        {
            Player.MovePlayer(inputKey);
            Interaction();
            OpenInventory();
        }

        private void Interaction()
        {

            foreach (GameObject gameObject in gameObjects)
            {
                if (gameObject.removeWhenInteract)
                {
                    gameObjects.Remove(gameObject);
                    return;
                }

                if (Player.playerPos.x == gameObject.pos.x &&
                    Player.playerPos.y == gameObject.pos.y)
                {
                    gameObject.Interaction(Player);
                    return;
                }
            }
        }
    }
}
