using Microsoft.Xna.Framework;
using MonogameProject.MyEngine.Components;
using MonogameProject.MyEngine.Interfaces;
using MonogameProject.MyEngine.Physics;
using System.Collections.Generic;

namespace MonogameProject.MyEngine.Systems
{
    internal class PhysicsSystem : ISystem, Interfaces.IRegisterable<object>
    {
        private readonly List<Collider> _colliders = new();
        private Dictionary<CollisionPair, bool> _previous = new();

        public void Update(GameTime gameTime)
        {
            Dictionary<CollisionPair, bool> current = new();

            for (int i = 0; i < _colliders.Count; i++)
            {
                for (int j = i + 1; j < _colliders.Count; j++)
                {
                    Collider first = _colliders[i];
                    Collider second = _colliders[j];

                    CollisionPair pair = new CollisionPair(first, second);

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
        }

        public void Unregister(object subscriber)
        {
            if (subscriber is Collider collider)
            {
                _colliders.Remove(collider);
            }
        }
    }
}
