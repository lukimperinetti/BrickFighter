using BrickFighter.Controllers;
using System;
using System.Diagnostics;

namespace BrickFighter.Entity
{
    public class Enemy : Entity
    {
        private EntityGameController _entityGameController;
        private Player _player;
        private static Random rnd = new Random();

        public int EnemyLife
        {
            get => _entityGameController.enemyLife;
            private set => _entityGameController.enemyLife = value;
        }

        public int EnemyPower
        {
            get => _entityGameController.enemyPower;
            private set => _entityGameController.enemyPower = value;
        }

        public Enemy(EntityGameController entityGameController) : base(entityGameController)
        {
            _entityGameController = entityGameController;
            EnemyLife = rnd.Next(150, 300);
            EnemyPower = rnd.Next(15, 30);
            Debug.WriteLine("Enemy created with random values: Life = " + EnemyLife + ", Power = " + EnemyPower);
        }

        public void SetPlayer(Player player)
        {
            _player = player;
            Debug.WriteLine("Player set for enemy");
        }

        public void PerformAttack()
        {
            if (_player == null)
            {
                throw new NullReferenceException("Player is not set.");
            }

            int damage = EnemyPower;
            Debug.WriteLine("Enemy attacking player with " + damage + " damage.");
            _player.TakeDamages(damage);
        }

        public void TakeDamages(int damage)
        {
            EnemyLife -= damage;
            Debug.WriteLine("Enemy took " + damage + " damage. Remaining Life = " + EnemyLife);
            if (EnemyLife <= 0)
            {
                OnDeath();
            }
        }

        public override void OnDeath()
        {
            Debug.WriteLine("Enemy died.");
            _entityGameController.PlayerWin();
        }

        public bool IsAlive()
        {
            return EnemyLife > 0;
        }
    }
}
