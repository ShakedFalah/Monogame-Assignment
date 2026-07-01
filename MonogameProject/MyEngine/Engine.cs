using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.MyEngine.Rendering;
using MonogameProject.MyEngine.Services;
using System;

namespace MonogameProject.MyEngine
{
    internal class Engine
    {
        public static Engine Instance { get; private set; }

        public static readonly string defaultName = "Default";
        public GraphicsManager GraphicsManager { get; private set; }
        public static AssetsManager Assets { get; private set; }
        public static SceneManager SceneManager { get; private set; }
        public static InputManager InputManager { get; private set; }
        public static LayerManager LayerManager { get; private set; }
        private Engine(Game game)
        {
            game.Content.RootDirectory = "Content";

            if (Instance != null)
            {
                throw new InvalidOperationException("Engine already exists.");
            }

            GraphicsManager = new GraphicsManager(game);
            Assets = new AssetsManager(game.Content);
            SceneManager = new SceneManager(game.GraphicsDevice);
            InputManager = new InputManager();
            LayerManager = new LayerManager();

        }
        public static void CreateInstance(Game game)
        {
            if (Instance == null)
            {
                Instance = new Engine(game);
            }
        }

        public void Initialize(GraphicsDevice graphicsDevice)
        {
            GraphicsManager.Initialize(graphicsDevice);
            LayerManager.Initialize();
            SceneManager.Initialize();
        }

        public void Load()
        {
            SceneManager.SetScene(SceneManager.DefaultScene);
        }

        public static void Update(GameTime gameTime)
        {
            InputManager.Update(gameTime);
            SceneManager.Update(gameTime);
        }

        public static void Draw(GameTime gameTime)
        {
            SceneManager.Draw(gameTime);
        }

    }
}