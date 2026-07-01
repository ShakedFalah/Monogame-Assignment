using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameProject.MyEngine.Sprites
{
    internal class TextureSprite : Sprite
    {
        private Texture2D _texture;
        
        public override Texture2D Texture()
        {
            return _texture;
        }

        public override Vector2 Size => SourceRectangle.Size.ToVector2();

        public void SetTexture(Texture2D texture)
        {
            this._texture = texture;
            SetSourceRectangle(texture.Bounds);
        }
    }
}
