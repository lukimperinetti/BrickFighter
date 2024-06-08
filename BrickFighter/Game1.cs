﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BrickFighter.Scenes;
using Microsoft.Xna.Framework.Input;
using BrickFighter.Services;
using System.Diagnostics;
using BrickFighter.Controllers;
//using BrickFighter.Entity;
using System.Numerics;

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

            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            new GameController();
            new EntityGameController();

            _assetsService = new AssetsService(Content);
            _screenService = new ScreenService(_graphics);
            _sceneManager = new SceneManager();
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
            _assetsService.Load<Texture2D>("AboutButton");
            _assetsService.Load<Texture2D>("NGbutton");
            _assetsService.Load<Texture2D>("quitButton");
            _assetsService.Load<Texture2D>("scoreButton");
            _assetsService.Load<Texture2D>("Title");
            _assetsService.Load<SpriteFont>("MyFont");
            _assetsService.Load<Texture2D>("PlayerTexture");
            _assetsService.Load<Texture2D>("EnemyTexture");

            // Load the initial scene
            _sceneManager.Load<MenuScene>();

            

        }

        protected override void Update(GameTime gameTime)
        {
            // Update the current scene
            _sceneManager.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _sceneManager.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
