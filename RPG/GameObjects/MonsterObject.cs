using RPG.Monsters;
using RPG.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.GameObjects
{
    public class MonsterObject : GameObject
    {
        Monster monster;
        BattleScene BattleScene;
        public MonsterObject(Scene scene) : base(scene)
        {
            BattleScene = new BattleScene(game);
        }

        public override void Interaction(Player player)
        {
            game.StartBattle(monster);
        }
    }
}
