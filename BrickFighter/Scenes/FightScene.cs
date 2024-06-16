using BrickFighter.Controllers;
using BrickFighter.Entity;
using BrickFighter.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace BrickFighter.Scenes
{
    public class FightScene : Scene
    {
        private static Random rnd = new Random();

        private Player _player;
        private Enemy _enemy;
        private SpriteFont _font;
        private Texture2D _playerTexture;
        private Texture2D _enemyTexture;
        private Vector2 _playerPosition;
        private Vector2 _enemyPosition;

        public override void Load()
        {
            var assetsService = ServiceLocator.Get<IAssetsService>();
            _font = assetsService.Get<SpriteFont>("MyFont");
            _playerTexture = assetsService.Get<Texture2D>("PlayerTexture");
            _enemyTexture = assetsService.Get<Texture2D>("EnemyTexture");

            var entityGameController = ServiceLocator.Get<EntityGameController>();
            _player = new Player(entityGameController);
            _enemy = new Enemy(entityGameController);

            // Position initiale des entités
            _playerPosition = new Vector2(100, 300);
            _enemyPosition = new Vector2(1200, 300);

            //load with health
            _player._health = 100;
            _enemy.Health = rnd.Next(200, 1000); ;
        }

        public override void Update(float dt)
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Space))
            {
                // Le joueur attaque l'ennemi lorsqu'on appuie sur la barre d'espace
                //_player.Attack(_enemy);
            }

            // Mise à jour de l'ennemi
            _enemy.Update(dt);

            //est il mort ?
            if (_player._health <= 0 || _enemy.Health <= 0)
            {
                var sceneManager = ServiceLocator.Get<ISceneManager>();
                if (_player._health <= 0)
                {
                    // Le joueur a perdu
                    sceneManager.Load<GameOverScene>();
                }
                else if (_enemy.Health <= 0)
                {
                    // L'ennemi a perdu
                    sceneManager.Load<WinScene>();
                }
            }

            base.Update(dt);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Draw player
            spriteBatch.Draw(_playerTexture, _playerPosition, Color.White);
            spriteBatch.Draw(_enemyTexture, _enemyPosition, Color.White);

            // draw life bar
            spriteBatch.DrawString(_font, $"Player Health: {_player._health}", new Vector2(100, 250), Color.White);
            spriteBatch.DrawString(_font, $"Enemy Health: {_enemy.Health}", new Vector2(1200, 250), Color.White);

            base.Draw(spriteBatch);
        }
    }
}
