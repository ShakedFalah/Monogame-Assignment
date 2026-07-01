using Microsoft.Xna.Framework;

namespace MonogameProject.MyEngine.Components
{
    // A component required by every game object to define its position rotation and scale
    internal class Transform
    {
        public Vector2 position = Vector2.Zero;
        public float rotation = 0.0f;
        public Vector2 scale = Vector2.One;
    }
}
