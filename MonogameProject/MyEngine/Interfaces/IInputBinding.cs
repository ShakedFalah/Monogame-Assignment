using MonogameProject.MyEngine.Input;

namespace MonogameProject.MyEngine.Interfaces
{
    internal interface IInputBinding<T>
    {
        T ReadValue(InputState state);
    }
}
