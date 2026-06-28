using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject.Engine.Rendering
{
    internal class SolidColorSprite : Sprite
    {
        private readonly Texture2D _colorTexture;

        public SolidColorSprite(Color color) : base()
        {
            _colorTexture = new Texture2D(Engine.GraphicsDevice, 2, 2);
            _colorTexture.SetData([color, color, color, color]);
            SetSourceRectangle(new Rectangle(0, 0, 2, 2));
        }

        public override Texture2D Texture() => _colorTexture;
    }
}
