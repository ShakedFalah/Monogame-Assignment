using Microsoft.Xna.Framework;
using MonogameProject.MyEngine.Components;
using MonogameProject.MyEngine.Interfaces;
using MonogameProject.MyEngine.Physics;
using System.Collections.Generic;

namespace MonogameProject.MyEngine.Systems
{
    internal class PhysicsSystem : IFixedUpdateSystem, Interfaces.IRegisterable<object>
    {
        private readonly List<Collider> _colliders = new();
        private readonly List<Rigidbody> _rigidbodies = new();
        private Dictionary<CollisionPair, bool> _previous = new();
        public Vector2 Gravity { get; set; } = new Vector2(0, 980);

        public void FixedUpdate(float deltaTime)
        {
            ApplyGravity(deltaTime);
            MoveRigidBodies(deltaTime);
            ResolveCollisions();
        }

        private void ApplyGravity(float deltaTime)
        {
            foreach (Rigidbody body in _rigidbodies)
            {
                body.Velocity += Gravity * body.GravityScale * deltaTime;
            }
        }

        private void MoveRigidBodies(float deltaTime)
        {
            
        }

        private void ResolveCollisions()
        {
            Dictionary<CollisionPair, bool> current = new();

            for (int i = 0; i < _colliders.Count; i++)
            {
                for (int j = i + 1; j < _colliders.Count; j++)
                {
                    Collider first = _colliders[i];
                    Collider second = _colliders[j];

                    CollisionPair pair = new(first, second);

                    if (first.CheckCollision(second))
                    {
                        bool isTriggerInteraction;

                        if (_previous.TryGetValue(pair, out bool previousTrigger))
                        {
                            isTriggerInteraction = previousTrigger;

                            if (isTriggerInteraction)
                            {
                                first.TriggerStay(second);
                                second.TriggerStay(first);
                            }
                            else
                            {
                                first.CollisionStay(second);
                                second.CollisionStay(first);
                            }
                        }
                        else
                        {
                            isTriggerInteraction = first.IsTrigger || second.IsTrigger;

                            if (isTriggerInteraction)
                            {
                                first.TriggerEnter(second);
                                second.TriggerEnter(first);
                            }
                            else
                            {
                                first.CollisionEnter(second);
                                second.CollisionEnter(first);
                            }
                        }

                        current.Add(pair, isTriggerInteraction);
                    }
                    else if (_previous.TryGetValue(pair, out bool previousTrigger))
                    {
                        if (previousTrigger)
                        {
                            first.TriggerExit(second);
                            second.TriggerExit(first);
                        }
                        else
                        {
                            first.CollisionExit(second);
                            second.CollisionExit(first);
                        }
                    }
                }
            }

            _previous = current;
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
