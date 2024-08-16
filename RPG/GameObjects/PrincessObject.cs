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
            Render();
            Player.playerPos.x = 2;
            Player.playerPos.y = 1;
            game.ChangeScene(SceneType.LastMap);
            removeWhenInteract = false;
        }

        public void Render()
        {
            Console.Clear();
            Console.WriteLine("축하합니다 공주를 구출하셨습니다!!");
            Console.WriteLine("공주와 함께 미로를 탈출해봅시다!");
            Thread.Sleep(1000);
            Console.WriteLine("다음맵으로 이동 중...");
            Thread.Sleep(1000);
        }
    }
}
