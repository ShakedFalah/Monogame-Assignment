using Microsoft.Xna.Framework;
using MonogameProject.MyEngine.Attributes;
using MonogameProject.MyEngine.GameObjects;

namespace MonogameProject.MyEngine.Components
{
    public enum RigidbodyType
    {
        Static,
        Dynamic,
        Kinematic
    }

    [RequireComponent(typeof(Collider))]
    internal class Rigidbody : Component
    {
        public Vector2 Velocity { get; private set; } = Vector2.Zero;
        public float GravityScale { get; set; } = 1f;
        public Collider Collider { get; private set; }
        public float Drag { get; set; } = 1f;
        public RigidbodyType Type { get; set; } = RigidbodyType.Dynamic;

        public override void Initialize(GameObject gameObject)
        {
            base.Initialize(gameObject);
            Collider = gameObject.GetComponent<Collider>();
        }

        public void AddForce(Vector2 force)
        {
            Velocity += force;
        }

        public void SetVelocity(Vector2 velocity)
        {
            this.Velocity = velocity;
        }
    }
}
