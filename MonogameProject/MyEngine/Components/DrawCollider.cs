using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.MyEngine.Attributes;
using MonogameProject.MyEngine.GameObjects;
using MonogameProject.MyEngine.Interfaces;
using MonogameProject.MyEngine.Rendering;
using MonogameProject.MyEngine.Sprites;

namespace MonogameProject.MyEngine.Components
{
    [RequireComponent(typeof(Collider))]
    internal class DrawCollider : Component, IRenderable
    {
        public Color color;
        public int thickness = 1;
        private int _orderInLayer;
        private RenderLayer _layer;
        private Collider _collider;
        private SolidColorSprite _sprite;

        public DrawCollider()
        {
            SetLayer(Engine.LayerManager.GetLayer("Default"));
        }

        public override void Initialize(GameObject gameObject)
        {
            base.Initialize(gameObject);

            _collider = gameObject.GetComponent<Collider>();
            _sprite = new SolidColorSprite(Color.White);
        }

        public RenderLayer Layer()
        {
            return _layer;
        }

        public int OrderInLayer()
        {
            return _orderInLayer;
        }

        public DrawCollider SetLayer(RenderLayer layer)
        {
            _layer = layer;
            return this;
        }
        public DrawCollider SetOrder(int order)
        {
            _orderInLayer = order;
            return this;
        }


        public void Render(SpriteBatch spriteBatch)
        {
            Rectangle bounds = _collider.Bounds.Value;

            // Top
            spriteBatch.Draw(
                _sprite.Texture(),
                new Rectangle(
                    bounds.Left,
                    bounds.Top,
                    bounds.Width,
                    thickness),
                color);

            // Bottom
            spriteBatch.Draw(
                _sprite.Texture(),
                new Rectangle(
                    bounds.Left,
                    bounds.Bottom - thickness,
                    bounds.Width,
                    thickness),
                color);

            // Left
            spriteBatch.Draw(
                _sprite.Texture(),
                new Rectangle(
                    bounds.Left,
                    bounds.Top,
                    thickness,
                    bounds.Height),
                color);

            // Right
            spriteBatch.Draw(
                _sprite.Texture(),
                new Rectangle(
                    bounds.Right - thickness,
                    bounds.Top,
                    thickness,
                    bounds.Height),
                color);
        }
    }
}
