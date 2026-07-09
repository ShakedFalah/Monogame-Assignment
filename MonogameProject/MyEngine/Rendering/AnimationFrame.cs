using MonogameProject.MyEngine.Sprites;

namespace MonogameProject.MyEngine.Rendering
{
    internal class AnimationFrame
    {
        private Sprite _sprite;
        public float duration;

        public AnimationFrame(Sprite sprite, float duration = 0f)
        {
            _sprite = sprite;
            this.duration = duration;
        }

        public Sprite getSprite()
        {
            return _sprite;
        }
    }
}