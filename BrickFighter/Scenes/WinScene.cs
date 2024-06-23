using BrickFighter.GameObjects;
using BrickFighter.Props;
using BrickFighter.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;


namespace BrickFighter.Scenes
{
    public class WinScene : Scene
    {
        private Texture2D titleTexture; // remplacer par titre Win
        private Texture2D ngButtonTexture;
        private Texture2D quitButtonTexture;

        private Button _newGameButton;
        private Button _quitButton;

        public override void Load()
        {
            var screen = ServiceLocator.Get<IScreenService>();
            var assetsService = ServiceLocator.Get<IAssetsService>();

            titleTexture = assetsService.Get<Texture2D>("YouWin");
            ngButtonTexture = assetsService.Get<Texture2D>("NGbutton");
            quitButtonTexture = assetsService.Get<Texture2D>("quitButton");

            // Création des boutons
            _newGameButton = new Button("NewGame", ngButtonTexture, (int)(screen.Center.X - ngButtonTexture.Width / 2), (int)(screen.Top + 20 + titleTexture.Height + 300), this);
            _quitButton = new Button("Quit", quitButtonTexture, (int)(screen.Center.X - quitButtonTexture.Width / 2), (int)(_newGameButton.ButtonY + _newGameButton.Texture.Height + 50), this);

            // Définir les actions à exécuter lorsque les boutons sont cliqués
            _newGameButton.OnClick = () =>
            {
                var sceneManager = ServiceLocator.Get<ISceneManager>();
                sceneManager.Load<BrickScene>();
            };

            _quitButton.OnClick = () =>
            {
                Debug.WriteLine("btn clicked");
                //quit ??????
            };
        }

        public override void Update(float dt)
        {
            // Mise à jour des boutons
            _newGameButton.Update(dt);
            _quitButton.Update(dt);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var screen = ServiceLocator.Get<IScreenService>();

            // Dessiner le titre
            Vector2 titlePosition = new Vector2(screen.Center.X - titleTexture.Width / 2, screen.Top + 20);
            spriteBatch.Draw(titleTexture, titlePosition, Color.White);

            // Dessiner les boutons
            _newGameButton.Draw(spriteBatch);
            _quitButton.Draw(spriteBatch);
        }
    }
}
