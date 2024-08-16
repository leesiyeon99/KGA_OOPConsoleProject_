using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Monsters
{
    public class IntermediateZombie : Monster
    {
        public override void Skill()
        {
            Console.WriteLine("철 검으로 공격!");
        }
    }
}
