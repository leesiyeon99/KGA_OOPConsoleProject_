using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Items
{
    public class Item
    {
        public string name;
        public ItemType type;
        public string explain;
        public Player player;
        public int cost;


        public class ItemFactory
        {
            public static Item Create(ItemType type)
            {
                if (type == ItemType.Potion)
                {
                    Potion potion = new Potion();
                    potion.name = "체력 포션 (사용) ";
                    potion.explain = "체력이 50 회복되는 포션입니다.";
                    potion.hp = 50;
                    potion.cost = 100;
                    potion.type = ItemType.Potion;
                    return potion;
                }
                else if (type == ItemType.Weapon)
                {
                    Weapon weapon = new Weapon();
                    weapon.name = "철 검 (소유) ";
                    weapon.explain = "공격력이 30 상승하는 검입니다.";
                    weapon.attack = 30;
                    weapon.cost = 300;
                    weapon.type = ItemType.Weapon;
                    return weapon;
                }
                else if (type == ItemType.Armor)
                {
                    Armor armor = new Armor();
                    armor.name = "철 갑옷 세트 (소유) ";
                    armor.explain = "방어력이 30 증가하는 방어구입니다.";
                    armor.defense = 30;
                    armor.cost = 300;
                    armor.type = ItemType.Armor;
                    return armor;
                }
                else if (type == ItemType.RandomPotion)
                {
                    RandomPotion randomPotion = new RandomPotion();
                    randomPotion.name = "랜덤 포션 (사용) ";
                    randomPotion.cost = 500;
                    randomPotion.explain = "랜덤으로 행운을 얻습니다. (0 ~ 100)";
                    Random random = new Random();
                    int randomLuck = random.Next(1, 100);
                    randomPotion.luck = randomLuck;
                    randomPotion.type = ItemType.RandomPotion;
                    return randomPotion;
                }
                else if (type == ItemType.Key)
                {
                    Key key = new Key();
                    key.name = "열쇠";
                    key.cost = 500;
                    key.explain = "어딘가를 열 수 있는 열쇠이다.";
                    key.type = ItemType.Key;
                    return key;
                }
                else if (type == ItemType.Hammer)
                {
                    Hammer hammer = new Hammer();
                    hammer.name = "망치";
                    hammer.cost = 500;
                    hammer.explain = "어딘가를 부술 수 있는 망치이다.";
                    hammer.type = ItemType.Hammer;
                    return hammer;
                }
                else
                {
                    Console.WriteLine("해당 아이템 타입이 없습니다.");
                    return null;
                }
            }
        }
    }
}
