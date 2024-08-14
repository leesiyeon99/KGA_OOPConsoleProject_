using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using RPG.Scenes;

namespace RPG.GameObjects
{
    public abstract class GameObject : IInteractable
    {
        public Game game;
        public Scene scene;

        public ConsoleColor color;
        public Point pos;
        public string simbol;
        public bool removeWhenInteract;

        public GameObject(Scene scene)
        {
            game = scene.game;
            this.scene = scene;
        }

        public abstract void Interaction(Player player);
    }
}
