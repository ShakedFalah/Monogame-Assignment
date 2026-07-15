using MonogameProject.MyEngine.Attributes;
using MonogameProject.MyEngine.Components;
using System;
using System.Collections.Generic;

namespace MonogameProject.MyEngine.GameObjects
{
    // The basic game object to represent everything inside a scene and contain components
    internal class GameObject
    {
        public Scene Scene { get; }
        public Transform Transform { get; }
        private readonly Dictionary<Type, Component> _components = [];
        private readonly HashSet<Type> _constructing = [];
        internal GameObject(Scene scene)
        {
            this.Scene = scene;
            this.Transform = new Transform();
        }

        public Component AddComponent(Type type)
        {
            if (_constructing.Contains(type))
            {
                return null;
            }

            _constructing.Add(type);
            foreach (var attribute in type.GetCustomAttributes(typeof(RequireComponentAttribute), true))
            {
                var require = (RequireComponentAttribute)attribute;

                if (!HasComponent(require.ComponentType))
                {
                    AddComponent(require.ComponentType);
                }
            }

            _constructing.Remove(type);
            if (_components.ContainsKey(type))
            {
                return GetComponent(type);
            }
            Component component = (Component)Activator.CreateInstance(type);
            component.Initialize(this);
            _components.Add(type, component);
            Scene.RegisterAll(component);

            return component;
        }

        public void RemoveComponent(Type type)
        {
            if (!(_components.TryGetValue(type, out Component component)))
            {
                throw new Exception($"Tried to remove component {type}, but it doesn't exist");
            }

            _components.Remove(type);
            Scene.UnregisterAll(component);
        }


        public Component GetComponent(Type type)
        {
            if (_components.TryGetValue(type, out var component))
            {
                return component;
            }

            return null;
        }

        public bool HasComponent(Type type)
        {
            return _components.ContainsKey(type);
        }

        public T AddComponent<T>() where T : Component, new()
        {
            return (T)AddComponent(typeof(T));
        }

        public void RemoveComponent<T>() where T : Component
        {
            RemoveComponent(typeof(T));
        }

        public T GetComponent<T>() where T : Component
        {
            return (T)GetComponent(typeof(T));
        }

        public bool HasComponent<T>() where T : Component
        {
            return HasComponent(typeof(T));
        }



    }
}
