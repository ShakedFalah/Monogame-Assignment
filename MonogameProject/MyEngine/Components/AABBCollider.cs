using Microsoft.Xna.Framework;
using System;

namespace MonogameProject.MyEngine.Components
{
    internal class AABBCollider : Component
    {
        public bool isTrigger = false;
        private Point offSet = Point.Zero;
        private Point? _overrideSize = null;

        public Rectangle GetCollider()
        {
            Point baseSize = GetBaseSize();

            Point scaledSize = new Point(
                (int)Math.Round(baseSize.X * gameObject.Transform.scale.X),
                (int)Math.Round(baseSize.Y * gameObject.Transform.scale.Y));

            Point position = new Point(
                (int)Math.Round(gameObject.Transform.position.X - scaledSize.X * 0.5f),
                (int)Math.Round(gameObject.Transform.position.Y - scaledSize.Y * 0.5f));

            Point scaledOffset = new Point(
                (int)Math.Round(offSet.X * gameObject.Transform.scale.X),
                (int)Math.Round(offSet.Y * gameObject.Transform.scale.Y));

            position += scaledOffset;
            return new Rectangle(position, scaledSize);
        }
        public void SetSize(Point? size)
        {
            this._overrideSize = size;
        }

        private Point GetBaseSize()
        {
            if (_overrideSize.HasValue)
            {
                return _overrideSize.Value;
            }

            SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();

            if (renderer == null)
            {
                throw new InvalidOperationException(
                    "Collider requires either an explicit size or a SpriteRenderer.");
            }

            return renderer.size.ToPoint();
        }
    }
}
