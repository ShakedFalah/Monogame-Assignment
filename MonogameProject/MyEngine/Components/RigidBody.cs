using Microsoft.Xna.Framework;
using MonogameProject.MyEngine.Attributes;

namespace MonogameProject.MyEngine.Components
{
    [RequireComponent(typeof(Collider))]
    internal class Rigidbody : Component
    {
        public Vector2 Velocity { get; set; }
        public float GravityScale { get; set; } = 1f;
        public bool IsKinematic { get; set; }
    }
}
