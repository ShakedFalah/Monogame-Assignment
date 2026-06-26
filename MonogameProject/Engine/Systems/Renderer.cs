using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Engine.Interfaces;
using System;
using System.Collections.Generic;

namespace MonogameProject.Engine.Systems
{
    internal class Renderer : ISystem
    {
        private HashSet<Interfaces.IDrawable> drawables;
        private readonly SpriteBatch _spriteBatch;

        public Renderer(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }

        public void Update(GameTime gameTime)
        {
            _spriteBatch.Begin();
            foreach (var drawable in drawables)
            {
                drawable.Draw(_spriteBatch);
            }
            _spriteBatch.End();
        }
    }
}
