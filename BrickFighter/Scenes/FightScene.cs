using BrickFighter.Controllers;
using BrickFighter.Entity;
using BrickFighter.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
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

        // Variable de temps
        private float _baseTime = 0f;
        private float _turnDelay = 1f; // Délai de 1 seconde entre les tours
        private bool _transition = false;

        public override void Load()
        {
            var assetsService = ServiceLocator.Get<IAssetsService>();
            _font = assetsService.Get<SpriteFont>("MyFont");
            _playerTexture = assetsService.Get<Texture2D>("PlayerTexture");
            _enemyTexture = assetsService.Get<Texture2D>("EnemyTexture");

            var entityGameController = EntityGameController.Instance;
            _player = new Player(entityGameController);
            _enemy = new Enemy(entityGameController);
            _playerHealth = _player.PlayerLife;
            _enemyHealth = _enemy.EnemyLife;

            _player.SetEnemy(_enemy);
            _enemy.SetPlayer(_player);
            _playerPower = _player.PlayerPower;
            _enemyPower = _enemy.EnemyPower;

            _playerPosition = new Vector2(100, 300);
            _enemyPosition = new Vector2(1200, 300);

            _curentState = BattleState.Start;

            Debug.WriteLine("FightScene loaded. Starting state: " + _curentState);
        }

        public override void Update(float dt)
        {
            if (_transition)
            {
                _baseTime += dt;
                if (_baseTime >= _turnDelay)
                {
                    _transition = false;
                    _baseTime = 0f;
                }
                else
                {
                    return; // Attendre que le délai soit écoulé
                }
            }

            switch (_curentState)
            {
                case BattleState.Start:
                    Debug.WriteLine("BattleState: Start");
                    _curentState = BattleState.PlayerTurn;
                    break;

                case BattleState.PlayerTurn:
                    Debug.WriteLine("BattleState: PlayerTurn");
                    _player.PerformAttack();
                    _enemyHealth = _enemy.EnemyLife;
                    Debug.WriteLine($"Player attacked enemy. Enemy health: {_enemyHealth}");
                    if (!_enemy.IsAlive())
                    {
                        Debug.WriteLine("Enemy is dead. Transitioning to End state.");
                        _curentState = BattleState.End;
                    }
                    else
                    {
                        _transition = true;
                        _curentState = BattleState.EnemyTurn;
                    }
                    break;

                case BattleState.EnemyTurn:
                    Debug.WriteLine("BattleState: EnemyTurn");
                    _enemy.PerformAttack();
                    _playerHealth = _player.PlayerLife;
                    Debug.WriteLine($"Enemy attacked player. Player health: {_playerHealth}");
                    if (!_player.IsAlive())
                    {
                        Debug.WriteLine("Player is dead. Transitioning to End state.");
                        _curentState = BattleState.End;
                    }
                    else
                    {
                        _transition = true;
                        _curentState = BattleState.PlayerTurn;
                    }
                    break;

                case BattleState.End:
                    Debug.WriteLine("BattleState: End");
                    if (!_player.IsAlive())
                    {
                        _player.OnDeath();
                    }
                    else
                    {
                        _enemy.OnDeath();
                    }
                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_playerTexture, _playerPosition, Color.White);
            spriteBatch.Draw(_enemyTexture, _enemyPosition, Color.White);

            spriteBatch.DrawString(_font, $"Player Health: {_playerHealth}", new Vector2(100, 250), Color.White);
            spriteBatch.DrawString(_font, $"Enemy Health: {_enemyHealth}", new Vector2(1200, 250), Color.White);

            spriteBatch.DrawString(_font, $"Player Power: {_playerPower}", new Vector2(100, 220), Color.White);
            spriteBatch.DrawString(_font, $"Enemy Power: {_enemyPower}", new Vector2(1200, 220), Color.White);

            base.Draw(spriteBatch);
        }
    }
}
