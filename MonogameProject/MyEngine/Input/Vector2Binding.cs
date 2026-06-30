using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonogameProject.MyEngine.Interfaces;

namespace MonogameProject.MyEngine.Input
{
    public class Vector2Binding : IInputBinding<Vector2>
    {
        public Keys Up;
        public Keys Down;
        public Keys Left;
        public Keys Right;

        public Vector2 ReadValue(InputState state)
        {
            Vector2 value = Vector2.Zero;

            if (state.IsKeyDown(Left))
                value.X--;

            if (state.IsKeyDown(Right))
                value.X++;

            if (state.IsKeyDown(Up))
                value.Y--;

            if (state.IsKeyDown(Down))
                value.Y++;

            return value;
        }
    }
}
