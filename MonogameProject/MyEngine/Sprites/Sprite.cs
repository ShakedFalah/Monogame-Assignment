using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.MyEngine.Rendering;

namespace MonogameProject.MyEngine.Sprites
{
    internal abstract class Sprite : PivotObject
    {
        protected Rectangle _sourceRectangle;
        public Rectangle SourceRectangle => _sourceRectangle;
        public override Vector2 Size { get => _sourceRectangle.Size.ToVector2(); }

        protected void SetSourceRectangle(Rectangle rect)
        {
            _sourceRectangle = rect;
        }

        public abstract Texture2D Texture();
    }
}
