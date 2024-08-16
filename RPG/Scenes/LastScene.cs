using RPG.GameObjects;
using RPG.Items;
using RPG.Monsters;

namespace RPG.Scenes
{
    public class LastScene : Scene
    {
        private char[,] Map;
        private Point playerPos;
        public ConsoleKey inputKey;
        private Player Player;
        private Inventory inventory;
        static public Item Item;
        public Monster Monster;
        public MonsterObject[] monsterObjects;

        public List<GameObject> gameObjects;
        public LastScene(Game game) : base(game)
        {
            Map = new char[,]
            {
                // 0   1   2   3   4   5   6   7   8   9  10  11  12  13  14  15
                { 'f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f'}, //0
                { 'f','t','p','t','f','t','f','e','t','t','t','f','t','t','t','f'}, //1
                { 'f','t','t','t','f','t','f','f','f','f','b','f','t','h','t','f'}, //2
                { 'f','t','t','t','f','t','f','t','t','t','t','f','t','t','t','f'}, //3
                { 'f','t','t','t','f','t','t','t','f','f','f','f','t','t','t','f'}, //4
                { 'f','t','t','t','f','f','f','t','m','t','t','f','t','t','t','f'}, //5
                { 'f','s','s','s','t','t','f','t','f','f','t','f','t','t','t','f'}, //6
                { 'f','t','t','t','f','t','f','t','f','r','t','f','t','t','t','f'}, //7
                { 'f','t','t','t','f','t','f','f','f','f','t','f','t','t','t','f'}, //8
                { 'f','t','t','t','f','t','t','t','t','t','t','f','t','t','t','f'}, //9
                { 'f','t','t','t','f','f','f','f','f','f','f','f','t','t','t','f'}, //10
                { 'f','t','t','t','t','t','t','t','t','t','t','t','t','t','t','f'}, //11
                { 'f','t','s','t','t','t','t','t','t','t','t','t','t','t','t','f'}, //12
                { 'f','t','t','t','t','t','t','t','t','t','t','t','t','t','t','f'}, //13
                { 'f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f'}
            };
            Item = Item.ItemFactory.Create(ItemType.Hammer);

            Player = new Player(2, 1, Map);
            gameObjects = new List<GameObject>();

            HiddenFloorObject hiddenFloor1 = new HiddenFloorObject(this);
            hiddenFloor1.pos = new Point(1, 6);
            hiddenFloor1.simbol = " ";
            gameObjects.Add(hiddenFloor1);

            HiddenFloorObject hiddenFloor2 = new HiddenFloorObject(this);
            hiddenFloor2.pos = new Point(2, 6);
            hiddenFloor2.simbol = " ";
            gameObjects.Add(hiddenFloor2);

            HiddenFloorObject hiddenFloor3 = new HiddenFloorObject(this);
            hiddenFloor3.pos = new Point(3, 6);
            hiddenFloor3.simbol = " ";
            gameObjects.Add(hiddenFloor3);

            HiddenWallObject hiddenWall = new HiddenWallObject(this);
            hiddenWall.pos = new Point(4, 6);
            hiddenWall.simbol = "#";
            hiddenWall.color = ConsoleColor.White;
            gameObjects.Add(hiddenWall);

            HammerObject hammer = new HammerObject(this);
            hammer.pos = new Point(13, 2);
            hammer.simbol = "H";
            hammer.color = ConsoleColor.Yellow;
            gameObjects.Add(hammer);

            ShopObject shop = new ShopObject(this);
            shop.pos = new Point(2, 12);
            shop.simbol = "S";
            shop.color = ConsoleColor.Cyan;
            gameObjects.Add(shop);

            MonsterObject monster1 = new MonsterObject(this, Monster);
            monster1.pos = new Point(8, 5);
            monster1.simbol = "Z";
            monster1.color = ConsoleColor.Red;
            gameObjects.Add(monster1);

            MonsterObject monster2 = new MonsterObject(this, Monster);
            monster2.pos = new Point(10, 2);
            monster2.simbol = "B";
            monster2.color = ConsoleColor.Red;
            gameObjects.Add(monster2);

            RestRoomObject restRoom = new RestRoomObject(this);
            restRoom.pos = new Point(9, 7);
            restRoom.simbol = "R";
            restRoom.color = ConsoleColor.Blue;
            gameObjects.Add(restRoom);

            EscapeObject escape = new EscapeObject(this);
            escape.pos = new Point(7, 1);
            escape.simbol = "E";
            escape.color = ConsoleColor.DarkRed;
            gameObjects.Add(escape);
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
        public void PrintPlayer()
        {
            Console.SetCursorPosition(Player.playerPos.x, Player.playerPos.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("P");
            Console.ResetColor();
        }
        public override void Render()
        {
            PrintMap();
            PrintGameObject();
            PrintPlayer();
            game.MapChange(this);
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

        public override void Update()
        {
            Player.MovePlayer(inputKey);            
            Interaction();
            OpenInventory();

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
