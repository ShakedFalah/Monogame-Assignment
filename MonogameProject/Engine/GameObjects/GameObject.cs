using MonogameProject.Engine.Components;
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
                gameObject = this
            };
            _components.Add(type, component);
            Scene.RegisterAll(component);

            return component;
        }

        public void RemoveComponent<T>() where T : Component
        {
            var type = typeof(T);
            if (!(_components.ContainsKey(type)))
            {
                throw new Exception($"Tried to remove component {type}, but it doesn't exist");
            }
            Component component = _components[type];
            _components.Remove(type);
            Scene.UnregisterAll(type);
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
