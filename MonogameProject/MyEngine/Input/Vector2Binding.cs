using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonogameProject.MyEngine.Interfaces;

namespace MonogameProject.MyEngine.Input
{
    // A class used to create key bindings for Vector2 type input
    public class Vector2Binding : IInputBinding<Vector2>
    {
        public Keys up;
        public Keys down;
        public Keys left;
        public Keys right;

        public Vector2Binding(Keys up, Keys down, Keys left, Keys right)
        {
            this.up = up;
            this.down = down;
            this.left = left;
            this.right = right;
        }

        public Vector2 ReadValue(InputState state)
        {
            Vector2 value = Vector2.Zero;

            if (state.IsKeyDown(left))
                value.X--;

            if (state.IsKeyDown(right))
                value.X++;

            if (state.IsKeyDown(up))
                value.Y--;

            if (state.IsKeyDown(down))
                value.Y++;

            return value;
        }
    }
}
