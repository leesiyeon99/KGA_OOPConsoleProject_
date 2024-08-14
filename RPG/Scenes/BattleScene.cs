using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RPG.Monsters;

namespace RPG.Scenes
{
    public class BattleScene : Scene
    {
        private Player player;
        private Monster monster;
        public BattleScene(Game game) : base(game)
        {
        }

        public void SetBattle(Player player, Monster monster)
        {
            this.player = player;
            this.monster = monster;
        }

        public override void Enter()
        {

        }

        public override void Exit()
        {

        }

        public override void Input()
        {

        }

        public override void Render()
        {

        }

        public override void Update()
        {

        }
    }
}
