using Microsoft.Xna.Framework;
using MonogameProject.MyEngine.Components;
using MonogameProject.MyEngine.Interfaces;
using MonogameProject.MyEngine.Physics;
using System;
using System.Collections.Generic;

namespace MonogameProject.MyEngine.Systems
{
    internal class PhysicsSystem : IFixedUpdateSystem, Interfaces.IRegisterable<object>
    {
        private readonly List<Collider> _colliders = new();
        private readonly List<Rigidbody> _rigidbodies = new();
        private readonly Dictionary<CollisionPair, CollisionInfo> _previous = new();
        private readonly Dictionary<CollisionPair, CollisionInfo> _current = new(); public Vector2 Gravity { get; set; } = new Vector2(0, 980);

        public void FixedUpdate(float deltaTime)
        {
            MoveRigidbodies(deltaTime);

            DetectCollisions();

            ResolvePhysics();

            ProcessCollisionEvents();
        }

        private void DetectCollisions()
        {
            _current.Clear();

            for (int i = 0; i < _colliders.Count; i++)
            {
                for (int j = i + 1; j < _colliders.Count; j++)
                {
                    Collider first = _colliders[i];
                    Collider second = _colliders[j];

                    CollisionPair pair = new(first, second);

                    if (first.TryGetCollisionInfo(second, out CollisionInfo info))
                    {
                        _current.Add(pair, info);
                    }
                }
            }
        }

        private void MoveRigidbodies(float deltaTime)
        {
            foreach (Rigidbody body in _rigidbodies)
            {
                if (body.Type == RigidbodyType.Static)
                {
                    continue;
                }

                if (body.Type == RigidbodyType.Dynamic)
                {
                    ApplyGravity(body, deltaTime);
                    ApplyDrag(body, deltaTime);
                }

                Vector2 movement = body.Velocity * deltaTime;

                body.gameObject.Transform.Position += movement;

            }
        }

        private void ResolvePhysics()
        {
            foreach (CollisionInfo info in _current.Values)
            {
                if (info.IsTrigger)
                    continue;

                ResolveCollision(info);
            }
        }

        private void ProcessCollisionEvents()
        {
            foreach (var pair in _current)
            {
                CollisionPair collisionPair = pair.Key;
                CollisionInfo info = pair.Value;

                if (_previous.ContainsKey(collisionPair))
                {
                    if (info.IsTrigger)
                    {
                        collisionPair.A.TriggerStay(collisionPair.B);
                        collisionPair.B.TriggerStay(collisionPair.A);
                    }
                    else
                    {
                        collisionPair.A.CollisionStay(collisionPair.B);
                        collisionPair.B.CollisionStay(collisionPair.A);
                    }
                }
                else
                {
                    if (info.IsTrigger)
                    {
                        collisionPair.A.TriggerEnter(collisionPair.B);
                        collisionPair.B.TriggerEnter(collisionPair.A);
                    }
                    else
                    {
                        collisionPair.A.CollisionEnter(collisionPair.B);
                        collisionPair.B.CollisionEnter(collisionPair.A);
                    }
                }
            }


            foreach (var pair in _previous)
            {
                if (!_current.ContainsKey(pair.Key))
                {
                    if (pair.Value.IsTrigger)
                    {
                        pair.Key.A.TriggerExit(pair.Key.B);
                        pair.Key.B.TriggerExit(pair.Key.A);
                    }
                    else
                    {
                        pair.Key.A.CollisionExit(pair.Key.B);
                        pair.Key.B.CollisionExit(pair.Key.A);
                    }
                }
            }


            _previous.Clear();

            foreach (var pair in _current)
            {
                _previous.Add(pair.Key, pair.Value);
            }
        }

        private void ResolveCollision(CollisionInfo info)
        {
            Rigidbody bodyA =
                info.A.gameObject.GetComponent<Rigidbody>();

            Rigidbody bodyB =
                info.B.gameObject.GetComponent<Rigidbody>();

            bool dynamicA = bodyA != null && bodyA.Type == RigidbodyType.Dynamic;
            bool dynamicB = bodyB != null && bodyB.Type == RigidbodyType.Dynamic;


            if (dynamicA && dynamicB)
            {
                MoveOut(bodyA, -info.Normal, info.Penetration * 0.5f);
                MoveOut(bodyB, info.Normal, info.Penetration * 0.5f);

                StopVelocity(bodyA, info.Normal);
                StopVelocity(bodyB, -info.Normal);
            }
            else if (dynamicA)
            {
                MoveOut(bodyA, -info.Normal, info.Penetration);
                StopVelocity(bodyA, info.Normal);
            }
            else if (dynamicB)
            {
                MoveOut(bodyB, info.Normal, info.Penetration);
                StopVelocity(bodyB, -info.Normal);
            }
        }

        private void MoveOut(Rigidbody body, Vector2 normal, float penetration)
        {
            body.gameObject.Transform.Position +=
                normal * penetration;
        }

        private void StopVelocity(Rigidbody body, Vector2 normal)
        {
            float velocityIntoSurface =
                Vector2.Dot(body.Velocity, normal);

            if (velocityIntoSurface < 0)
            {
                body.SetVelocity(
                    body.Velocity - velocityIntoSurface * normal
                );
            }
        }
        private void ApplyGravity(Rigidbody body, float deltaTime)
        {
            body.SetVelocity(
                body.Velocity + Gravity * body.GravityScale * deltaTime
            );
        }

        private void ApplyDrag(Rigidbody body, float deltaTime)
        {
            body.SetVelocity(
                body.Velocity * MathF.Exp(-body.Drag * deltaTime)
            );
        }

        public void Register(object subscriber)
        {
            if (subscriber is Collider collider && !_colliders.Contains(collider))
            {
                _colliders.Add(collider);
            }
            if (subscriber is Rigidbody rigidbody && !_rigidbodies.Contains(rigidbody))
            {
                _rigidbodies.Add(rigidbody);
            }
        }

        public void Unregister(object subscriber)
        {
            if (subscriber is Collider collider)
            {
                _colliders.Remove(collider);
            }
            if (subscriber is Rigidbody rigidbody)
            {
                _rigidbodies.Remove(rigidbody);
            }
        }
    }
}
