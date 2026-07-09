using MonogameProject.MyEngine.Sprites;
using System.Collections;
using System.Collections.Generic;

namespace MonogameProject.MyEngine.Rendering
{
    internal class AnimationClip : IEnumerable<AnimationFrame>
    {
        public List<AnimationFrame> frames = new();
        private int _currentFrame = 0;
        public int frameRate { get; } = 60;
        private bool _isLooping = false;

        public AnimationClip(bool looping = false, int frameRate = 60)
        {
            this._isLooping = looping;
            this.frameRate = frameRate;
        }

        public IEnumerator<AnimationFrame> GetEnumerator()
        {
            return frames.GetEnumerator();
        }

        public Sprite Next()
        {
            _currentFrame++;
            if (_currentFrame >= frames.Count)
            {
                if (_isLooping)
                {
                    _currentFrame = 0;
                } else
                {
                    _currentFrame = frames.Count - 1;
                }
            }

            return frames[_currentFrame].getSprite();
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
                return frames[index].getSprite();
            }
        }

        public float GetDuration()
        {
            if (frames[_currentFrame].duration > 0f)
            {
                return frames[_currentFrame].duration;
            }

            return 1f / frameRate;
        }
    }
}
