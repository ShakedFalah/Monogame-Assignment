using MonogameProject.Engine.GameObjects;

namespace MonogameProject.Engine.Components
{
    internal abstract class Component
    {
        public GameObject parent;

        public Component(GameObject parent)
        {
            this.parent = parent;
        }
    }
}
