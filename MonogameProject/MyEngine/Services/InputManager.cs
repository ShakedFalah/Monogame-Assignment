using Microsoft.Xna.Framework;
using MonogameProject.MyEngine.Input;
using MonogameProject.MyEngine.Interfaces;
using System;
using System.Collections.Generic;

namespace MonogameProject.MyEngine.Services
{
    internal class InputManager : ISystem
    {
        private readonly InputState _state = new();
        private Dictionary<Type, IActionMap> _actionMaps = new();
        private Dictionary<Type, object> _provider = new();

        public InputManager() 
        {
            _actionMaps.Add(typeof(bool), new InputActionMap<bool>());
            _actionMaps.Add(typeof(float), new InputActionMap<float>());
            _actionMaps.Add(typeof(Vector2), new InputActionMap<Vector2>());
        }

        public void Update(GameTime gameTime)
        {
            _state.Update();

            foreach (var map in _actionMaps.Values)
            {
                map.Update(_state);
            }
        }

        private InputActionMap<T> GetMap<T>()
        {
            var type = typeof(T);
            bool exists = _actionMaps.TryGetValue(type, out var map);

            if (!exists)
            {
                return null;
            }

            return (InputActionMap<T>)map;
        }

        public void AddAction<T>(string name, IInputBinding<T> binding, IInputComparer<T> comparer = null)
        {
            InputAction<T> action = GetMap<T>().Add(name, binding);

            if (comparer != null)
            {
                action.Comparer = comparer;
            } else if (_provider.TryGetValue(typeof(T), out var provider))
            {
                action.Comparer = ((IInputComparerProvider<T>)provider).createInputComparer();
            }
        }

        public void SetInputComparerProvider<T>(IInputComparerProvider<T> provider)
        {
            _provider[typeof(T)] =  provider;
        }

        public InputAction<T> GetAction<T>(string name)
        {
            return GetMap<T>().GetAction(name);
        }
    }
}
