using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BrickFighter.Scenes;
using Microsoft.Xna.Framework.Input;
using BrickFighter.Services;

namespace BrickFighter
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Register my new servicies
            ServiceLocator.Register(Content);
            ServiceLocator.Register(spriteBatch);

            //get the first scene of the game
            SceneManager.Instance.ChangeScene(new MenuScene());
        }

        protected override void Update(GameTime gameTime)
        {
            if (/*GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||*/ Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            SceneManager.Instance.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue); //bg color
            SceneManager.Instance.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
