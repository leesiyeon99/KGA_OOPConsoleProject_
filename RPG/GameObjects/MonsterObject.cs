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
        public MonsterObject(Scene scene, Monster _monster) : base(scene)
        {
            monster = _monster;
        }

        public override void Interaction(Player player)
        {
            game.StartBattle(this);
            Console.Clear();
            Console.WriteLine("****************************");
            Console.WriteLine("     몬스터를 만났습니다.      ");
            Console.WriteLine("****************************");
            Thread.Sleep(1000);
        }
    }
}
