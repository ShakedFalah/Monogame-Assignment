using Microsoft.Xna.Framework;
using MonogameProject.Engine.Statics;

namespace MonogameProject.Engine
{
    internal class Scene
    {
        public UpdateManager UpdateManager { get; } = new();

        public void Update(GameTime gameTime)
        {
            UpdateManager.Update(gameTime);
        }
    }
}
