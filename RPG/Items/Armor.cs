using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Items
{
    public class Armor : Item, IGainable
    {
        public int defense;

        public void Gain(Player user)
        {
            player.defense += defense;
        }
    }
}
