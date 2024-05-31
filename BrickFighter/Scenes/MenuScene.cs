using BrickFighter.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BrickFighter.Scenes;
public class MenuScene : SceneModel
{
    private SpriteFont font;

    public MenuScene() : base(ServiceLocator.Get<SpriteBatch>()) { }

    public override void LoadContent()
    {
        font = ServiceLocator.Get<ContentManager>().Load<SpriteFont>("MyFont");
    }

    public override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Enter))
        {
            SceneManager.Instance.ChangeScene(new BrickScene());
        }
    }

    public override void Draw(GameTime gameTime)
    {
        spriteBatch.Begin();
        spriteBatch.DrawString(font, "Welcome to the Menu! Press Enter to Start.", new Vector2(100, 100), Color.White);
        spriteBatch.End();
    }


}