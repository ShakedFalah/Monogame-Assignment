using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.MyEngine.Interfaces;
using MonogameProject.MyEngine.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MonogameProject.MyEngine.Systems
{
    internal class RenderSystem : IRenderSystem, Interfaces.IRegisterable<object>
    {
        private GraphicsDevice _graphicsDevice;
        private readonly HashSet<Interfaces.IRenderable> _renderables;
        private readonly SpriteBatch _spriteBatch;

        public RenderSystem(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
            _spriteBatch = new SpriteBatch(graphicsDevice);
            _renderables = new();
        }

        public void Render()
        {
            _graphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(SpriteSortMode.Deferred);
            foreach (IRenderable renderable in _renderables
                .OrderBy(renderable => renderable.Layer().Order)
                .ThenBy(renderable => renderable.OrderInLayer()))
            {
                renderable.Render(_spriteBatch);
            }

            DebugDraw.Draw(_spriteBatch);
            _spriteBatch.End();
        }

        public void Register(object subscriber)
        {
            if (subscriber is Interfaces.IRenderable renderable)
            {
                _renderables.Add(renderable);
            }
        }

        public void Unregister(object subscriber)
        {
            if (subscriber is Interfaces.IRenderable renderable)
            {
                _renderables.Remove(renderable);
            }
        }
    }
}
