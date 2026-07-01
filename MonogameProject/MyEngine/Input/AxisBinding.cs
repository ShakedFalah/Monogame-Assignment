using Microsoft.Xna.Framework.Input;
using MonogameProject.MyEngine.Interfaces;

namespace MonogameProject.MyEngine.Input
{
    // A class used to create key bindings for axis type input
    public class AxisBinding : IInputBinding<float>
    {
        public Keys positive;
        public Keys negative;

        public AxisBinding(Keys positive, Keys negative)
        {
            this.positive = positive;
            this.negative = negative;
        }

        public float ReadValue(InputState state)
        {
            float value = 0;

            if (state.IsKeyDown(positive))
                value += 1;

            if (state.IsKeyDown(negative))
                value -= 1;

            return value;
        }
    }
}
