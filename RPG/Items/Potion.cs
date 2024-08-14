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
            player.hp += hp;
            if (player.hp >= 100)
            {
                player.hp = 100;
            }
            Console.WriteLine($"체력이 회복 됐습니다. 현재 체력은 {player.hp}입니다.");
            Thread.Sleep(1000);
        }
    }
}
