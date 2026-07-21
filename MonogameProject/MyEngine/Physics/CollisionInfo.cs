using Microsoft.Xna.Framework;
using MonogameProject.MyEngine.Components;

namespace MonogameProject.MyEngine.Physics
{
    internal readonly struct CollisionInfo
    {
        public Collider A { get; }
        public Collider B { get; }

        public Vector2 Normal { get; }
        public float Penetration { get; }

        public bool IsTrigger { get; }

        public CollisionInfo(
            Collider a,
            Collider b,
            Vector2 normal,
            float penetration)
        {
            A = a;
            B = b;
            Normal = normal;
            Penetration = penetration;
            IsTrigger = a.IsTrigger || b.IsTrigger;
        }
    }
}
