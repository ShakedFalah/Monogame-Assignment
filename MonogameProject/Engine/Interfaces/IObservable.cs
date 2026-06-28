namespace MonogameProject.Engine.Interfaces
{
    internal interface IObservable<T>
    {
        public void Register(T subscriber);
        public void Unregister(T subscriber);
    }
}
