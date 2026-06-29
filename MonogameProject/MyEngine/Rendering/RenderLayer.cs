using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject.MyEngine.Rendering
{
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
