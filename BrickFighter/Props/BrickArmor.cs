using BrickFighter.Controllers;
using BrickFighter.GameObjects;
using BrickFighter.Scenes;
using BrickFighter.Services;
using Microsoft.Xna.Framework.Graphics;

namespace BrickFighter.Props
{
    public class BrickArmor : SpriteGameObject
    {
        private const string armor = "armor";
        public BrickArmor(Scene root) : base(root)
        {
            texture = ServiceLocator.Get<IAssetsService>().Get<Texture2D>("BrickArmor");
        }

        public override void OnCollide(SpriteGameObject other)
        {
            ServiceLocator.Get<EntityGameController>().AddBuff("armor");
            enable = false;
            isFree = true;
        }
    }
}
