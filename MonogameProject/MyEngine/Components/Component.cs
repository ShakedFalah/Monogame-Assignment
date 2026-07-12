using MonogameProject.MyEngine.GameObjects;

namespace MonogameProject.MyEngine.Components
{
    // Base component class used to make components
    internal abstract class Component
    {
        public GameObject gameObject;

        private static int _nextId = 1;
        public int Id { get; }

        public Component()
        {
            Id = _nextId++;
        }

        public void Initialize(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }
    }
}
