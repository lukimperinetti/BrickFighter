using BrickFighter.Services;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;


namespace BrickFighter.Scenes
{
    public interface ISceneManager
    {
        void Load<T>() where T : Scene, new();
    }
    public sealed class SceneManager : ISceneManager
    {
        private Scene _currentScene;

        public  SceneManager()
        {
            ServiceLocator.Register<ISceneManager>(this);
        }

        public void Load<T>() where T : Scene, new()
        {
            var type = typeof(T);
            if (_currentScene != null) _currentScene.Unload();
            _currentScene = new T();
            _currentScene.Load();
        }

        public void Update(float dt)
        {
            _currentScene?.Update(dt);// call the methode only if currentScene is not nul
        }

        public void Draw(SpriteBatch sb) => _currentScene?.Draw(sb);
    }
}
