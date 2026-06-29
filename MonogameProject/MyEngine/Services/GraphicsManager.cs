using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameProject.MyEngine.Services
{
    internal class GraphicsManager
    {
        private const int DEFAULTWIDTH = 1920;
        private const int DEFAULTHEIGHT = 1080;
        public int Width => _graphics.PreferredBackBufferWidth;
        public int Height => _graphics.PreferredBackBufferHeight;

        public Vector2 ScreenCenter => new Vector2(Width * 0.5f, Height * 0.5f);
        public static GraphicsDevice GraphicsDevice { get; private set; }

        private GraphicsDeviceManager _graphics;
        public GraphicsManager(Game game)
        {
            _graphics = new GraphicsDeviceManager(game);

            game.IsMouseVisible = true;

            ApplyResolution(DEFAULTWIDTH, DEFAULTHEIGHT);
            SetFullScreen(true);
        }

        public void Initialize(GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
        }

        public void ApplyResolution(int width, int height)
        {
            _graphics.PreferredBackBufferWidth = width;
            _graphics.PreferredBackBufferHeight = height;
            _graphics.ApplyChanges();
        }

        public void SetFullScreen(bool isFullScreen)
        {
            _graphics.IsFullScreen = isFullScreen;
            _graphics.ApplyChanges();
        }
    }
}
