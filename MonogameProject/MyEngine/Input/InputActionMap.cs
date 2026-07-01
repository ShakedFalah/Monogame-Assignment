using MonogameProject.MyEngine.Interfaces;
using System.Collections.Generic;

namespace MonogameProject.MyEngine.Input
{
    // A generic class to contain all input actions of a specific type and calls update on them
    internal class InputActionMap<T> : IActionMap
    {
        private readonly Dictionary<string, InputAction<T>> _actions = new();

        public InputAction<T> Add(string name, IInputBinding<T> binding)
        {
            InputAction<T> newAction = new InputAction<T>(binding);
            _actions[name] = newAction;
            return newAction;
        }

        public InputAction<T> GetAction(string name)
        {
            return _actions[name];
        }

        public T GetValue(string name, InputState state)
        {
            return _actions[name].Binding.ReadValue(state);
        }

        public void Update(InputState state)
        {
            foreach (var action in _actions.Values)
            {
                action.Update(state);
            }
        }
    }
}
