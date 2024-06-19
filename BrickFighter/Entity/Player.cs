using BrickFighter.Controllers;
using BrickFighter.Services;
using System;
using System.Diagnostics;

namespace BrickFighter.Entity
{
    public class Player : Entity
    {
        private EntityGameController _entityGameController;

        public int Life
        {
            get => _entityGameController.Life; // Je get la life mise a jour dans mon controller
            private set => _entityGameController.Life = value;
        }

        public int HealPoints
        {
            get => _entityGameController.HealPoints;
            private set => _entityGameController.HealPoints = value;
        }

        public int Power
        {
            get => _entityGameController.Power;
            private set => _entityGameController.Power = value;
        }

        public Player(EntityGameController entityGameController) : base(entityGameController)
        {
            _entityGameController = entityGameController;
        }

        public void Heal()
        {
            int healAmount = (int)(Life * 0.3);
            Life += healAmount;
            Console.WriteLine($"Player heals for {healAmount} health points!");
        }

        public override void OnDeath()
        {
            _entityGameController.PlayerLoose();
        }
    }
}

