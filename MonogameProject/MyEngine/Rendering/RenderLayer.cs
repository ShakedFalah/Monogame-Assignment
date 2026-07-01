namespace MonogameProject.MyEngine.Rendering
{
    // A class that represents a render layer
    internal sealed class RenderLayer
    {
        public string Name { get; }
        public int Order { get; }

        public RenderLayer(string name, int order)
        {
            Name = name;
            Order = order;
        }
    }
}
