using BrickFighter.GameObjects;
using BrickFighter.Scenes;
using BrickFighter.Services;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BrickFighter.Props
{
    public class Pad : SpriteGameObject
    {
        private float _speed = 800f;
        private Rectangle _bounds;
        private Vector2 _targetPosition;

        public Pad (Rectangle bounds, Scene root) : base(root)
        {
            texture = ServiceLocator.Get<IAssetsService>().Get<Texture2D>("Pad"); //j'assigne la texture
            offset = new Vector2(texture.Width * .5f, texture.Height * .5f);
            _bounds = bounds;
            _targetPosition = new Vector2(bounds.Center.X, bounds.Bottom - texture.Height * .5f);
            position = _targetPosition;
        }

        public override void Update(float dt)
        {
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Left))
                _targetPosition.X -= _speed * dt;

            if (keyboardState.IsKeyDown(Keys.Right))
                _targetPosition.X += _speed * dt;

            //on établi les limites de l'écran
            _targetPosition = Vector2.Clamp(_targetPosition, new Vector2(_bounds.Left + offset.X, position.Y), new Vector2(_bounds.Right - offset.X, position.Y));
            position = Vector2.Lerp(position, _targetPosition, .1f);
        }

    }
}
