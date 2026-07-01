using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameProject.MyEngine.Rendering;
using MonogameProject.MyEngine.Services;
using System.Text;

namespace MonogameProject.MyEngine.Sprites
{
    internal class TextSprite : PivotObject
    {
        public SpriteFont font;
        public StringBuilder text;
        public override Vector2 Size => font.MeasureString(text);

        public TextSprite()
        {
            font = Engine.Assets.GetFont(Engine.defaultName);
            text = new StringBuilder("");
        }
    }
}
