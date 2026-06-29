using System;

namespace MonogameProject.MyEngine.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    internal sealed class RequireComponentAttribute : Attribute
    {
        public Type ComponentType { get; }

        public RequireComponentAttribute(Type componentType)
        {
            ComponentType = componentType;
        }
    }
}
