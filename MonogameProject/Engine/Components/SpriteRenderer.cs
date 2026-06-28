using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Engine.GameObjects;
using MonogameProject.Engine.Rendering;

namespace MonogameProject.Engine.Components
{
    internal class SpriteRenderer : Component, Interfaces.IRenderable
    {
        public Sprite sprite;
        public Color tint;
        public Vector2 origin;
        public SpriteEffects effects;
        public Vector2 size;
        private int _orderInLayer;
        private RenderLayer _layer;
        public Rectangle DestinationRectangle { get; private set; }

        public SpriteRenderer(GameObject parent) : base(parent)
        {
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
            DestinationRectangle = new Rectangle(gameObject.Transform.position, new Point((int)(size.X * gameObject.Transform.scale.X), (int)(size.Y * gameObject.Transform.scale.Y)));
            spriteBatch.Draw(sprite.Texture(), DestinationRectangle, sprite.SourceRectangle, 
                tint, gameObject.Transform.rotation, origin, effects, 0);
        }

        public Vector2 RelativeOrigin()
        {
            return new Vector2(sprite.Texture().Width * origin.X, sprite.SourceRectangle.Height * origin.Y);
        }
    }
}
