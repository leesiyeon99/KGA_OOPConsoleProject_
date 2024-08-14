using RPG.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.GameObjects
{
    public class Money : GameObject
    {
        public Player player;
        public Money(Scene scene) : base(scene)
        {
            player = new Player();
        }

        public override void Interaction(Player player)
        {
            this.player.GetMoney();
        }
    }
}
