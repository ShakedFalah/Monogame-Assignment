using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.MyEngine.Rendering;
using MonogameProject.MyEngine.Sprites;

namespace MonogameProject.MyEngine.Components
{
    // Component that is used to render sprites on screen
    internal class SpriteRenderer : Component, Interfaces.IRenderable
    {
        public Sprite sprite = null;
        public Color tint = Color.White;
        public SpriteEffects effects = SpriteEffects.None;
        public Vector2 size { get; private set; } = Vector2.One;
        private int _orderInLayer;
        private RenderLayer _layer;


        public SpriteRenderer() : base()
        {
            SetLayer(Engine.LayerManager.GetLayer("Default"));
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

        public void SetSize(Vector2 size)
        {
            this.size = size;
        }

        public void Render(SpriteBatch spriteBatch)
        {
            if (sprite == null)
            {
                return;
            }

            Rectangle destinationRectangle = new Rectangle(gameObject.Transform.position.ToPoint(), (size * gameObject.Transform.scale).ToPoint());
            spriteBatch.Draw(
                sprite.Texture(),
                destinationRectangle,
                sprite.SourceRectangle,
                tint,
                gameObject.Transform.rotation,
                sprite.AbsolutePivot,
                effects,
                0f);
        }
    }
}
