using Microsoft.Xna.Framework;
using MonogameProject.MyEngine.GameObjects;
using System;

namespace MonogameProject.MyEngine.Components
{
    internal class Collider : Component
    {
        public bool IsTrigger { get; set; }
        private Point offSet = Point.Zero;
        private Point? _overrideSize = null;
        public Rectangle? Bounds { get; private set; }

        public event Action<Collider> OnCollisionEnter;
        public event Action<Collider> OnCollisionStay;
        public event Action<Collider> OnCollisionExit;

        public event Action<Collider> OnTriggerEnter;
        public event Action<Collider> OnTriggerStay;
        public event Action<Collider> OnTriggerExit;

        public override void Initialize(GameObject parent)
        {
            base.Initialize(parent);

            gameObject.Transform.OnTransformChanged += (transform) => UpdateCollider();
            UpdateCollider();
        }
        public void UpdateCollider()
        {
            if (!TryGetBaseSize(out Point baseSize))
            {
                Bounds = null;
                return;
            }

            Point scaledSize = new(
                (int)Math.Round(baseSize.X * gameObject.Transform.Scale.X),
                (int)Math.Round(baseSize.Y * gameObject.Transform.Scale.Y));

            Point position = new(
                (int)Math.Round(gameObject.Transform.Position.X - scaledSize.X * 0.5f),
                (int)Math.Round(gameObject.Transform.Position.Y - scaledSize.Y * 0.5f));

            Point scaledOffset = new(
                (int)Math.Round(offSet.X * gameObject.Transform.Scale.X),
                (int)Math.Round(offSet.Y * gameObject.Transform.Scale.Y));

            position += scaledOffset;
            Bounds = new Rectangle(position, scaledSize);
        }
        public void SetSize(Point? size)
        {
            this._overrideSize = size;
            UpdateCollider();
        }

        private bool TryGetBaseSize(out Point size)
        {
            if (_overrideSize.HasValue)
            {
                size = _overrideSize.Value;
                return true;
            }

            SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();

            if (renderer != null)
            {
                size = renderer.size.ToPoint();
                return true;
            }

            size = default;
            return false;
        }

        public bool CheckCollision(Collider other)
        {
            return Bounds.Value.Intersects(other.Bounds.Value);
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
