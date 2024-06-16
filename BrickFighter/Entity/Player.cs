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
            get => _entityGameController.Life;
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

        public enum State
        {
            Attack,
            Heal
        }

        public State CurrentState { get; private set; }

        public void TransitionToState(State newState, Entity entity)
        {
            CurrentState = newState;

            switch (newState)
            {
                case State.Attack:
                    Attack(target: entity);
                    break;

                case State.Heal:
                    Heal();
                    break;
            }
        }

        protected override void Attack(Entity target)
        {
            Console.WriteLine("Player is attacking!");
           /* if (target == null)
                throw new ArgumentNullException(nameof(target));

            int damage = Power;
            target.Life -= damage;
            Console.WriteLine($"Player attacks Enemy for {damage} damage!");*/
        }

        private void Heal()
        {
            int healAmount = (int)(Life * 0.3);
            Life += healAmount;
            Console.WriteLine($"Player heals for {healAmount} health points!");
        }

        protected override void OnDeath()
        {
            _entityGameController.PlayerLoose();
        }

        public void AddBuff(string type)
        {
            _entityGameController.AddBuff(type);
        }
    }
}

