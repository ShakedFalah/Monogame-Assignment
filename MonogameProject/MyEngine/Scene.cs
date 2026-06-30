using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.MyEngine.Systems;

namespace MonogameProject.MyEngine
{
    internal class Scene
    {
        public LifecycleSystem Lifecycle { get; }
        public RenderSystem Renderer { get; }
        public InputSystem Input { get; }

        public Scene(GraphicsDevice graphicsDevice)
        {
            this.Lifecycle = new();
            this.Renderer = new(graphicsDevice);
            this.Input = new();
        }

        public void Start()
        {
            Lifecycle.Start();
        }

        public void Update(GameTime gameTime)
        {
            Lifecycle.Update(gameTime);
            Input.Update(gameTime);
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
