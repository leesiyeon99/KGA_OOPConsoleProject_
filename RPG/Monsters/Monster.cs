using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Monsters
{
    public abstract class Monster
    {
        public string name;
        public int hp;
        public int attack;
        public int defense;
        public string explain;
        public int cost;
        public MonsterType monsterType;

        public abstract void Skill();
        public class MonsterFactory
        {
            public static Monster Create(MonsterType monsterType)
            {
                if (monsterType == MonsterType.LowGradeZombie)
                {
                    LowGradeZombie lowGradeZombie = new LowGradeZombie();
                    lowGradeZombie.name = "하급 좀비";
                    lowGradeZombie.attack = 5;
                    lowGradeZombie.defense = 10;
                    lowGradeZombie.hp = 30;
                    lowGradeZombie.cost = 300;
                    lowGradeZombie.explain = "기본 검을 사용하는 약한 좀비입니다.";
                    lowGradeZombie.monsterType = MonsterType.LowGradeZombie;
                    return lowGradeZombie;
                }
                else if (monsterType == MonsterType.IntermediateZombie)
                {
                    IntermediateZombie intermediateZombie = new IntermediateZombie();
                    intermediateZombie.name = "중급 좀비";
                    intermediateZombie.attack = 15;
                    intermediateZombie.defense = 20;
                    intermediateZombie.hp = 70;
                    intermediateZombie.cost = 500;
                    intermediateZombie.explain = "철 검을 사용하는 좀비입니다. 체력이 많습니다.";
                    intermediateZombie.monsterType = MonsterType.IntermediateZombie;
                    return intermediateZombie;
                }
                else if (monsterType == MonsterType.HighGradeZombie)
                {
                    HighGradeZombie highGradeZombie = new HighGradeZombie();
                    highGradeZombie.name = "상급 좀비";
                    highGradeZombie.attack = 25;
                    highGradeZombie.defense = 25;
                    highGradeZombie.hp = 100;
                    highGradeZombie.cost = 800;
                    highGradeZombie.explain = "강한 원거리 마법 공격을 합니다.";
                    highGradeZombie.monsterType = MonsterType.HighGradeZombie;
                    return highGradeZombie;
                }
                else if (monsterType == MonsterType.BossZombie)
                {
                    BossZombie bossZombie = new BossZombie();
                    bossZombie.name = "보스 좀비";
                    bossZombie.attack = 50;
                    bossZombie.defense = 30;
                    bossZombie.hp = 250;
                    bossZombie.cost = 1500;
                    bossZombie.explain = "쌍철검을 사용합니다. 공격력, 방어력, 체력이 모두 높습니다.";
                    bossZombie.monsterType = MonsterType.BossZombie;
                    return bossZombie;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
