using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameProject.Engine.Rendering
{
    internal abstract class Sprite
    {
        protected Rectangle _sourceRectangle;
        public Rectangle SourceRectangle => _sourceRectangle;
        public SpriteOrigin SpriteOrigin { get; private set; } = new SpriteOrigin();
        public Vector2 AbsoluteOrigin
        {
            get
            {
                if (SpriteOrigin.originType == OriginType.relative)
                {
                    return OriginHelper.RelativeToAbsolute(SpriteOrigin.origin, _sourceRectangle.Size);
                }

                return SpriteOrigin.origin;
            }
        }

        protected void SetSourceRectangle(Rectangle rect)
        {
            _sourceRectangle = rect;
        }

        public void SetOrigin(SpriteOrigin origin)
        {
            SpriteOrigin = origin;
        }

        public void SetOrigin(Vector2 origin, OriginType originType = OriginType.absolute)
        {
            SpriteOrigin = new SpriteOrigin(origin, originType);
        }
        public abstract Texture2D Texture();
    }
}
