using BrickFighter.Scenes;
using BrickFighter.Services;
using System.Collections.Generic;
using System.Diagnostics;

namespace BrickFighter.Controllers
{
    public class EntityGameController
    {
        public List<string> inventory = ServiceLocator.Get<GameController>().inventory;
        public int power { get; private set; } = 10;
        public int health { get; private set; } = 100;
        public int healPoints { get; private set; } = 0;

        public EntityGameController()
        {
            ServiceLocator.Register(this);
        }

        public void Reset()
        {
            inventory = new List<string>();
            power = 10;
            health = 100;
            healPoints = 0;
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
            //On parcour l'inventaire et pour chaque type on fait :
            if (type == "armor")
            {
                Debug.WriteLine($"Le player à {health}hp");
                health += 50;
                Debug.WriteLine($"50 hp sont ajouté au player. Il à maintenant {health}hp");
            }
            if (type == "magic")
            {
                Debug.WriteLine($"Le player à {healPoints} heal point(s)");
                healPoints += 25;
                Debug.WriteLine($"25magic sont ajouté au player. Il à maintenant {healPoints} heal points");

            }
            if (type == "sword")
            {
                Debug.WriteLine($"Le player à {power} force");
                power += 10;
                Debug.WriteLine($"10magic sont ajouté au player. Il à maintenant {power} force");
            }
        }
    }
}
