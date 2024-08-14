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
        public MonsterObject(Scene scene) : base(scene)
        {
        }

        public override void Interaction(Player player)
        {
            game.StartBattle(monster);
        }
    }
}
