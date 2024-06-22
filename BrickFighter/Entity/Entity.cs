using BrickFighter.Controllers;

namespace BrickFighter.Entity
{
    public abstract class Entity
    {
        protected EntityGameController _entityGameController;


        public Entity(EntityGameController entityGameController)
        {
            _entityGameController = entityGameController;
        }

        public virtual void Update(float dt) { }

        public abstract void OnDeath();
    }
}
