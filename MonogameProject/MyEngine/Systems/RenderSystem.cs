using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.MyEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonogameProject.MyEngine.Systems
{
    internal class RenderSystem : ISystem, Interfaces.IObservable<object>
    {
        private GraphicsDevice _graphicsDevice;
        private HashSet<Interfaces.IRenderable> _renderables;
        private readonly SpriteBatch _spriteBatch;

        public RenderSystem(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
            _spriteBatch = new SpriteBatch(graphicsDevice);
            _renderables = new();
        }

        public void Update(GameTime gameTime)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred);
            foreach (IRenderable renderable in _renderables
                .OrderBy(renderable => renderable.Layer().Order)
                .ThenBy(renderable => renderable.OrderInLayer()))
            {
                renderable.Render(_spriteBatch);
            }
            _spriteBatch.End();
        }

        public void Register(object subscriber)
        {
            if (subscriber is Interfaces.IRenderable)
            {
                _renderables.Add((Interfaces.IRenderable)subscriber);
            }
        }

        public void Unregister(object subscriber)
        {
            if (subscriber is Interfaces.IRenderable)
            {
                _renderables.Remove((Interfaces.IRenderable)subscriber);
            }
        }
    }
}
