using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Items
{
    public class Potion : Item, IUseable
    {
        public int hp;

        public void Use(Player player)
        {
            Player.hp += hp;
            if (Player.hp >= 100)
            {
                Player.hp = 100;
            }
            Console.WriteLine($"체력이 회복 됐습니다. 현재 체력은 {Player.hp}입니다.");
            Thread.Sleep(1000);
        }
    }
}
