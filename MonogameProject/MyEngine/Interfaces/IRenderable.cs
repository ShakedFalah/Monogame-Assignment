using Microsoft.Xna.Framework.Graphics;
using MonogameProject.MyEngine.Rendering;

namespace MonogameProject.MyEngine.Interfaces
{
    internal interface IRenderable
    {
        public RenderLayer Layer();
        public int OrderInLayer();
        public void Render(SpriteBatch spriteBatch);
    }
}
