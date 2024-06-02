using BrickFighter.Props;
using BrickFighter.Services;
using Microsoft.Xna.Framework;

namespace BrickFighter.Scenes
{
    public class BrickScene : Scene
    {
        public override void Load()
        {
            var screen = ServiceLocator.Get<IScreenService>();
            Rectangle bounds = screen.Bounds;
            AddGameObject(new Pad(bounds, this));
        }
    }
}
