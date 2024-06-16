using BrickFighter.Controllers;
using BrickFighter.Services;
using System;

namespace BrickFighter.Entity
{
    public abstract class Entity
    {
        protected EntityGameController _entityGameController; // Instance de GameController
        protected Player _player;
        protected Enemy _enemy;

        private int _health;
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

        public int Power { get; set; }

        public Entity(EntityGameController entityGameController)
        {
            _entityGameController = entityGameController;
        }

        public void Load()
        {
            var screen = ServiceLocator.Get<IScreenService>();
            var assetsService = ServiceLocator.Get<IAssetsService>();
        }

        public virtual void Update(float dt) { }
        protected virtual void Attack(Entity target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            target.Health -= this.Power;

            if (this is Player && target.Health <= 0)
            {
                _entityGameController.PlayerWin();
            }
            else if (this is Enemy && _player.Life <= 0)
            {
                _entityGameController.PlayerLoose();
            }
        }
        protected abstract void OnDeath();
    }
}
