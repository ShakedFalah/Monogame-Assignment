using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.MyEngine.Services;

namespace MonogameProject.MyEngine.Sprites
{
    internal class SolidColorSprite : Sprite
    {
        private readonly Texture2D _colorTexture;

        public SolidColorSprite(Color color) : base()
        {
            _colorTexture = new Texture2D(GraphicsManager.GraphicsDevice, 1, 1);
            _colorTexture.SetData([color]);
            SetSourceRectangle(new Rectangle(0, 0, 1, 1));
        }

        public override Texture2D Texture() => _colorTexture;
    }
}
