/*using BrickFighter.Controllers;
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
            _enemyPosition = new Vector2(600, 300);
        }

        public override void Update(float dt)
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Space))
            {
                // Le joueur attaque l'ennemi lorsqu'on appuie sur la barre d'espace
                _player.Attack(_enemy);
            }

            // Mise à jour de l'ennemi
            _enemy.Update(dt);

            // Vérification des états de santé pour voir si quelqu'un est mort
            if (_player.Health <= 0 || _enemy.Health <= 0)
            {
                var sceneManager = ServiceLocator.Get<ISceneManager>();
                if (_player.Health <= 0)
                {
                    // Le joueur a perdu
                    sceneManager.Load<MenuScene>(); // Ou toute autre scène pour la défaite
                }
                else if (_enemy.Health <= 0)
                {
                    // L'ennemi a perdu
                    sceneManager.Load<WinScene>(); // Ou toute autre scène pour la victoire
                }
            }

            base.Update(dt);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Dessiner le joueur et l'ennemi
            spriteBatch.Draw(_playerTexture, _playerPosition, Color.White);
            spriteBatch.Draw(_enemyTexture, _enemyPosition, Color.White);

            // Dessiner les barres de santé ou les valeurs de santé
            spriteBatch.DrawString(_font, $"Player Health: {_player.Health}", new Vector2(100, 250), Color.White);
            spriteBatch.DrawString(_font, $"Enemy Health: {_enemy.Health}", new Vector2(600, 250), Color.White);

            base.Draw(spriteBatch);
        }
    }
}
*/