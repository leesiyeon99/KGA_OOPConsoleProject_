using RPG.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.GameObjects
{
    public class PrincessObject : GameObject
    {
        public PrincessObject(Scene scene) : base(scene)
        {
        }

        public override void Interaction(Player player)
        {
            game.ChangeScene(SceneType.LastMap);
        }
    }
}
