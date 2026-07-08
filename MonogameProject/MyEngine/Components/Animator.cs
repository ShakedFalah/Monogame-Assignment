using MonogameProject.MyEngine.Attributes;
using MonogameProject.MyEngine.Interfaces;
using MonogameProject.MyEngine.Rendering;

namespace MonogameProject.MyEngine.Components
{
    [RequireComponent(typeof(SpriteRenderer))]
    internal class Animator : Component, IUpdateable, IStartable
    {
        private AnimationClip _clip;
        private SpriteRenderer _spriteRenderer;
        private float _timeTillNextFrame = 1f;
        private float _timeBetweenFrames = 1f;


        public void Start()
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            _timeBetweenFrames = 1f / _clip.frameRate;
            _timeTillNextFrame -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timeTillNextFrame < 0f)
            {
                _timeTillNextFrame = _timeBetweenFrames;
                _spriteRenderer.sprite = _clip.next();
            }
        }

        public void SetClip(AnimationClip clip)
        {
            _clip = clip;
        }
    }
}
