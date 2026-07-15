using Microsoft.Xna.Framework;
using System;

namespace MonogameProject.MyEngine.Components
{
    // A component required by every game object to define its position rotation and scale
    internal class Transform : Component
    {
        public event Action<Transform> OnTransformChanged;
        public Vector2 _position = Vector2.Zero;
        public float _rotation = 0.0f;
        public Vector2 _scale = Vector2.One;

        public Vector2 Position { get 
            {
                return _position;
            } 
            set 
            { 
                _position = value;
                OnTransformChanged?.Invoke(this);
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
                OnTransformChanged?.Invoke(this);
            }
        }
        public Vector2 Scale
        { get 
            {
                return _scale;
            } 
            set 
            { 
                _scale = value;
                OnTransformChanged?.Invoke(this);
            }
        }
    }
}
