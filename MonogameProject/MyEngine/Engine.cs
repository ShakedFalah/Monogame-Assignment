using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.MyEngine.EngineManagers;
using MonogameProject.MyEngine.Rendering;
using System;

namespace MonogameProject.MyEngine
{
    internal class Engine
    {
        public static Engine Instance { get; private set; }

        public GraphicsManager GraphicsManager { get; private set; }
        public static AssetsManager Assets { get; private set; }
        private Engine(Game game)
        {
            if (Instance != null)
            {
                throw new InvalidOperationException("Engine already exists.");
            }

            GraphicsManager = new GraphicsManager(game);
            Assets = new AssetsManager(game.Content);

            game.Content.RootDirectory = "Content";
        }
        public static void Load(Game game)
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
        }
    }
}