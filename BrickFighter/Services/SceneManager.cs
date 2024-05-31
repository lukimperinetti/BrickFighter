using BrickFighter.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using static System.Formats.Asn1.AsnWriter;

namespace BrickFighter.Services
{
    public class SceneManager
    {
        private static SceneManager _instance;
        public static SceneManager Instance => _instance ??= new SceneManager(); // garantit qu'il n'y aura qu'une seule instance de SceneManager dans toute l'application
        private SceneModel currentScene;
        private SceneManager() { }

        public void ChangeScene(SceneModel newScene)
        {
            currentScene = newScene;
            currentScene.LoadContent();
        }

        public void Update(GameTime gameTime)
        {
            currentScene?.Update(gameTime);// call the methode only if currentScene is not nul
        }

        public void Draw(GameTime gameTime)
        {
            currentScene?.Draw(gameTime);
        }
    }
}
