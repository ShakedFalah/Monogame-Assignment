using MonogameProject.Engine.Components;
using MonogameProject.Engine.Systems;
using System;
using System.Collections.Generic;

namespace MonogameProject.Engine.GameObjects
{
    internal class GameObject
    {
        public Scene Scene { get; }
        public Transform Transform { get; }
        private readonly Dictionary<Type, Component> _components = [];
        internal GameObject(Scene scene)
        {
            this.Scene = scene;
            this.Transform = new Transform();
        }

        public T AddComponent<T>() where T : Component, new()
        {
            var type = typeof(T);
            if (_components.ContainsKey(type))
            {
                throw new Exception($"Component {type} already exists");
            }
            T component = new()
            {
                parent = this
            };
            _components[type] = component;
            Scene.UpdateManager.TryRegister(component);

            return component;
        }

        public T GetComponent<T>() where T : Component
        {
            if (_components.TryGetValue(typeof(T), out var component))
            {
                return (T)component;
            }

            return null;
        }

        public bool HasComponent<T>() where T : Component 
        {
            return _components.ContainsKey(typeof(T));
        }
    }
}
