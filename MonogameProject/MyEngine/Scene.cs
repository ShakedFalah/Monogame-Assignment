using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.MyEngine.Systems;

namespace MonogameProject.MyEngine
{
    internal class Scene
    {
        public LifecycleSystem Lifecycle { get; }
        public RenderSystem Renderer { get; }
        public PhysicsSystem Physics { get; }

        public Scene(GraphicsDevice graphicsDevice)
        {
            this.Lifecycle = new();
            this.Renderer = new(graphicsDevice);
            this.Physics = new();
        }

        public void Start()
        {
            Lifecycle.Start();
        }

        public void Update(GameTime gameTime)
        {
            Lifecycle.Update(gameTime);
        }

        public void FixedUpdate(float deltaTiem)
        {
            Lifecycle.FixedUpdate(deltaTiem);
            Physics.FixedUpdate(deltaTiem);
        }

        public void Draw(GameTime gameTime)
        {
            Physics.Render();
            Renderer.Render();
        }

        public void RegisterAll(object obj)
        {
            Physics.Register(obj);
            Lifecycle.Register(obj);
            Renderer.Register(obj);
        }

        public void UnregisterAll(object obj)
        {
            Physics.Unregister(obj);
            Lifecycle.Unregister(obj);
            Renderer.Unregister(obj);
        }

    }
}
