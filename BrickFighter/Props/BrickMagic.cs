using BrickFighter.Controllers;
using BrickFighter.GameObjects;
using BrickFighter.Scenes;
using BrickFighter.Services;
using Microsoft.Xna.Framework.Graphics;

public class BrickMagic : SpriteGameObject
{
    private const string magic = "magic";

    public BrickMagic(Scene root) : base(root)
    {
        texture = ServiceLocator.Get<IAssetsService>().Get<Texture2D>("BrickMagic");
    }

    public override void OnCollide(SpriteGameObject other)
    {
        ServiceLocator.Get<EntityGameController>().AddBuff("magic");
        enable = false;
        isFree = true;
    }
}
