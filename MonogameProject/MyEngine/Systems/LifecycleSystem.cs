using Microsoft.Xna.Framework;
using MonogameProject.MyEngine.Interfaces;
using System.Collections.Generic;

namespace MonogameProject.MyEngine.Systems
{
    internal class LifecycleSystem : ISystem, Interfaces.IRegisterable<object>
    {
        private HashSet<Interfaces.IStartable> _startables = [];
        private HashSet<Interfaces.IUpdateable> _updateables = [];

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
        }
    }
}
