using Microsoft.Xna.Framework;
using System;

namespace MonogameProject.MyEngine.Components
{
    internal class Collider : Component
    {
        public bool IsTrigger { get; set; }
        private Point offSet = Point.Zero;
        private Point? _overrideSize = null;

        public event Action<Collider> OnCollisionEnter;
        public event Action<Collider> OnCollisionStay;
        public event Action<Collider> OnCollisionExit;

        public event Action<Collider> OnTriggerEnter;
        public event Action<Collider> OnTriggerStay;
        public event Action<Collider> OnTriggerExit;

        public Rectangle GetCollider()
        {
            Point baseSize = GetBaseSize();

            Point scaledSize = new(
                (int)Math.Round(baseSize.X * gameObject.Transform.scale.X),
                (int)Math.Round(baseSize.Y * gameObject.Transform.scale.Y));

            Point position = new(
                (int)Math.Round(gameObject.Transform.position.X - scaledSize.X * 0.5f),
                (int)Math.Round(gameObject.Transform.position.Y - scaledSize.Y * 0.5f));

            Point scaledOffset = new(
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

        public bool CheckCollision(Collider other)
        {
            return GetCollider().Intersects(other.GetCollider());
        }

        public void CollisionEnter(Collider other)
        {
            OnCollisionEnter?.Invoke(other);
        }

        public void CollisionStay(Collider other)
        {
            OnCollisionStay?.Invoke(other);
        }

        public void CollisionExit(Collider other)
        {
            OnCollisionExit?.Invoke(other);
        }

        public void TriggerEnter(Collider other)
        {
            OnTriggerEnter?.Invoke(other);
        }

        public void TriggerStay(Collider other)
        {
            OnTriggerStay?.Invoke(other);
        }

        public void TriggerExit(Collider other)
        {
            OnTriggerExit?.Invoke(other);
        }
    }
}
