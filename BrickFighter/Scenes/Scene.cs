using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using BrickFighter.GameObjects;
using System.Collections.Generic;
using System.Diagnostics;


namespace BrickFighter.Scenes
{
    public abstract class Scene
    {
        protected ContentManager content;
        protected SpriteBatch spriteBatch;
        private List<GameObject> _gameObjects = new List<GameObject>();

        public virtual void Load() { }
        public virtual void Unload() { }


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

        public void Draw(SpriteBatch sb) {
            System.Diagnostics.Debug.WriteLine("Draw du SModel");
            foreach (GameObject obj in _gameObjects)
            {
                if (obj.enable)
                    obj.Draw(sb);
            }
        }

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
