using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.MyEngine.Interfaces;
using System;
using System.Collections.Generic;

namespace MonogameProject.MyEngine.Services
{
    internal class SceneManager : ISystem
    {
        public Scene ActiveScene { get; private set; }
        private Dictionary<string, Scene> _scenes;
        private GraphicsDevice _graphicsDevice;
        public SceneManager(GraphicsDevice graphicsDevice) 
        {
            _graphicsDevice = graphicsDevice;
            _scenes = new Dictionary<string, Scene>();
        }

        public void Update(GameTime gameTime)
        {
            ActiveScene.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            ActiveScene.Draw(gameTime);
        }

        public void SetScene(string sceneName)
        {
            Scene loadedScene;
            if (!_scenes.TryGetValue(sceneName, out loadedScene))
            {
                throw new KeyNotFoundException($"Scene '{sceneName}' was not found.");
            }
            ActiveScene = loadedScene;
            ActiveScene.Start();
        }

        public Scene AddScene(string sceneName)
        {
            if (_scenes.ContainsKey(sceneName))
            {
                throw new ArgumentException($"A scene named '{sceneName}' already exists.");
            }

            Scene newScene = new Scene(_graphicsDevice);
            _scenes.Add(sceneName, newScene);
            return newScene;
        }

        public Scene GetScene(string sceneName)
        {
            Scene sceneToGet;
            if (!_scenes.TryGetValue(sceneName, out sceneToGet))
            {
                throw new KeyNotFoundException($"Scene '{sceneName}' was not found.");
            }
            return sceneToGet;
        }

        public void RemoveScene(string sceneName)
        {
            if (!_scenes.Remove(sceneName))
            {
                throw new KeyNotFoundException($"Scene '{sceneName}' was not found.");
            }

        }
    }
}
