using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.MyEngine.Rendering;
using System;
using System.Collections.Generic;

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
            if (column < 0 || column >= sheet.columns || row < 0 || row > sheet.rows)
            {
                throw new ArgumentOutOfRangeException("row or column out of range of spritesheet");
            }
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

            SetSourceRectangle(_spriteSheet[_column, _row]);
        }

        public override Texture2D Texture()
        {
            return _spriteSheet.texture;
        }

        public SpritesheetSprite[] SplitToSprites(int startingRow = 0, int rowsAmount = 0, int[] columnsPerRow = null)
        {
            if (startingRow < 0 || startingRow >= _spriteSheet.rows)
            {
                throw new IndexOutOfRangeException("Row is out of spritesheet bounds");
            }

            if (rowsAmount < 0)
            {
                throw new ArgumentException("Rows amount must be 0 or greater");
            }

            int numberOfRows = rowsAmount;
            if (numberOfRows == 0)
            {
                numberOfRows = SpriteSheet.rows - startingRow;
            }

            if (columnsPerRow != null && columnsPerRow.Length != numberOfRows) 
            {
                throw new ArgumentException("Columns per row length must be the same as the amount of rows to split");
            }

            SpritesheetSprite[] output = new SpritesheetSprite[numberOfRows * SpriteSheet.columns];

            int index = 0;
            int columnsInRow = _spriteSheet.columns;

            for (int row = startingRow; row < startingRow + numberOfRows; row++)
            {
                if (columnsPerRow != null)
                {
                    columnsInRow = columnsPerRow[row];
                }
                for (int col = 0; col < columnsInRow;  col++)
                {
                    output[index] = new SpritesheetSprite(SpriteSheet, col, row);
                    index++;
                }
            }

            return output;
        }
    }
}
