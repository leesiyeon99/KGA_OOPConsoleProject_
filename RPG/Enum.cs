using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public enum SceneType
    {
        Title,
        FirstMap,
        LastMap,
        Battle,
        Inventory,
        ShopMenu,
        ShopPurchase,
        ShopSale,
        GameOver,

        Size
    }
    public enum ItemType { Potion, Weapon, Armor, RandomPotion, Key, Hammer }

    public enum MonsterType { LowGradeZombie, IntermediateZombie, HighGradeZombie, BossZombie }
}
