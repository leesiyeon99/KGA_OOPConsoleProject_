using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Monsters
{
    public class HighGradeZombie : Monster
    {
        public override void Skill()
        {
            Console.WriteLine("원거리 마법 공격!");
        }
    }
}
