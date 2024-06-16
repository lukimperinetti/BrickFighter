using BrickFighter.Controllers;
using BrickFighter.Services;
using System;

namespace BrickFighter.Entity
{
    public class Player : Entity
    {
        //private static Random rnd = new Random();
        public int _health;

        public Player(EntityGameController entityGameController) : base(entityGameController)
        {
            _health = 100;
            Power = 10;
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
            /*if (target == null)
                throw new ArgumentNullException(nameof(target));

            int damage = Power;
            target.Health -= damage;
            Console.WriteLine($"Player attacks Enemy for {damage} damage!");*/
        }

        private void Heal()
        {
            int healAmount = (int)(_health * 0.3);
            _health += healAmount;
            Console.WriteLine($"Player heals for {healAmount} health points!");
        }
        protected override void OnDeath()
        {
            _entityGameController.PlayerLoose();
        }
    }
}
