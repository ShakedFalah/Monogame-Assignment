using MonogameProject.MyEngine.Interfaces;
using System;

namespace MonogameProject.MyEngine.Input.Comparers
{
    internal class FloatInputComparer : IInputComparer<float>
    {
        private float _deadzone;

        public FloatInputComparer(float deadzone)
        {
            _deadzone = deadzone;
        }

        public bool Changed(float previous, float current)
        {
            return MathF.Abs(previous - current) > _deadzone;
        }
    }
}
