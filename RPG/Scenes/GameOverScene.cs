using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Scenes
{
    public class GameOverScene : Scene
    {
        public GameOverScene(Game game) : base(game)
        {
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("=                                  =");
            Console.WriteLine("=           게임 클리어!           =");
            Console.WriteLine("=                                  =");
            Console.WriteLine("====================================");
            Console.WriteLine();
        }

        public override void Input()
        {

        }

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine("축하합니다 탈출하셨습니다.");
            Thread.Sleep(1000);
        }

        public override void Update()
        {
            game.Over();
        }
    }
}
