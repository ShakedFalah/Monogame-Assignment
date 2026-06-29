using MonogameProject.MyEngine.GameObjects;

namespace MonogameProject.MyEngine.Components
{
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
