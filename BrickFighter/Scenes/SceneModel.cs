using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using BrickFighter.GameObjects;
using System.Collections.Generic;

namespace BrickFighter.Scenes
{
    public abstract class SceneModel
    {
        protected ContentManager content;
        protected SpriteBatch spriteBatch;
        private List<GameObject> _gameObjects = new List<GameObject>();

        public SceneModel(ContentManager content, SpriteBatch spriteBatch)
        {
            this.content = content;
            this.spriteBatch = spriteBatch;
        }

        public abstract void LoadContent();

        public void Update(float dt)
        {
            foreach (GameObject obj in _gameObjects)
            {
                if (obj.enable)
                    obj.Update(dt);
            }

            for (int i = _gameObjects.Count - 1; i >= 0; i--)
            {
                if (_gameObjects[i].isFree)
                {
                    _gameObjects[i].OnFree();
                    _gameObjects.RemoveAt(i);
                }
            }
        }

        public abstract void Draw(GameTime gameTime);

        public void AddGameObject(GameObject obj)
        {
            obj.Start();
            _gameObjects.Add(obj);
        }

        public List<T> GetGameObjects<T>()
        {
            var gameObjects = new List<T>();

            foreach (GameObject gameObject in _gameObjects)
                if (gameObject is T typedObject)
                    gameObjects.Add(typedObject);

            return gameObjects;
        }
    }
}
