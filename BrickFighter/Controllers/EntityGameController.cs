using BrickFighter.Entity;
using BrickFighter.Scenes;
using BrickFighter.Services;
using System.Collections.Generic;
using System.Diagnostics;

namespace BrickFighter.Controllers
{
    public class EntityGameController
    {
        private static EntityGameController _instance;
        public static EntityGameController Instance => _instance ??= new EntityGameController(); // gqrde cette instqnce en mémoire

        public int Life { get; set; } = 100;
        public int HealPoints { get; set; } = 0;
        public int Power { get; set; } = 10;

        public enum BattleState
        {
            Start,
            PlayerTurn,
            EnemyTurn,
            End
        }

        private EntityGameController()
        {
            ServiceLocator.Register(this);
        }

        public void Reset()
        {
            Power = 10;
            Life = 100;
            HealPoints = 0;
        }

        public void AddLife()
        {
            Life += 50;
        }

        public void PlayerWin()
        {
            var sm = ServiceLocator.Get<ISceneManager>();
            sm.Load<WinScene>();
        }

        public void PlayerLoose()
        {
            var sm = ServiceLocator.Get<ISceneManager>();
            sm.Load<GameOverScene>();
        }

        public void AddBuff(string type)
        {
            if (type == "armor")
            {
                Debug.WriteLine($"Le player a {Life}hp");
                Life += 50;
                Debug.WriteLine($"50 hp sont ajoutés au player. Il a maintenant {Life}hp");
            }
            if (type == "magic")
            {
                Debug.WriteLine($"Le player a {HealPoints} heal point(s)");
                HealPoints += 25;
                Debug.WriteLine($"25 magic sont ajoutés au player. Il a maintenant {HealPoints} heal points");
            }
            if (type == "sword")
            {
                Debug.WriteLine($"Le player a {Power} force");
                Power += 30;
                Debug.WriteLine($"30 power sont ajoutés au player. Il a maintenant {Power} force");
            }
        }
    }
}
