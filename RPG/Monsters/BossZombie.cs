﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Monsters
{
    public class BossZombie : Monster
    {
        public override void Skill()
        {
            Console.WriteLine("쌍철검으로 공격");
        }
    }
}
