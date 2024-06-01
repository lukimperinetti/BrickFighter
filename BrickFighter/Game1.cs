using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BrickFighter.Scenes;
using Microsoft.Xna.Framework.Input;
using BrickFighter.Services;
using Microsoft.Xna.Framework.Content;

namespace BrickFighter
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private AssetsService _assetsService;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Initialize the spriteBatch to register it with the ServiceLocator
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Register services in the ServiceLocator
            ServiceLocator.Register(Content);
            ServiceLocator.Register(spriteBatch);
            _assetsService = new AssetsService();
            ServiceLocator.Register(_assetsService);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Load assets
            _assetsService.LoadAsset<Texture2D>("Ball");
            _assetsService.LoadAsset<Texture2D>("BrickArmor");
            _assetsService.LoadAsset<Texture2D>("BrickMagic");
            _assetsService.LoadAsset<Texture2D>("BrickSword");
            _assetsService.LoadAsset<Texture2D>("Brick");
            _assetsService.LoadAsset<Texture2D>("lignes");
            _assetsService.LoadAsset<Texture2D>("Pad");

            // Change to the first scene of the game
            SceneManager.Instance.ChangeScene(new MenuScene());
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update the current scene
            SceneManager.Instance.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue); // Background color

            // Draw the current scene
            SceneManager.Instance.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
