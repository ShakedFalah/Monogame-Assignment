using Microsoft.Xna.Framework;
using System;

namespace MonogameProject.MyEngine.Components
{
    // A component required by every game object to define its position rotation and scale
    internal class Transform : Component
    {
        private Vector2 _position = Vector2.Zero;
        private float _rotation = 0f;
        private Vector2 _scale = Vector2.Zero;
        public Vector2 Position { 
            get 
            { 
                return _position; 
            } 
            set 
            { 
                _position = value;
                OnTransformChange?.Invoke(this);
            } 
        }
        public float Rotation
        {
            get
            {
                return _rotation;
            }
            set
            {
                _rotation = value;
                OnTransformChange?.Invoke(this);
            }
        }
        public Vector2 Scale
        {
            get
            {
                return _scale;
            }
            set
            {
                _scale = value;
                OnTransformChange?.Invoke(this);
            }
        }

        public event Action<Transform> OnTransformChange;
    }
}
