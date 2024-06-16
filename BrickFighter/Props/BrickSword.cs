using BrickFighter.Controllers;
using BrickFighter.GameObjects;
using BrickFighter.Scenes;
using BrickFighter.Services;
using Microsoft.Xna.Framework.Graphics;

namespace BrickFighter.Props
{
    public class BrickSword : SpriteGameObject
    {
        private const string sword = "sword";

        public BrickSword(Scene root) : base(root)
        {
            texture = ServiceLocator.Get<IAssetsService>().Get<Texture2D>("BrickSword");
        }

        public override void OnCollide(SpriteGameObject other)
        {
            ServiceLocator.Get<EntityGameController>().AddBuff("sword");
            enable = false;
            isFree = true;
        }
    }
}
