using BrickFighter.GameObjects;
using BrickFighter.Scenes;
using BrickFighter.Services;
using Microsoft.Xna.Framework.Graphics;


namespace BrickFighter.Props
{
    public class BrickSword : SpriteGameObject
    {
        private const int points = 100;
        public BrickSword(Scene root) : base(root)
        {
            texture = ServiceLocator.Get<IAssetsService>().Get<Texture2D>("BrickSword");
        }

        public override void OnCollide(SpriteGameObject other)
        {
            ServiceLocator.Get<GameController>().AddPoints(points);
            enable = false;
            isFree = true;
        }
    }
}
