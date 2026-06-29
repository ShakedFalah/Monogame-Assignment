using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonogameProject.MyEngine.Services
{
    internal class AssetsManager
    {
        public static readonly string defaultName = "Default";
        private readonly ContentManager _content;
        private readonly Dictionary<string, SpriteFont> _fonts = new();

        public AssetsManager(ContentManager content)
        {
            _content = content;
            _fonts.Add(defaultName, _content.Load<SpriteFont>("Content/Fonts/Arial"));
        }

        public SpriteFont GetFont(string name)
        {
            if (_fonts.TryGetValue(name, out var font))
                return font;

            font = _content.Load<SpriteFont>($"Fonts/{name}");
            _fonts[name] = font;

            return font;
        }
    }
}
