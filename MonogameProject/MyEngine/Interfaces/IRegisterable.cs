namespace MonogameProject.MyEngine.Interfaces
{
    internal interface IRegisterable<T>
    {
        public void Register(T subscriber);
        public void Unregister(T subscriber);
    }
}
