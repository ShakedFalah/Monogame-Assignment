using Microsoft.Xna.Framework;
using MonogameProject.MyEngine.Components;
using System;
using System.Runtime.CompilerServices;

namespace MonogameProject.MyEngine.Physics
{
    internal readonly struct CollisionPair : IEquatable<CollisionPair>
    {
        public Collider A { get; }
        public Collider B { get; }

        public CollisionPair(Collider a, Collider b, bool isTrigger = false)
        {
            if (a.Id < b.Id)
            {
                A = a;
                B = b;
            }
            else
            {
                A = b;
                B = a;
            }

        }
        public bool Equals(CollisionPair other)
        {
            return ReferenceEquals(A, other.A) &&
                   ReferenceEquals(B, other.B);
        }

        public override bool Equals(object obj)
        {
            return obj is CollisionPair other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(A.Id, B.Id);
        }
    }
}
