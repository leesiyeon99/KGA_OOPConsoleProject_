using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Items
{
    public class RandomPotion : Item, IUseable
    {
        public int luck;

        public void Use(Player player)
        {
            Random random = new Random();
            luck = random.Next(1, 100);
            Player.lucky += luck;
            Console.WriteLine($"행운이 {luck}만큼 증가했습니다. 현재 행운은{Player.lucky}입니다.");
            Thread.Sleep(1000);
        }
    }
}
