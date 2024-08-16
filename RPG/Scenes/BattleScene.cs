using RPG.GameObjects;
using RPG.Monsters;

namespace RPG.Scenes
{
    public class BattleScene : Scene
    {
        private Player player;
        public Monster[] monsters;
        private Monster _monster;
        private ConsoleKey inputKey;
        MonsterObject monsterObject;
        public BattleScene(Game game) : base(game)
        {
            monsterObject = new MonsterObject(this, _monster);

            monsters = new Monster[4];
            monsters[0] = Monster.MonsterFactory.Create(MonsterType.LowGradeZombie);
            monsters[1] = Monster.MonsterFactory.Create(MonsterType.IntermediateZombie);
            monsters[2] = Monster.MonsterFactory.Create(MonsterType.HighGradeZombie);
            monsters[3] = Monster.MonsterFactory.Create(MonsterType.BossZombie);
        }

        public void SetBattle(Player player, MonsterObject monsterObject)
        {
            this.player = player;
            this.monsterObject = monsterObject;
        }

        public override void Enter()
        {

        }

        public override void Exit()
        {

        }

        public override void Input()
        {
            inputKey = Console.ReadKey().Key;
            Console.WriteLine();
        }

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine("****************************");
            Console.WriteLine("*        몬스터 발견       *");
            Console.WriteLine("****************************");
            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("플레이어 정보 ");
            Console.WriteLine($" 체력 : {Player.hp} / {100}  공격 : {Player.attack} / 방어 : {Player.defense}");
            Console.WriteLine("==========================================");
            Console.WriteLine("몬스터 정보 ");
            if (Player.playerPos.x == 1 && Player.playerPos.y == 8)
            {
                _monster = monsters[0];
                Console.WriteLine($" 이름: {monsters[0].name}");
                Console.WriteLine($" 설명: {monsters[0].explain}");
                Console.WriteLine($" 체력 : {monsters[0].hp} / {30}  공격 : {monsters[0].attack} / 방어 : {monsters[0].defense}");
            }
            else if (Player.playerPos.x == 12 && Player.playerPos.y == 8)
            {
                _monster = monsters[1];
                Console.WriteLine($" 이름: {monsters[1].name}");
                Console.WriteLine($" 설명: {monsters[1].explain}");
                Console.WriteLine($" 체력 : {monsters[1].hp} / {70}  공격 : {monsters[1].attack} / 방어 : {monsters[1].defense}");
            }
            else if (Player.playerPos.x == 8 && Player.playerPos.y == 5)
            {
                _monster = monsters[2];
                Console.WriteLine($" 이름: {monsters[2].name}");
                Console.WriteLine($" 설명: {monsters[2].explain}");
                Console.WriteLine($" 체력 : {monsters[2].hp} / {100}  공격 : {monsters[2].attack} / 방어 : {monsters[2].defense}");
            }
            else if (Player.playerPos.x == 10 && Player.playerPos.y == 2)
            {
                _monster = monsters[3];
                Console.WriteLine($" 이름: {monsters[3].name}");
                Console.WriteLine($" 설명: {monsters[3].explain}");
                Console.WriteLine($" 체력 : {monsters[3].hp} / {150}  공격 : {monsters[3].attack} / 방어 : {monsters[3].defense}");
            }
            Console.WriteLine();
            Console.WriteLine("1. 싸우기");
            Console.WriteLine("2. 도망치기");
            Console.WriteLine();
            Console.Write("원하는 선택지를 입력해주세요 : ");

        }

        public override void Update()
        {
            if (inputKey == ConsoleKey.D1)
            {
                Console.WriteLine("플레이어가 공격합니다.");
                Thread.Sleep(800);
                PlayerAttack();
                if (MonsterDied()) return;

                Console.WriteLine("몬스터가 공격합니다.");
                _monster.Skill();
                Thread.Sleep(800);
                if (PlayerVoid()) { return; }
                MonsterAttack();
                PlayerDied();
            }
            else if (inputKey == ConsoleKey.D2)
            {
                PlayerPos();
                Run();
                game.ReturnScene();
            }
            else
            {
                Console.WriteLine("잘못 입력하셨습니다.");
            }
        }

        public void MonsterAttack()
        {
            int damageToDefense = Math.Min(Player.defense, _monster.attack);
            Player.defense -= damageToDefense;
            if (Player.defense <= 0)
            {
                Player.defense = 0;
                int remainingDamage = _monster.attack - damageToDefense;
                Player.hp -= remainingDamage;
                Console.WriteLine($"플레이어가 {remainingDamage}의 데미지를 입었습니다.");
            }
            else
            {
                Console.WriteLine($"플레이어의 방어력이 {damageToDefense}만큼 공격을 막았습니다.");
            }
            Thread.Sleep(1000);
        }

        public void PlayerAttack()
        {
            int damageToDefense = Math.Min(_monster.defense, Player.attack);
            _monster.defense -= damageToDefense;

            if (_monster.defense <= 0)
            {
                _monster.defense = 0;
                int remainingDamage = Player.attack - damageToDefense;
                _monster.hp -= remainingDamage;
                Console.WriteLine($"몬스터가 {remainingDamage}의 데미지를 입었습니다.");
            }
            else
            {
                Console.WriteLine($"몬스터의 방어력이 {damageToDefense}만큼 공격을 막았습니다.");
            }
            Thread.Sleep(1000);
        }

        public bool PlayerDied()
        {
            if (Player.hp <= 0)
            {
                Console.Clear();
                PlayerPos();
                Player.money -= 500;
                if (Player.money < 0) { Player.money = 0; }
                Player.hp = 1;
                Console.WriteLine("플레이어가 죽었습니다. 500원을 잃었습니다.");
                Thread.Sleep(2000);
                game.ReturnScene();
                return true;
            }
            return false;
        }

        public bool MonsterDied()
        {
            if (_monster.hp <= 0 && Player.hp > 0)
            {
                Console.Clear();
                Player.money += _monster.cost;
                Console.WriteLine("*******************************************");
                Console.WriteLine($"축하합니다. {_monster.name}을/를 죽였습니다. ");
                Console.WriteLine($"전투에서 승리하셨습니다! {_monster.cost}원을 얻었습니다.");
                Console.WriteLine("*******************************************");
                Thread.Sleep(2000);
                monsterObject.removeWhenInteract = true;
                game.ReturnScene();
                return true;
            }
            return false;
        }

        public void Run()
        {
            Console.Clear();
            Console.WriteLine("도망치는 중입니다...");
            Thread.Sleep(1000);
        }

        public void PlayerPos()
        {
            if (Player.playerPos.x == 1 && Player.playerPos.y == 8)
            {
                Player.playerPos.x = 1;
                Player.playerPos.y = 7;
            }
            else if (Player.playerPos.x == 12 && Player.playerPos.y == 8)
            {
                Player.playerPos.x = 12;
                Player.playerPos.y = 7;
            }
            else if (Player.playerPos.x == 8 && Player.playerPos.y == 5)
            {
                Player.playerPos.x = 9;
                Player.playerPos.y = 5;

            }
            else if (Player.playerPos.x == 10 && Player.playerPos.y == 2)
            {
                Player.playerPos.x = 10;
                Player.playerPos.y = 3;

            }
        }

        public bool PlayerVoid()
        {
            Random random = new Random();
            int playerAvoid = random.Next(1, 100);
            if (Player.lucky > 50)
            {
                playerAvoid += 10;
            }
            else if (Player.lucky < 0)
            {
                playerAvoid -= 10;
            }

            if (playerAvoid > 70)
            {
                Console.WriteLine("플레이어가 공격을 운 좋게 피했습니다. 데미지를 맞지 않습니다.");
                Thread.Sleep(1000);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
