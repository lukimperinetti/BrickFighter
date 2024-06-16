using BrickFighter.Controllers;
using BrickFighter.Entity;
using BrickFighter.Props;
using BrickFighter.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BrickFighter.Scenes
{
    public class BrickScene : Scene
    {
        private SpriteFont _spriteFont;
        private Vector2 _textPosition;
        private GameController _gameController;
        private Player _player;

        public override void Load()
        {
            var entityGameController = ServiceLocator.Get<EntityGameController>();
            var screen = ServiceLocator.Get<IScreenService>();
            var assetsService = ServiceLocator.Get<IAssetsService>();

            _player = new Player(entityGameController);

            Rectangle bounds = screen.Bounds;
            AddGameObject(new Ball(bounds, this));
            AddGameObject(new Pad(bounds, this));

            _spriteFont = assetsService.Get<SpriteFont>("MyFont");
            _gameController = ServiceLocator.Get<GameController>();

            // Calculer et stocker la position des briques
            _textPosition = AddBricks(bounds);
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
            //var gamePadState = GamePad.GetState(PlayerIndex.One); // trouver la touche du gamepad

            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                var sceneManager = ServiceLocator.Get<ISceneManager>();
                sceneManager.Load<MenuScene>();
            }

            base.Update(dt);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Dessiner du texte à l'écran
            Color color = Color.White; // Couleur du texte
            string lifesText = $"Vies: {_gameController.lifes}";
            Vector2 lifesPosition = new Vector2(10, 1000); // Position du texte des vies à l'écran
            spriteBatch.DrawString(_spriteFont, lifesText, lifesPosition, color);

            base.Draw(spriteBatch);
        }

        private Vector2 AddBricks(Rectangle bounds)
        {
            var brickLayout = ServiceLocator.Get<GameController>().GetBricksLayout();
            var brickTexture = ServiceLocator.Get<IAssetsService>().Get<Texture2D>("Brick");

            int cols = brickLayout.GetLength(0);
            int rows = brickLayout.GetLength(1);

            int spaceBetweenBricks = 10;
            int verticalOffset = 10;
            float totalWidth = cols * (brickTexture.Width + spaceBetweenBricks) - spaceBetweenBricks;
            float offsetX = (bounds.Width - totalWidth) * .5f;

            Vector2 firstBrickPosition = Vector2.Zero;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (brickLayout[col, row] != 0)
                    {
                        Texture2D currentBrickTexture = null;
                        switch (brickLayout[col, row])
                        {
                            case 1:
                                currentBrickTexture = brickTexture;
                                break;
                            case 2:
                                currentBrickTexture = ServiceLocator.Get<IAssetsService>().Get<Texture2D>("BrickSword");
                                break;
                            case 3:
                                currentBrickTexture = ServiceLocator.Get<IAssetsService>().Get<Texture2D>("BrickMagic");
                                break;
                            case 4:
                                currentBrickTexture = ServiceLocator.Get<IAssetsService>().Get<Texture2D>("BrickArmor");
                                break;
                        }

                        float x = bounds.X + offsetX + col * (currentBrickTexture.Width + spaceBetweenBricks);
                        float y = bounds.Y + verticalOffset + row * (currentBrickTexture.Height + spaceBetweenBricks);

                        if (firstBrickPosition == Vector2.Zero)
                        {
                            firstBrickPosition = new Vector2(x, y - 30); 
                        }

                        if (brickLayout[col, row] == 1)
                        {
                            Brick brick = new Brick(this);
                            brick.position = new Vector2(x, y);
                            AddGameObject(brick);
                        }
                        else if (brickLayout[col, row] == 2)
                        {
                            BrickSword brickSword = new BrickSword(this);
                            brickSword.position = new Vector2(x, y);
                            AddGameObject(brickSword);
                        }
                        else if (brickLayout[col, row] == 3)
                        {
                            BrickMagic brickMagic = new BrickMagic(this);
                            brickMagic.position = new Vector2(x, y);
                            AddGameObject(brickMagic);
                        }
                        else if (brickLayout[col, row] == 4)
                        {
                            BrickArmor brickArmor = new BrickArmor(this);
                            brickArmor.position = new Vector2(x, y);
                            AddGameObject(brickArmor);
                        }
                    }
                }
            }

            return firstBrickPosition;
        }
    }
}
