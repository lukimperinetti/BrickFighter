using Microsoft.Xna.Framework;

namespace BrickFighter.Services
{
    public interface IScreenService
    {
        int Width { get; }
        int Height { get; }
        int Top { get; }
        int Left { get; }
        int Bottom { get; }
        int Right { get; }
        Vector2 TopLeft { get; }
        Vector2 BotRight { get; }
        Vector2 Center { get; }
        Rectangle Bounds { get; }
    }

    public sealed class ScreenService : IScreenService
    {
        private GraphicsDeviceManager _graphicsDeviceManager;
        public ScreenService(GraphicsDeviceManager graphicsDeviceManager)
        {
            _graphicsDeviceManager = graphicsDeviceManager;
            ServiceLocator.Register<IScreenService>(this);
        }

        public int Width => _graphicsDeviceManager.PreferredBackBufferWidth;
        public int Height => _graphicsDeviceManager.PreferredBackBufferHeight;
        public int Top => 0;
        public int Left => 0;
        public int Bottom => Height;
        public int Right => Width;
        public Vector2 TopLeft => Vector2.Zero;
        public Vector2 BotRight => new Vector2(Width, Height);
        public Vector2 Center => BotRight * .5f;
        public Rectangle Bounds => new Rectangle(Top, Left, Width, Height);

        public void SetSize(int width, int height)
        {
            _graphicsDeviceManager.PreferredBackBufferWidth = width;
            _graphicsDeviceManager.PreferredBackBufferHeight = height;
            _graphicsDeviceManager.ApplyChanges();
        }

    }
}
