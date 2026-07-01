using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;

namespace MonogameProject.MyEngine.Services
{
    internal class AssetsManager
    {
        private readonly ContentManager _content;
        private readonly Dictionary<string, SpriteFont> _fonts = new();
        private readonly Dictionary<string, Texture2D> _images = new();
        private const string FONTSPATH = "Fonts";
        private const string IMAGESPATH = "Images";

        public AssetsManager(ContentManager content)
        {
            _content = content;
            SetFont(Engine.defaultName,"Arial");
        }

        public void SetFont(string name, string fileName)
        {
            _fonts[name] = _content.Load<SpriteFont>(Path.Combine(FONTSPATH, fileName));
        }

        public SpriteFont GetFont(string name)
        {
            if (_fonts.TryGetValue(name, out var font))
                return font;

            font = _content.Load<SpriteFont>(Path.Combine(FONTSPATH, name));
            _fonts[name] = font;

            return font;
        }

        public void SetImage(string name, string fileName)
        {
            _images[name] = _content.Load<Texture2D>(Path.Combine(IMAGESPATH, fileName));
        }

        public Texture2D GetImage(string name)
        {
            if (_images.TryGetValue(name, out var image))
                return image;

            image = _content.Load<Texture2D>(Path.Combine(IMAGESPATH, name));
            _images[name] = image;

            return image;
        }

    }
}
