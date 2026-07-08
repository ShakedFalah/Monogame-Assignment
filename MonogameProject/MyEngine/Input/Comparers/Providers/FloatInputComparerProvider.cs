using MonogameProject.MyEngine.Interfaces;

namespace MonogameProject.MyEngine.Input.Comparers.Providers
{
    internal class FloatInputComparerProvider : IInputComparerProvider<float>
    {
        private float _deadzone;
        public FloatInputComparerProvider(float deadzone) 
        {
            _deadzone = deadzone;
        }

        public IInputComparer<float> createInputComparer()
        {
            return new FloatInputComparer(_deadzone);
        }
    }
}
