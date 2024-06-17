using BrickFighter.Controllers;
using BrickFighter.Services;
using System;

namespace BrickFighter.Entity
{
    public abstract class Entity
    {
        protected EntityGameController _entityGameController; // Instance de GameController

        public int HealPoints { get; set; } = 0;
    
        private int _health;
        public int Power { get; set; }

        protected internal int Health
        {
            get { return _health; }
            set
            {
                _health = value;
                if (_health <= 0)
                {
                    OnDeath();
                }
            }
        }

        public Entity(EntityGameController entityGameController)
        {
            _entityGameController = entityGameController;
        }



        public void TakeDamages(int damage)
        {
            Health -= damage;
            if (_health <= 0) Health = 0;
        }

        public bool IsAlive()
        {
            return Health > 0;
        }

        public virtual void Update(float dt) { }

        protected abstract void OnDeath();
    }
}
