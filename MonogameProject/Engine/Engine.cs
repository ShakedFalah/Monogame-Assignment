using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject.Engine
{
    internal class Engine
    {
        public static GraphicsDevice GraphicsDevice { get; private set; }

        public static void Initialize(GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
            LayerManager.Initialize();
        }
    }
}
