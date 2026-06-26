using MonogameProject.Engine.Components;
using System;
using System.Collections.Generic;

namespace MonogameProject.Engine.GameObjects
{
    internal class GameObject
    {
        private readonly Dictionary<Type, List<Component>> _components = [];
        public GameObject()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
        }

        public T AddComponent<T>() where T : Component, new()
        {
            T component = new()
            {
                parent = this
            };
            _components[typeof(T)].Add(component);

            return component;
        }

        public T GetComponent<T>() where T : Component
        {
            if (_components.TryGetValue(typeof(T), out var component))
            {
                return (T)component[0];
            }

            return null;
        }
    }
}
