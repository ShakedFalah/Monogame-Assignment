using System;

namespace MonogameProject.MyEngine.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    // Attribute to make components create automatically other components used by components that require other specific components
    internal sealed class RequireComponentAttribute : Attribute
    {
        public Type ComponentType { get; }

        public RequireComponentAttribute(Type componentType)
        {
            ComponentType = componentType;
        }
    }
}
