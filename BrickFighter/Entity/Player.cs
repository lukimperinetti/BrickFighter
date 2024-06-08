/*using BrickFighter.Controllers;
using BrickFighter.Services;
using System;

namespace BrickFighter.Entity
{
    public class Player : Entity
    {
        private static Random rnd = new Random();
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
        public void TransitionToState(State newState)
        {
            CurrentState = newState;

            switch (newState)
            {
                case State.Attack:
                    Attack(_enemy);
                    break;

                case State.Heal:
                    Heal();
                    break;
            }
        }
        private void Attack()
        {
            Console.WriteLine("Player is attacking!");
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
*/