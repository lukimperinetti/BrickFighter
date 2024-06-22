using BrickFighter.Controllers;
using System;
using System.Diagnostics;

namespace BrickFighter.Entity
{
    public class Player : Entity
    {
        private EntityGameController _entityGameController;
        private Enemy _enemy;

        public int PlayerLife
        {
            get => _entityGameController.Life;
            private set => _entityGameController.Life = value;
        }

        public int PlayerPower
        {
            get => _entityGameController.Power;
            private set => _entityGameController.Power = value;
        }

        public Player(EntityGameController entityGameController) : base(entityGameController)
        {
            _entityGameController = entityGameController;
            Debug.WriteLine("Player created with initial values: Life = " + PlayerLife + ", Power = " + PlayerPower);
        }

        public void SetEnemy(Enemy enemy)
        {
            _enemy = enemy;
            Debug.WriteLine("Enemy set for player");
        }

        public void PerformAttack()
        {
            if (_enemy == null)
            {
                throw new NullReferenceException("Enemy is not set.");
            }

            int damage = PlayerPower;
            Debug.WriteLine("Player attacking enemy with " + damage + " damage.");
            _enemy.TakeDamages(damage);
        }

        public void TakeDamages(int damage)
        {
            PlayerLife -= damage;
            Debug.WriteLine("Player took " + damage + " damage. Remaining Life = " + PlayerLife);
            if (PlayerLife <= 0)
            {
                OnDeath();
            }
        }

        public override void OnDeath()
        {
            Debug.WriteLine("Player died.");
            _entityGameController.PlayerLoose();
        }

        public bool IsAlive()
        {
            return PlayerLife > 0;
        }
    }
}
