using MonogameProject.Engine.GameObjects;

namespace MonogameProject.Engine.Components
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
