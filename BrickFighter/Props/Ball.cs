using BrickFighter.GameObjects;
using BrickFighter.Scenes;
using BrickFighter.Services;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Input;
using BrickFighter.Controllers;

namespace BrickFighter.Props
{
    internal class Ball : SpriteGameObject
    {
        private Rectangle _bounds;
        private Vector2 _direction = Vector2.Zero;
        private Vector2 _velocity = Vector2.Zero;
        private float _speed = 800f;
        private bool _sticked = true;

        public Ball(Rectangle bounds, Scene root) : base(root)
        { 
            texture = ServiceLocator.Get<AssetsService>().Get<Texture2D>("Ball");
            offset = new Vector2(texture.Width * .5f, texture.Height *.5f);
            _bounds = bounds;
        }

        public override void Update(float dt)
        {
            var keyboardState = Keyboard.GetState();
            var gamePadState = GamePad.GetState(PlayerIndex.One);

            if (_sticked)
            {
                var pad = root.GetGameObjects<Pad>()[0];
                position = new Vector2(pad.position.X, pad.collider.Top - offset.Y - 10f);
                if (keyboardState.IsKeyDown(Keys.Space))
                {
                    _sticked = false;
                    _direction = new Vector2(1, -1);
                    _direction = Vector2.Normalize(_direction);
                }
                if (gamePadState.IsConnected)
                {
                    // DPad support
                    if (gamePadState.Buttons.A == ButtonState.Pressed)
                    {
                        _sticked = false;
                        _direction = new Vector2(1, -1);
                        _direction = Vector2.Normalize(_direction);
                    }
                }
            }
            else
            {
                Move(dt);
                ResolveColisionWithObjects<Pad>();
                ResolveColisionWithObjects<Brick>();
                ResolveColisionWithObjects<BrickSword>();
                ResolveColisionWithObjects<BrickMagic>();
                ResolveColisionWithObjects<BrickArmor>();
                BounceOnBounds();
                CheckOutOfBounds();
            }
        }

        private void Move(float dt)
        {
            _velocity = _direction * _speed * dt;
            position += _velocity;
        }

        private void ResolveColisionWithObjects<T>() where T : SpriteGameObject
        {
            var objects = root.GetGameObjects<T>();
            foreach ( SpriteGameObject obj in objects )
            {
                if ( !obj.enable ) continue; //escape le code et passe a la boucle suivante
                if(collider.Intersects(obj.collider))
                {
                    float depthX = Math.Min(collider.Right - obj.collider.Left, obj.collider.Right - collider.Left);//ou est ce que coliisionne ma balle 
                    float depthY = Math.Min(collider.Bottom - obj.collider.Top, obj.collider.Bottom - collider.Top);

                    if(depthX < depthY) //colision horizontale
                    {
                        if(collider.Right > obj.collider.Left && collider.Left < obj.collider.Left)
                        {
                            position.X = obj.collider.Left - offset.X;
                            _direction.X *= -1;
                        }
                        else if(collider.Left < obj.collider.Right && collider.Right > obj.collider.Right)
                        {
                            position.X = obj.collider.Right + offset.X;
                            _direction.X *= -1;
                        }
                    }
                    else // verticale
                    {
                        if (collider.Bottom > obj.collider.Top && collider.Top < obj.collider.Top)
                        {
                            position.Y = obj.collider.Top - offset.Y;
                            _direction.Y *= -1;
                        }
                        else if (collider.Top < obj.collider.Bottom && collider.Bottom > obj.collider.Bottom)
                        {
                            position.Y = obj.collider.Bottom + offset.Y;
                            _direction.Y *= -1;
                        }
                    }
                    _direction = Vector2.Normalize(_direction);
                    obj.OnCollide(this);
                }
            }
        }

        private void CheckOutOfBounds()
        {
            if (position.Y > _bounds.Bottom + 100f)
            {
                ServiceLocator.Get<GameController>().BallOut();
                //renvoyer un msg Perdu
                _sticked = true;
            }
        }

        private void BounceOnBounds()
        {
            if (position.X > _bounds.Right - offset.X)
            {
                position.X = _bounds.Right - offset.X;
                _direction.X *= -1;
            }
            else if (position.X < _bounds.Left - offset.X)
            {
                position.X = _bounds.Left - offset.X;
                _direction.X *= -1;
            }
            if (position.Y < _bounds.Top + offset.Y)
            {
                position.Y = _bounds.Top + offset.Y;
                _direction.Y *= -1;
            }
            _direction = Vector2.Normalize(_direction);
        }

    }
}
