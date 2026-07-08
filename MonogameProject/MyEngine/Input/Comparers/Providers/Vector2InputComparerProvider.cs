using Microsoft.Xna.Framework;
using MonogameProject.MyEngine.Interfaces;

namespace MonogameProject.MyEngine.Input.Comparers.Providers
{
    internal class Vector2InputComparerProvider : IInputComparerProvider<Vector2>
    {
        private float _deadzone;
        public Vector2InputComparerProvider(float deadzone)
        {
            _deadzone = deadzone;
        }

        public IInputComparer<Vector2> createInputComparer()
        {
            return new Vector2InputComparer(_deadzone);
        }

    }
}
