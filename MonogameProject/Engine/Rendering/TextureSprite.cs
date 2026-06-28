using Microsoft.Xna.Framework.Graphics;

namespace MonogameProject.Engine.Rendering
{
    internal class TextureSprite : Sprite
    {
        private Texture2D _texture;
        
        public override Texture2D Texture()
        {
            return _texture;
        }

        public void SetTexture(Texture2D texture)
        {
            this._texture = texture;
        }
    }
}
