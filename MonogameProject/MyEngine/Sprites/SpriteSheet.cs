using Microsoft.Xna.Framework.Graphics;

namespace MonogameProject.MyEngine.Sprites
{
    internal class SpriteSheet
    {
        public Texture2D texture { get; }
        public int columns { get; }
        public int rows { get; }

        public SpriteSheet(Texture2D texture, int columns = 1, int rows = 1)
        {
            this.texture = texture;
            this.columns = columns;
            this.rows = rows;
        }
    }
}
