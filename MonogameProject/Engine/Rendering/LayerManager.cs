using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject.Engine.Rendering
{
    internal class LayerManager
    {
        public static LayerManager Instance { get; private set; }
        private readonly Dictionary<string, RenderLayer> _layers = new();
        private LayerManager()
        {
            Create("Default", 10);
        }
        public static void Initialize()
        {
            if (Instance == null)
            {
                Instance = new LayerManager();
            }
        }
        public RenderLayer Create(string name, int order)
        {
            if (_layers.ContainsKey(name))
            {
                return _layers[name];
            }

            var layer = new RenderLayer(name, order);
            _layers[name] = layer;
            return layer;
        }

        public RenderLayer Get(string name)
        {
            return _layers[name];
        }

        public IEnumerable<RenderLayer> All()
        {
            return _layers.Values.OrderBy(layer => layer.Order);
        }

    }
}
