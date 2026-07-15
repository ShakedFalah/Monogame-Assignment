using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.MyEngine.Interfaces;
using MonogameProject.MyEngine.Rendering;
using MonogameProject.MyEngine.Sprites;
using System.Text;

namespace MonogameProject.MyEngine.Components
{
    // A component to render text on screen
    internal class UIText : Component, IRenderable
    {
        public Color color = Color.Black;
        public SpriteEffects spriteEffects;
        private TextSprite _textSprite;
        private RenderLayer _layer;
        private int _orderInLayer;

        public UIText() : base()
        {
            SetLayer(Engine.LayerManager.GetLayer("Default"));
            _textSprite = new TextSprite();
        }

        public RenderLayer Layer()
        {
            return _layer;
        }

        public int OrderInLayer()
        {
            return _orderInLayer;
        }

        public void Render(SpriteBatch spriteBatch)
        {
            Transform transform = gameObject.Transform;
            spriteBatch.DrawString(_textSprite.font, _textSprite.text, transform.position, color, transform.rotation, _textSprite.AbsolutePivot, transform.scale, spriteEffects, 0);
        }

        public UIText SetLayer(RenderLayer layer)
        {
            _layer = layer;
            return this;
        }
        public UIText SetOrder(int order)
        {
            _orderInLayer = order;
            return this;
        }

        public void SetText(string text)
        {
            _textSprite.text = new StringBuilder(text);
        }

        public void SetFont(SpriteFont font)
        {
            _textSprite.font = font;
        }
    }
}
