using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Runtime.CompilerServices;

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

        public Rectangle this[int column, int row]
        {
            get
            {
                if (row >= rows || row < 0 || column >= columns || column < 0)
                {
                    throw new IndexOutOfRangeException("Row or Column outside spritesheet");
                }

                int width = texture.Width / columns;
                int height = texture.Height / rows;
                return new Rectangle(column * width, row / height, width, height);
            }
        }
    }
}
