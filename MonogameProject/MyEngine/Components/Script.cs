using Microsoft.Xna.Framework;
using MonogameProject.MyEngine.Interfaces;

namespace MonogameProject.MyEngine.Components
{
    // Base script class the user can inherit from to create components that add behaviours to gameobjects
    internal abstract class Script : Component, IStartable, Interfaces.IUpdateable, Interfaces.IFixedUpdateable
    {
        public virtual void Start() { }

        public virtual void FixedUpdate(float deltaTime) { }

        public virtual void Update(GameTime gameTime) { }
    }
}
