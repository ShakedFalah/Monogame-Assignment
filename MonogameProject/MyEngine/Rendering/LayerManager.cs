using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace MonogameProject.MyEngine.Rendering
{
    // A singleton that creates and keeps layers
    internal class LayerManager
    {
        private readonly Dictionary<string, RenderLayer> _layers = new();
        public LayerManager()
        {
            
        }

        public void Initialize()
        {
            CreateLayer("Default", 10);
        }

        public RenderLayer CreateLayer(string name, int order)
        {
            if (_layers.ContainsKey(name))
            {
                return _layers[name];
            }

            var layer = new RenderLayer(name, order);
            _layers[name] = layer;
            return layer;
        }

        public RenderLayer GetLayer(string name)
        {
            return _layers[name];
        }

        public IEnumerable<RenderLayer> All()
        {
            return _layers.Values.OrderBy(layer => layer.Order);
        }

    }
}
