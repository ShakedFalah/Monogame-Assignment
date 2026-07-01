using MonogameProject.MyEngine.GameObjects;

namespace MonogameProject.MyEngine.Components
{
    // Base component class used to make components
    internal abstract class Component
    {
        public GameObject gameObject;

        public Component()
        {
        }

        public void Initialize(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }
    }
}
