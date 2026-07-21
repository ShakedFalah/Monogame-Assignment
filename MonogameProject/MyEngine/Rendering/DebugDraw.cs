using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.MyEngine.Interfaces;
using System;
using System.Collections.Generic;

namespace MonogameProject.MyEngine.Rendering
{
    readonly struct DebugRectangle 
    {
        public readonly Rectangle rectangle;
        public readonly Color color;

        public DebugRectangle(Rectangle rectangle, Color color)
        {
            this.rectangle = rectangle;
            this.color = color;
        }
    }

    public static class DebugDraw
    {
        private static Texture2D _pixel;

        private static readonly List<DebugRectangle> _drawQueue = new();
        public static void Initialize(GraphicsDevice graphicsDevice)
        {
            _pixel = new Texture2D(graphicsDevice, 1, 1);
            _pixel.SetData(new[] { Color.White });
        }

        public static void DrawRectangle(Rectangle rectangle, Color color, int thickness = 1)
        {
            _drawQueue.Add(new DebugRectangle(new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width, thickness), color));
            _drawQueue.Add(new DebugRectangle(new Rectangle(rectangle.Left, rectangle.Bottom - thickness, rectangle.Width, thickness), color));
            _drawQueue.Add(new DebugRectangle(new Rectangle(rectangle.Left, rectangle.Top, thickness, rectangle.Height), color));
            _drawQueue.Add(new DebugRectangle(new Rectangle(rectangle.Right - thickness, rectangle.Top, thickness, rectangle.Height), color));
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            if (_pixel == null)
            {
                throw new InvalidOperationException("DebugDraw has not been initialized.");
            }

            foreach (DebugRectangle rectangle in _drawQueue)
            {
                spriteBatch.Draw(_pixel, rectangle.rectangle, rectangle.color);
            }

            _drawQueue.Clear();
        }

    }
}
