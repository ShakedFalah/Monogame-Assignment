using Microsoft.Xna.Framework;
using System;

namespace MonogameProject.MyEngine.Components
{
    // A component required by every game object to define its position rotation and scale
    internal class Transform : Component
    {
        private Vector2 _position;
        private float _rotation;
        private Vector2 _scale;
        public Vector2 Position { 
            get 
            { 
                return _position; 
            } 
            set 
            { 
                _position = value;
                onTransformChange?.Invoke(this);
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
                onTransformChange?.Invoke(this);
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
                onTransformChange?.Invoke(this);
            }
        }

        public event Action<Transform> onTransformChange;
    }
}
