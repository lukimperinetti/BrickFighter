using BrickFighter.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using static System.Formats.Asn1.AsnWriter;

namespace BrickFighter.Scenes
{
    public class BrickScene : SceneModel
    {
        public BrickScene() : base(ServiceLocator.Get<SpriteBatch>()) { }


        public override void LoadContent()
        {
            // Load game content here

        }

        public override void Update(GameTime gameTime)
        {
            // Update game logic here
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(ServiceLocator.Get<ContentManager>().Load<SpriteFont>("MyFont"), "Game Playing!", new Vector2(100, 100), Color.White);
            spriteBatch.End();
        }
    }
}
