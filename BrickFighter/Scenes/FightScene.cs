using BrickFighter.Controllers;
using BrickFighter.Entity;
using BrickFighter.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static BrickFighter.Controllers.EntityGameController;

namespace BrickFighter.Scenes
{
    public class FightScene : Scene
    {
        private BattleState _curentState;
        private Player _player;
        private Enemy _enemy;
        private SpriteFont _font;
        private Texture2D _playerTexture;
        private Texture2D _enemyTexture;
        private Vector2 _playerPosition;
        private Vector2 _enemyPosition;
        private int _playerHealth;
        private int _enemyHealth;
        private int _playerPower;
        private int _enemyPower;

        public override void Load()
        {
            var assetsService = ServiceLocator.Get<IAssetsService>();
            _font = assetsService.Get<SpriteFont>("MyFont");
            _playerTexture = assetsService.Get<Texture2D>("PlayerTexture");
            _enemyTexture = assetsService.Get<Texture2D>("EnemyTexture");

            var entityGameController = EntityGameController.Instance;
            _player = new Player(entityGameController);
            _enemy = new Enemy(entityGameController);

            _playerPosition = new Vector2(100, 300);
            _enemyPosition = new Vector2(1200, 300);

            _playerHealth = _player.Life;
            _enemyHealth = _enemy.Health;
            _playerPower = _player.Power;
            _enemyPower = _enemy.Power;

            _curentState = BattleState.Start;
        }

        public override void Update(float dt)
        {

            switch ()

            /*var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Space))
            {
                // Logique d'attaque ici
            }

            _enemy.Update(dt);

            if (_playerHealth <= 0 || _enemyHealth <= 0)
            {
                var sceneManager = ServiceLocator.Get<ISceneManager>();
                if (_playerHealth <= 0)
                {
                    sceneManager.Load<GameOverScene>();
                }
                else if (_enemyHealth <= 0)
                {
                    sceneManager.Load<WinScene>();
                }
            }*/

            base.Update(dt);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_playerTexture, _playerPosition, Color.White);
            spriteBatch.Draw(_enemyTexture, _enemyPosition, Color.White);

            spriteBatch.DrawString(_font, $"Player Health: {_playerHealth}", new Vector2(100, 250), Color.White);
            spriteBatch.DrawString(_font, $"Enemy Health: {_enemyHealth}", new Vector2(1200, 250), Color.White);

            spriteBatch.DrawString(_font, $"Player power: {_playerPower}", new Vector2(100, 220), Color.White);
            spriteBatch.DrawString(_font, $"Enemy Power: {_enemyPower}", new Vector2(1200, 220), Color.White);

            base.Draw(spriteBatch);
        }
    }
}
