using BrickFighter.Controllers;
using BrickFighter.GameObjects;
using BrickFighter.Scenes;
using BrickFighter.Services;
using Microsoft.Xna.Framework.Graphics;


namespace BrickFighter.Props
{
    public class BrickMagic : SpriteGameObject
    {
        private const string magicPower = "magic";
        public BrickMagic(Scene root) : base(root)
        {
            texture = ServiceLocator.Get<IAssetsService>().Get<Texture2D>("BrickMagic");
        }

        public override void OnCollide(SpriteGameObject other)
        {
            ServiceLocator.Get<EntityGameController>().AddBuff(magicPower);
            enable = false;
            isFree = true;
        }
    }
}
