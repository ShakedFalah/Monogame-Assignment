using Microsoft.Xna.Framework.Input;

namespace MonogameProject.MyEngine.Input
{
    public class KeyBinding
    {
        public Keys Key;

        public bool ReadValue(InputState state)
        {
            return state.IsKeyDown(Key);
        }
    }
}
