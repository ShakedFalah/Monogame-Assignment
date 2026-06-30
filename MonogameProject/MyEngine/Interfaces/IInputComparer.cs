namespace MonogameProject.MyEngine.Interfaces
{
    internal interface IInputComparer<T>
    {
        bool Changed(T previous, T current);
    }
}
