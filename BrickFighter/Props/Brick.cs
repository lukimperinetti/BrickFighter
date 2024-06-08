using BrickFighter.Controllers;
using BrickFighter.GameObjects;
using BrickFighter.Scenes;
using BrickFighter.Services;
using Microsoft.Xna.Framework.Graphics;


namespace BrickFighter.Props
{
    public class Brick : SpriteGameObject
    {
        public Brick(Scene root) : base(root)
        {
            texture = ServiceLocator.Get<IAssetsService>().Get<Texture2D>("Brick");
        }

        public override void OnCollide(SpriteGameObject other)
        {
            enable = false;
            isFree = true;
        }
    }
}
