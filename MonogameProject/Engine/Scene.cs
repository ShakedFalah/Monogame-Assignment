using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Engine.Interfaces;
using MonogameProject.Engine.Statics;
using MonogameProject.Engine.Systems;

namespace MonogameProject.Engine
{
    internal class Scene
    {
        public LifecycleSystem Lifecycle { get; }
        public RenderSystem Renderer { get; }

        public Scene(GraphicsDevice graphicsDevice)
        {
            this.Lifecycle = new();
            this.Renderer = new(graphicsDevice);
        }

        public void Start()
        {
            Lifecycle.Start();
        }

        public void Update(GameTime gameTime)
        {
            Lifecycle.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            Renderer.Update(gameTime);
        }

        public void RegisterAll(object obj)
        {
            Lifecycle.Register(obj);
            Renderer.Register(obj);
        }

        public void UnregisterAll(object obj)
        {
            Lifecycle.Unregister(obj);
            Renderer.Unregister(obj);
        }

    }
}
