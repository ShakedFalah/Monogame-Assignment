using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Engine.Rendering;

namespace MonogameProject.Engine.Interfaces
{
    internal interface IRenderable
    {
        public RenderLayer Layer();
        public int OrderInLayer();
        public void Render(SpriteBatch spriteBatch);
    }
}
