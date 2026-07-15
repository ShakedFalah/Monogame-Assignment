using Microsoft.Xna.Framework;
using MonogameProject.MyEngine.Interfaces;
using System.Collections.Generic;

namespace MonogameProject.MyEngine.Systems
{
    internal class LifecycleSystem : IUpdateSystem, IFixedUpdateSystem, Interfaces.IRegisterable<object>
    {
        private readonly HashSet<Interfaces.IStartable> _startables = [];
        private readonly HashSet<Interfaces.IUpdateable> _updateables = [];
        private readonly HashSet<Interfaces.IFixedUpdateable> _fixedUpdateables = [];

        public void Start()
        {
            foreach (var startable in _startables)
            {
                startable.Start();
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var updateable in _updateables)
            {
                updateable.Update(gameTime);
            }
        }

        public void FixedUpdate(float deltaTime)
        {
            foreach (var fixedUpdateable in _fixedUpdateables)
            {
                fixedUpdateable.FixedUpdate(deltaTime);
            }
        }

        public void Register(object subscriber)
        {
            if (subscriber == null)
            {
                return;
            }

            if (subscriber is IStartable startable)
            {
                _startables.Add(startable);
            }

            if (subscriber is Interfaces.IUpdateable updateable)
            {
                _updateables.Add(updateable);
            }

            if (subscriber is Interfaces.IFixedUpdateable fixedUpdateable)
            {
                _fixedUpdateables.Add(fixedUpdateable);
            }
        }

        public void Unregister(object subscriber)
        {
            if (subscriber is IStartable startable)
            {
                _startables.Remove(startable);
            }

            if (subscriber is Interfaces.IUpdateable updateable)
            {
                _updateables.Remove(updateable);
            }

            if (subscriber is Interfaces.IFixedUpdateable fixedUpdateable)
            {
                _fixedUpdateables.Remove(fixedUpdateable);
            }
        }

    }
}
