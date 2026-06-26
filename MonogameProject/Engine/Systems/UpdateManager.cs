using Microsoft.Xna.Framework;
using MonogameProject.Engine.Interfaces;
using System.Collections.Generic;

namespace MonogameProject.Engine.Statics
{
    internal class UpdateManager : ISystem
    {
        private HashSet<Interfaces.IStartable> startables = [];
        private HashSet<Interfaces.IUpdateable> updateables = [];

        public void Start()
        {
            foreach (var startable in startables)
            {
                startable.Start();
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var updateable in updateables)
            {
                updateable.Update(gameTime);
            }
        }

        public void TryRegister(object obj)
        {
            if (obj == null)
            {
                return;
            }

            if (obj is IStartable)
            {
                startables.Add((IStartable)obj);
            }

            if (obj is Interfaces.IUpdateable)
            {
                updateables.Add((Interfaces.IUpdateable)obj);
            }

        }
    }
}
