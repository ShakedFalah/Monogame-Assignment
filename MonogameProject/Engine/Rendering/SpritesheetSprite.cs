using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonogameProject.Engine.Rendering
{
    internal class SpritesheetSprite : Sprite
    {
        private SpriteSheet _spriteSheet;
        private int _column;
        private int _row;

        public SpriteSheet SpriteSheet
        {
            get => _spriteSheet; 
            set
            {
                if (value == null) return;

                _spriteSheet = value;
                UpdateSourceRectangle();
            } 
        }


        public int Column
        {
            get => _column;
            set
            {
                _column = Math.Clamp(value, 0, _spriteSheet.columns - 1);
                UpdateSourceRectangle();
            }
        }
        public int Row 
        {
            get => _row;
            set
            {
                _row = Math.Clamp(value, 0, _spriteSheet.rows - 1);
                UpdateSourceRectangle();
            }
        }

        public SpritesheetSprite(SpriteSheet spriteSheet, int column = 0, int row = 0)
        {
            Initialize(spriteSheet, column, row, new SpriteOrigin(new Vector2(0.5f, 0.5f), OriginType.relative));
        }

        public SpritesheetSprite(SpriteSheet spriteSheet, Vector2 origin, OriginType originType = OriginType.absolute, int column = 0, int row = 0)
        {
            Initialize(spriteSheet, column, row, new SpriteOrigin(origin, originType));
        }

        public SpritesheetSprite(SpriteSheet spriteSheet, SpriteOrigin origin, int column = 0, int row = 0)
        {
            Initialize(spriteSheet, column, row, origin);
        }

        private void Initialize(SpriteSheet sheet, int column, int row, SpriteOrigin origin)
        {
            _spriteSheet = sheet;
            _column = column;
            _row = row;
            SetOrigin(origin);
            UpdateSourceRectangle();
        }

        private void UpdateSourceRectangle()
        {
            if (_spriteSheet == null)
                return;

            int width = _spriteSheet.texture.Width / _spriteSheet.columns;
            int height = _spriteSheet.texture.Height / _spriteSheet.rows;

            SetSourceRectangle(new Rectangle(width * _column, height * _row, width, height));
        }

        public override Texture2D Texture()
        {
            return _spriteSheet.texture;
        }
    }
}
