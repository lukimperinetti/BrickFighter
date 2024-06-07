using BrickFighter.GameObjects;
using BrickFighter.Props;
using BrickFighter.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace BrickFighter.Scenes
{
    public class MenuScene : Scene
    {
        private Texture2D titleTexture;
        private Texture2D ngButtonTexture;
        private Texture2D scoreButtonTexture;
        private Texture2D quitButtonTexture;

        private Button _newGameButton;
        private Button _scoreButton;
        private Button _quitButton;

        public override void Load()
        {
            var screen = ServiceLocator.Get<IScreenService>();
            var assetsService = ServiceLocator.Get<IAssetsService>();

            titleTexture = assetsService.Get<Texture2D>("Title");
            ngButtonTexture = assetsService.Get<Texture2D>("NGbutton");
            scoreButtonTexture = assetsService.Get<Texture2D>("scoreButton");
            quitButtonTexture = assetsService.Get<Texture2D>("quitButton");

            // Création des boutons
            _newGameButton = new Button("NewGame", ngButtonTexture, (int)(screen.Center.X - ngButtonTexture.Width / 2), (int)(screen.Top + 20 + titleTexture.Height + 300), this);
            _scoreButton = new Button("Score", scoreButtonTexture, (int)(screen.Center.X - scoreButtonTexture.Width / 2), (int)(_newGameButton.ButtonY + _newGameButton.Texture.Height + 50), this);
            _quitButton = new Button("Quit", quitButtonTexture, (int)(screen.Center.X - quitButtonTexture.Width / 2), (int)(_scoreButton.ButtonY + _scoreButton.Texture.Height + 50), this);

            // Définir les actions à exécuter lorsque les boutons sont cliqués
            _newGameButton.OnClick = () =>
            {
                var sceneManager = ServiceLocator.Get<ISceneManager>();
                sceneManager.Load<BrickScene>();
            };

            _scoreButton.OnClick = () =>
            {
                // Mettre ici l'action à exécuter lors du clic sur le bouton Score
            };

            _quitButton.OnClick = () =>
            {
                //quit ??????
            };
        }

        public override void Update(float dt)
        {
            // Mise à jour des boutons
            _newGameButton.Update(dt);
            _scoreButton.Update(dt);
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
            _scoreButton.Draw(spriteBatch);
            _quitButton.Draw(spriteBatch);
        }
    }
}
