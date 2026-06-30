using MonogameProject.MyEngine.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MonogameProject.MyEngine.Input
{
    internal class InputAction<T>
    {
        public event Action<T>? Started;
        public event Action<T>? Performed;
        public event Action<T>? Canceled;
        public event Action<T>? Changed;

        public IInputBinding<T> Binding;
        public IInputComparer<T>? Comparer; // optional

        private T _previous;
        private T _current;

        public T Value => _current;

        public InputAction(IInputBinding<T> binding)
        {
            this.Binding = binding;
        }

        public void Update(InputState state)
        {
            _previous = _current;
            _current = Binding.ReadValue(state);

            bool changed = Compare(_previous, _current);

            if (changed)
                Changed?.Invoke(_current);

            bool wasActive = IsActive(_previous);
            bool isActive = IsActive(_current);

            if (!wasActive && isActive)
                Started?.Invoke(_current);

            if (wasActive && isActive)
                Performed?.Invoke(_current);

            if (wasActive && !isActive)
                Canceled?.Invoke(_current);
        }

        private bool Compare(T a, T b)
        {
            if (Comparer != null)
                return Comparer.Changed(a, b);

            return !EqualityComparer<T>.Default.Equals(a, b);
        }

        private bool IsActive(T value)
        {
            return !EqualityComparer<T>.Default.Equals(value, default);
        }
    }
}
