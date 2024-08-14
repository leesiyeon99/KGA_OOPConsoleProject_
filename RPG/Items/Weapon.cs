using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Items
{
    public class Weapon : Item, IGainable
    {
        public int attack;

        public void Gain(Player user)
        {
            Player.attack += attack;
        }
    }
}
