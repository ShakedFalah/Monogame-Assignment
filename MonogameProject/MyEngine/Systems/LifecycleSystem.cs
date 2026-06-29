using Microsoft.Xna.Framework;
using MonogameProject.MyEngine.Interfaces;
using System.Collections.Generic;

namespace MonogameProject.MyEngine.Statics
{
    internal class LifecycleSystem : ISystem, Interfaces.IObservable<object>
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

            if (subscriber is IStartable)
            {
                _startables.Add((IStartable)subscriber);
            }

            if (subscriber is Interfaces.IUpdateable)
            {
                _updateables.Add((Interfaces.IUpdateable)subscriber);
            }
        }

        public void Unregister(object subscriber)
        {
            if (subscriber is IStartable)
            {
                _startables.Remove((IStartable)subscriber);
            }

            if (subscriber is Interfaces.IUpdateable)
            {
                _updateables.Remove((Interfaces.IUpdateable)subscriber);
            }
        }
    }
}
