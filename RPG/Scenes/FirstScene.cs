﻿using RPG.GameObjects;

namespace RPG.Scenes
{
    public class FirstScene : Scene
    {
        private char[,] Map;
        private Point playerPos;
        public ConsoleKey inputKey;
        private Player Player;

        private List<GameObject> gameObjects;

        private ConsoleKey input;
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
                { 'f','t','t','t','t','t','t','t','h','f','t','t','t','f','t','f'}, //7
                { 'f','t','f','f','f','f','f','f','f','f','f','f','t','f','t','f'}, //8
                { 'f','t','t','t','t','k','f','t','t','t','t','t','t','f','m','f'}, //9
                { 'f','f','f','f','f','f','f','f','d','f','f','f','f','f','f','f'}, //10
                { 'f','f','f','f','f','f','f','t','t','t','f','f','f','f','f','f'}, //11
                { 'f','f','f','f','f','f','f','t','t','t','f','f','f','f','f','f'}, //12
                { 'f','f','f','f','f','f','f','t','P','t','f','f','f','f','f','f'}, //13
                { 'f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f'}
           };

            Player = new Player(3, 1, Map);
            gameObjects = new List<GameObject>();

            Money money1 = new Money(this);
            money1.pos = new Point(5, 5);
            money1.simbol = "M";
            money1.color = ConsoleColor.Yellow;
            money1.removeWhenInteract = true;
            gameObjects.Add(money1);


            Money money2 = new Money(this);
            money2.pos = new Point(12, 3);
            money2.simbol = "M";
            money2.color = ConsoleColor.Yellow;
            money2.removeWhenInteract = true;
            gameObjects.Add(money2);

            Money money3 = new Money(this);
            money3.pos = new Point(14, 9);
            money3.simbol = "M";
            money3.color = ConsoleColor.Yellow;
            money3.removeWhenInteract = true;
            gameObjects.Add(money3);

            Key key = new Key(this);
            key.pos = new Point(5, 9);
            key.simbol = "K";
            key.color = ConsoleColor.DarkYellow;
            key.removeWhenInteract = true;
            gameObjects.Add(key);
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

        public override void Update()
        {
            Player.MovePlayer(inputKey);
            Interaction();
        }

        private void Interaction()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                if (Player.playerPos.x == gameObject.pos.x &&
                    Player.playerPos.y == gameObject.pos.y)
                {
                    gameObject.Interaction(game.Player);
                    if (gameObject.removeWhenInteract)
                    {
                        gameObjects.Remove(gameObject);
                    }
                    return;
                }
            }
        }
    }
}
