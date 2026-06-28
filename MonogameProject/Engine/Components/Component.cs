using MonogameProject.Engine.GameObjects;

namespace MonogameProject.Engine.Components
{
    internal abstract class Component
    {
        public GameObject gameObject;

        public Component(GameObject parent)
        {
            this.gameObject = parent;
        }
    }
}
