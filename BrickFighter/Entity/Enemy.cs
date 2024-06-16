using BrickFighter.Controllers;
using BrickFighter.Services;
using System;

namespace BrickFighter.Entity
{
    public class Enemy : Entity
    {
        private static Random rnd = new Random();

        public Enemy(EntityGameController entityGameController) : base(entityGameController)
        {
            //ServiceLocator.Register(this);
            Health = rnd.Next(200, 1000);
            Power = rnd.Next(15, 30);
            CurrentState = State.None; // Initialize the state
        }

        public enum State
        {
            None,
            Attack,
            Heal
        }

        public State CurrentState { get; private set; }

        public override void Update(float dt)
        {
            switch (CurrentState)
            {
                case State.None:
                    Waiting();
                    break;
                case State.Attack:
                    Attack(_player);
                    break;
                case State.Heal:
                    Heal();
                    break;
            }
        }

        private void Waiting()
        {
            //cooldown between attacks
        }

        protected override void Attack(Entity target)
        {
            Console.WriteLine("Player is attacking!");

            /*if (target == null)
                throw new ArgumentNullException(nameof(target));

            int damage = Power;
            target.Health -= damage;
            Console.WriteLine($"Enemy attacks player for {damage} damage!");*/
        }

        private void Heal()
        {
            int healAmount = (int)(Health * 0.3);
            Health += healAmount;
            Console.WriteLine($"Enemy heals for {healAmount} health points!");
        }

        protected override void OnDeath()
        {
            _entityGameController.PlayerWin();
        }
    }
}
