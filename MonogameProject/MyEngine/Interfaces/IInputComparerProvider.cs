namespace MonogameProject.MyEngine.Interfaces
{
    internal interface IInputComparerProvider<T>
    {
        public IInputComparer<T> createInputComparer();
    }
}
