using RPG.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.GameObjects
{
    public class Key : GameObject
    {
        public string name;
        public ItemType type;
        public string explain;
        public Player player;
        public int cost;
        public Key(Scene scene) : base(scene)
        {
            player = new Player();
            name = "열쇠";
            type = ItemType.Key;
            explain = "어딘가를 열 수 있는 열쇠다";
            cost = 0;
        }

        public override void Interaction(Player player)
        {

        }
    }
}
