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

        Size
    }
    public enum ItemType { Potion, Weapon, Armor, RandomPotion, Key }

    public enum MonsterType { LowGradeZombie, IntermediateZombie, HighGradeZombie, BossZombie }
}
