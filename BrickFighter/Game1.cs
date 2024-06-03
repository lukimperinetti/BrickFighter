﻿using Microsoft.Xna.Framework;
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

            // Set the game resolution to 1080x720
            _graphics.PreferredBackBufferWidth = 1080;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
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

            // Load the initial scene
            _sceneManager.Load<BrickScene>();

            Debug.WriteLine("on load la BrickScene");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update the current scene
            _sceneManager.Update((float)gameTime.ElapsedGameTime.TotalSeconds); // Call Update of SceneManager

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Debug.WriteLine("Draw du Game1");

            GraphicsDevice.Clear(Color.CornflowerBlue); // Background color

            _spriteBatch.Begin();
            _sceneManager.Draw(_spriteBatch); // Call Draw of SceneManager
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
