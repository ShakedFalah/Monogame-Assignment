using Microsoft.Xna.Framework;
using MonogameProject.MyEngine.Interfaces;
using System;

namespace MonogameProject.MyEngine.Input.Comparers
{
    // Default comparer for Vector2 values input used to define a deadzone
    internal class Vector2InputComparer : IInputComparer<Vector2>
    {
        private float _deadzone;

        public Vector2InputComparer(float deadzone)
        {
            _deadzone = deadzone;
        }

        public bool Changed(Vector2 previous, Vector2 current)
        {
            return Vector2.Distance(previous, current) > _deadzone;
        }
    }
}
