using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BrickFighter.Scenes;
using Microsoft.Xna.Framework.Input;
using BrickFighter.Services;
using System.Diagnostics;

namespace BrickFighter
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private AssetsService _assetsService;
        private ScreenService _screenService;
        private SceneManager _sceneManager;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            
            _assetsService = new AssetsService(Content);
            _screenService = new ScreenService(_graphics);
            _sceneManager = new SceneManager();
            // Initialize the spriteBatch to register it with the ServiceLocator
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // Register services in the ServiceLocator
            ServiceLocator.Register(Content);
            ServiceLocator.Register(_spriteBatch);
            ServiceLocator.Register(_assetsService);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            

            // Load assets
            _assetsService.Load<Texture2D>("Ball");
            _assetsService.Load<Texture2D>("BrickArmor");
            _assetsService.Load<Texture2D>("BrickMagic");
            _assetsService.Load<Texture2D>("BrickSword");
            _assetsService.Load<Texture2D>("Brick");
            _assetsService.Load<Texture2D>("lignes");
            _assetsService.Load<Texture2D>("Pad");

            // Change to the first scene of the game
            Debug.WriteLine("on load la BrickScene");
            _sceneManager.Load<BrickScene>();
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update the current scene
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue); // Background color
            _spriteBatch.Begin();
            _sceneManager.Draw(_spriteBatch);
            _spriteBatch.End();

            // Draw the current scene
            base.Draw(gameTime);
            System.Diagnostics.Debug.WriteLine("Draw du GALE1");
        }
    }
}
