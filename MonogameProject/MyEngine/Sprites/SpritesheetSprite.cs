using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.MyEngine.Rendering;
using System;

namespace MonogameProject.MyEngine.Sprites
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
            Initialize(spriteSheet, column, row, new Pivot(new Vector2(0.5f, 0.5f), PivotType.relative));
        }

        public SpritesheetSprite(SpriteSheet spriteSheet, Vector2 origin, PivotType originType = PivotType.absolute, int column = 0, int row = 0)
        {
            Initialize(spriteSheet, column, row, new Pivot(origin, originType));
        }

        public SpritesheetSprite(SpriteSheet spriteSheet, Pivot origin, int column = 0, int row = 0)
        {
            Initialize(spriteSheet, column, row, origin);
        }

        private void Initialize(SpriteSheet sheet, int column, int row, Pivot origin)
        {
            _spriteSheet = sheet;
            _column = column;
            _row = row;
            SetPivot(origin);
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
