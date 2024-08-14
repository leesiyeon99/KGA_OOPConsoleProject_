namespace RPG.Scenes
{
    public class LastScene : Scene
    {
        private char[,] Map;
        public ConsoleKey inputKey;
        public LastScene(Game game) : base(game)
        {
            Map = new char[,]
            {
                // 0   1   2   3   4   5   6   7   8   9  10  11  12  13  14  15
                { 'f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f'}, //0
                { 'f','t','p','t','f','s','f','e','t','t','t','f','t','t','t','f'}, //1
                { 'f','t','t','t','f','t','f','f','f','f','b','f','t','h','t','f'}, //2
                { 'f','t','t','t','f','t','f','t','t','t','t','f','t','t','t','f'}, //3
                { 'f','t','t','t','f','t','t','t','f','f','f','f','t','t','t','f'}, //4
                { 'f','t','t','t','f','f','f','t','m','t','t','f','t','t','t','f'}, //5
                { 'f','s','s','s','t','t','f','t','f','f','t','f','t','t','t','f'}, //6
                { 'f','t','t','t','f','t','f','t','t','f','t','f','t','t','t','f'}, //7
                { 'f','t','t','t','f','t','f','f','f','f','t','f','t','t','t','f'}, //8
                { 'f','t','t','t','f','t','t','t','t','t','t','f','t','t','t','f'}, //9
                { 'f','t','t','t','f','f','f','f','f','f','f','f','t','t','t','f'}, //10
                { 'f','t','t','t','t','t','t','t','t','t','t','t','t','t','t','f'}, //11
                { 'f','t','t','t','t','t','t','t','t','t','t','t','t','t','t','f'}, //12
                { 'f','t','t','t','t','t','t','t','t','t','t','t','t','t','t','f'}, //13
                { 'f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f'}
            };
        }

        public override void Enter()
        {
            Console.Clear();
            Console.WriteLine("다음 맵으로 이동합니다...");
            Thread.Sleep(1000);
            game.MapChange(this);
        }

        public override void Exit()
        {
            throw new NotImplementedException();
        }

        public override void Input()
        {
            inputKey = Console.ReadKey(true).Key;
        }

        public override void Render()
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
            throw new NotImplementedException();
        }
    }
}
