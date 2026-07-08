using Microsoft.Xna.Framework.Input;

namespace MonogameProject.MyEngine.Input
{
    // A class to save the current and previous state of all input
    public class InputState
    {
        private KeyboardState _currentKeyboard;
        private KeyboardState _previousKeyboard;

        internal void Update()
        {
            _previousKeyboard = _currentKeyboard;
            _currentKeyboard = Keyboard.GetState();
        }

        public bool IsKeyDown(Keys key)
            => _currentKeyboard.IsKeyDown(key);

        public bool IsKeyPressed(Keys key)
            => _currentKeyboard.IsKeyDown(key) &&
               _previousKeyboard.IsKeyUp(key);

        public bool IsKeyReleased(Keys key)
            => _currentKeyboard.IsKeyUp(key) &&
               _previousKeyboard.IsKeyDown(key);
    }
}