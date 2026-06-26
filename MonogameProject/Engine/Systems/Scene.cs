using Microsoft.Xna.Framework;
using MonogameProject.Engine.Interfaces;
using MonogameProject.Engine.Statics;

namespace MonogameProject.Engine.Systems
{
    internal class Scene : ISystem
    {
        public UpdateManager UpdateManager { get; } = new();

        public void Start()
        {
            UpdateManager.Start();
        }

        public void Update(GameTime gameTime)
        {
            UpdateManager.Update(gameTime);
        }
    }
}
