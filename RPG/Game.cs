﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RPG.GameObjects;
using RPG.Monsters;
using RPG.Scenes;
using static System.Formats.Asn1.AsnWriter;

namespace RPG
{
    public class Game
    {
        private bool isRunning;

        private Scene[] scenes;
        private Scene curScene;
        private Scene prevScene;
        public Scene CurScene { get { return curScene; } }

        private Player player;
        public Player Player { get { return player; } set { player = value; } }

        public void Run()
        {
            Console.CursorVisible = false;
            Start();
            while (isRunning)
            {
                Render();
                Input();
                Update();
            }
            End();
        }

        public void ChangeScene(SceneType sceneType)
        {
            curScene.Exit();
            curScene = scenes[(int)sceneType];
            curScene.Enter();
        }

        public void ReturnScene()
        {
            curScene.Exit();
            curScene = prevScene;
            curScene.Enter();
        }
        public void MapChange(Scene scene)
        {
            curScene = scene;
            prevScene = curScene;
        }

        public void StartBattle(MonsterObject monsterObject)
        {
            prevScene = curScene;
            curScene.Exit();
            curScene = scenes[(int)SceneType.Battle];
            BattleScene battleScene = (BattleScene)curScene;
            battleScene.SetBattle(player, monsterObject);
            curScene.Enter();

        }

        public void Over()
        {
            isRunning = false;
        }

        private void Start()
        {
            isRunning = true;

            scenes = new Scene[(int)SceneType.Size];
            scenes[(int)SceneType.Title] = new TitleScene(this);
            scenes[(int)SceneType.Battle] = new BattleScene(this);
            scenes[(int)SceneType.Inventory] = new InventoryScene(this);
            scenes[(int)SceneType.ShopMenu] = new ShopMenuScene(this);
            scenes[(int)SceneType.ShopPurchase] = new ShopPurchaseScene(this);
            scenes[(int)SceneType.ShopSale] = new ShopSaleScene(this);
            scenes[(int)SceneType.FirstMap] = new FirstScene(this);
            scenes[(int)SceneType.LastMap] = new LastScene(this); 
            scenes[(int)SceneType.GameOver] = new GameOverScene(this); 

            prevScene = scenes[(int)SceneType.GameOver];
            curScene = scenes[(int)SceneType.Title];
            curScene.Enter();
        }

        private void End()
        {
            curScene.Exit();
        }

        private void Render()
        {
            curScene.Render();
        }

        private void Input()
        {
            curScene.Input();
        }

        private void Update()
        {
            curScene.Update();
        }
    }
}
