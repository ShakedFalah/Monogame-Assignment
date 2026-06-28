using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Engine.GameObjects;
using MonogameProject.Engine.Rendering;

namespace MonogameProject.Engine.Components
{
    internal class SpriteRenderer : Component, Interfaces.IRenderable
    {
        public Sprite sprite = null;
        public Color tint = Color.White;
        public SpriteEffects effects = SpriteEffects.None;
        private int _orderInLayer;
        private RenderLayer _layer;
        public Rectangle DestinationRectangle { get; private set; }

        public SpriteRenderer() : base()
        {
            SetLayer(LayerManager.Instance.Get("Default"));
        }

        public RenderLayer Layer()
        {
            return _layer;
        }
        public int OrderInLayer()
        {
            return _orderInLayer;
        }
        public SpriteRenderer SetLayer(RenderLayer layer)
        {
            _layer = layer;
            return this;
        }
        public SpriteRenderer SetOrder(int order)
        {
            _orderInLayer = order;
            return this;
        }

        public void Render(SpriteBatch spriteBatch)
        {
            if (sprite == null)
            {
                return;
            }

            spriteBatch.Draw(
                sprite.Texture(),
                gameObject.Transform.position,
                sprite.SourceRectangle,
                tint,
                gameObject.Transform.rotation,
                sprite.AbsoluteOrigin,
                gameObject.Transform.scale,
                effects,
                0f);
        }
    }
}
