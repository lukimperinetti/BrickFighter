using BrickFighter.Props;
using BrickFighter.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace BrickFighter.Scenes
{
    public class BrickScene : Scene
    {
        public override void Load()
        {
            var screen = ServiceLocator.Get<IScreenService>();
            Rectangle bounds = screen.Bounds;
            AddGameObject(new Ball(bounds, this));
            AddGameObject(new Pad(bounds, this));
            AddBricks(bounds);
        }

        public override void Update(float dt)
        {
            var gc = ServiceLocator.Get<GameController>();
            var sm = ServiceLocator.Get<ISceneManager>();
            var bricks = GetGameObjects<Brick>();
            var bricksSword = GetGameObjects<BrickSword>();
            var bricksMagic = GetGameObjects<BrickMagic>();
            var bricksArmor = GetGameObjects<BrickArmor>();

            if (bricks.Count == 0 && bricksSword.Count == 0 && bricksMagic.Count == 0 && bricksArmor.Count == 0)
            {
                gc.LevelUp();
                sm.Load<BrickScene>();
                return;
            }

            var keyboardState = Keyboard.GetState();
            var gamePadState = GamePad.GetState(PlayerIndex.One);
            
            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                var sceneManager = ServiceLocator.Get<ISceneManager>();
                sceneManager.Load<MenuScene>();
            }
            /*if (gamePadState.IsConnected)
            {
                // DPad support
                if (gamePadState.Buttons.Start == ButtonState.Pressed)
                {
                        
                }
            }*/
            

            base.Update(dt);
        }

        private void AddBricks(Rectangle bounds)
        {
            var brickLayout = ServiceLocator.Get<GameController>().GetBricksLayout();
            var brickTexture = ServiceLocator.Get<IAssetsService>().Get<Texture2D>("Brick");

            int cols = brickLayout.GetLength(0);
            int rows = brickLayout.GetLength(1);

            int spaceBetweenBricks = 10;
            int verticalOffset = 10;
            float totalWidth = cols * (brickTexture.Width + spaceBetweenBricks) - spaceBetweenBricks;
            float offsetX = (bounds.Width - totalWidth) * .5f;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (brickLayout[col, row] == 1)
                    {
                        float x = bounds.X + offsetX + col * (brickTexture.Width + spaceBetweenBricks);
                        float y = bounds.Y + verticalOffset + row * (brickTexture.Height + spaceBetweenBricks);
                        Brick brick = new Brick(this);
                        brick.position = new Vector2(x, y);
                        AddGameObject(brick);
                    }
                    else if (brickLayout[col, row] == 2)
                    {
                        var brickSwordTexture = ServiceLocator.Get<IAssetsService>().Get<Texture2D>("BrickSword");
                        float totalWidthSword = cols * (brickSwordTexture.Width + spaceBetweenBricks) - spaceBetweenBricks;
                        float offsetXSword = (bounds.Width - totalWidthSword) * .5f;

                        float x = bounds.X + offsetXSword + col * (brickSwordTexture.Width + spaceBetweenBricks);
                        float y = bounds.Y + verticalOffset + row * (brickSwordTexture.Height + spaceBetweenBricks);
                        BrickSword brickSword = new BrickSword(this);
                        brickSword.position = new Vector2(x, y);
                        AddGameObject(brickSword);
                    }
                    else if (brickLayout[col, row] == 3)
                    {
                        var brickMagicTexture = ServiceLocator.Get<IAssetsService>().Get<Texture2D>("BrickMagic");
                        float totalWidthMagic = cols * (brickMagicTexture.Width + spaceBetweenBricks) - spaceBetweenBricks;
                        float offsetXMagic = (bounds.Width - totalWidthMagic) * .5f;

                        float x = bounds.X + offsetXMagic + col * (brickMagicTexture.Width + spaceBetweenBricks);
                        float y = bounds.Y + verticalOffset + row * (brickMagicTexture.Height + spaceBetweenBricks);
                        BrickMagic brickMagic = new BrickMagic(this);
                        brickMagic.position = new Vector2(x, y);
                        AddGameObject(brickMagic);
                    }
                    else if (brickLayout[col, row] == 4)
                    {
                        var brickArmorTexture = ServiceLocator.Get<IAssetsService>().Get<Texture2D>("BrickArmor");
                        float totalWidthArmor = cols * (brickArmorTexture.Width + spaceBetweenBricks) - spaceBetweenBricks;
                        float offsetXArmor = (bounds.Width - totalWidthArmor) * .5f;

                        float x = bounds.X + offsetXArmor + col * (brickArmorTexture.Width + spaceBetweenBricks);
                        float y = bounds.Y + verticalOffset + row * (brickArmorTexture.Height + spaceBetweenBricks);
                        BrickArmor brickArmor = new BrickArmor(this);
                        brickArmor.position = new Vector2(x, y);
                        AddGameObject(brickArmor);
                    }
                }
            }
        }
    }
}
