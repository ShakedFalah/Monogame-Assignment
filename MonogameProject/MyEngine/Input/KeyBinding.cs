using Microsoft.Xna.Framework.Input;
using MonogameProject.MyEngine.Interfaces;

namespace MonogameProject.MyEngine.Input
{
    // A class used to create key bindings for simple key input
    public class KeyBinding : IInputBinding<bool>
    {
        public Keys key;

        public KeyBinding(Keys key)
        {
            this.key = key;
        }

        public bool ReadValue(InputState state)
        {
            return state.IsKeyDown(key);
        }
    }
}
