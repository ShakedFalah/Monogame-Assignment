using MonogameProject.MyEngine.Sprites;
using System.Collections;
using System.Collections.Generic;

namespace MonogameProject.MyEngine.Rendering
{
    internal class AnimationClip : IEnumerable<AnimationFrame>
    {
        private List<AnimationFrame> _frames = new();
        private int _currentFrame = 0;
        public int frameRate { get; } = 60;
        private bool _isLooping = false;

        public IEnumerator<AnimationFrame> GetEnumerator()
        {
            return _frames.GetEnumerator();
        }

        public Sprite next()
        {
            _currentFrame++;
            if (_currentFrame >= _frames.Count)
            {
                if (_isLooping)
                {
                    _currentFrame = 0;
                } else
                {
                    _currentFrame = _frames.Count - 1;
                }
            }

            return _frames[_currentFrame].getSprite();
        }

        public Sprite prev()
        {
            _currentFrame--;

            if (_currentFrame < 0)
            {
                if (_isLooping)
                {
                    _currentFrame = _frames.Count - 1;
                }
                else
                {
                    _currentFrame = 0;
                }
            }

            return _frames[_currentFrame].getSprite();
        }

        public void Reset()
        {
            _currentFrame = 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Sprite this[int index]
        {
            get
            {
                return _frames[index].getSprite();
            }
        }
    }
}
