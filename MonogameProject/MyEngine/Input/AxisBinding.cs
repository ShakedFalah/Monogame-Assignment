using Microsoft.Xna.Framework.Input;

namespace MonogameProject.MyEngine.Input
{
    public class AxisBinding
    {
        public Keys Positive;
        public Keys Negative;

        public float ReadValue(InputState state)
        {
            float value = 0;

            if (state.IsKeyDown(Positive))
                value += 1;

            if (state.IsKeyDown(Negative))
                value -= 1;

            return value;
        }
    }
}
