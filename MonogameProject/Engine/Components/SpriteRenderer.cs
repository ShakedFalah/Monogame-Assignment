using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.Engine.GameObjects;

namespace MonogameProject.Engine.Components
{
    internal class SpriteRenderer : Component, Interfaces.IDrawable
    {
        public Texture2D texture;
        public Rectangle destinationRectangle;
        public Rectangle? sourceRectangle;
        public Color tint;
        public Vector2 origin;
        public SpriteEffects effects;
        public float layerDepth;

        public SpriteRenderer(GameObject parent) : base(parent)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, 
                tint, parent.Transform.rotation, origin, effects, layerDepth);
        }
    }
}
