using Microsoft.Xna.Framework;
using MonogameProject.MyEngine.Input;
using MonogameProject.MyEngine.Input.Comparers;
using MonogameProject.MyEngine.Interfaces;
using System;
using System.Collections.Generic;

namespace MonogameProject.MyEngine.Services
{
    internal class InputManager : ISystem
    {
        private readonly InputState _state = new();
        private Dictionary<Type, IActionMap> _actionMaps = new();

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

        public void AddAction<T>(string name, IInputBinding<T> binding, float deadzone = 0.1f)
        {
            InputAction<T> action = GetMap<T>().Add(name, binding);

            if (typeof(T) == typeof(float))
            {
                action.Comparer = (IInputComparer<T>)(new FloatInputComparer(deadzone));
            } else if (typeof(T) == typeof(Vector2))
            {
                action.Comparer = (IInputComparer<T>)(new Vector2InputComparer(deadzone));
            }
        }

        public InputAction<T> GetAction<T>(string name)
        {
            return GetMap<T>().GetAction(name);
        }
    }
}
