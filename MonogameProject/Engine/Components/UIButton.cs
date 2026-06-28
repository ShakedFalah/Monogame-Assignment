using Microsoft.Xna.Framework;
using MonogameProject.Engine.Attributes;
using MonogameProject.Engine.GameObjects;
using MonogameProject.Engine.Rendering;
using System;

namespace MonogameProject.Engine.Components
{
    public enum ButtonState
    {
        Normal,
        Hovered,
        Pressed
    }

    [RequireComponent(typeof(SpriteRenderer))]
    internal class UIButton : Component, Interfaces.IUpdateable, Interfaces.IStartable
    {
        public event Action OnClick;
        private SpriteRenderer _spriteRenderer;

        public Sprite normal;
        public Sprite hover;
        public Sprite pressed;

        public Rectangle? bounds;

        private ButtonState _state = ButtonState.Normal;
        private ButtonState _lastState = ButtonState.Normal;

        public UIButton()
        {
            normal = new SolidColorSprite(Color.SlateGray);
            hover = new SolidColorSprite(Color.LightSlateGray);
            pressed = new SolidColorSprite(Color.DarkSlateGray);
        }
        public void Start()
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            UpdateSprite();
        }

        public void Update(GameTime gameTime)
        {
            Microsoft.Xna.Framework.Input.MouseState mouse = Microsoft.Xna.Framework.Input.Mouse.GetState();
            Rectangle currentBounds = GetBounds();

            bool hovered = currentBounds.Contains(mouse.Position);
            bool pressed = mouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed;

            if (hovered && pressed)
            {
                _state = ButtonState.Pressed;
            }
            else if (hovered)
            {
                _state = ButtonState.Hovered;
            }
            else
            {
                _state = ButtonState.Normal;
            }

            // click detection
            if (_lastState == ButtonState.Pressed &&
                _state != ButtonState.Pressed &&
                hovered)
            {
                OnClick?.Invoke();
            }

            if (_state != _lastState)
            {
                UpdateSprite();
                _lastState = _state;
            }
        }

        private Rectangle GetBounds()
        {
            if (bounds.HasValue)
                return bounds.Value;

            Sprite sprite = _spriteRenderer.sprite;

            Point size = new Point(
                (int)(sprite.SourceRectangle.Width * gameObject.Transform.scale.X),
                (int)(sprite.SourceRectangle.Height * gameObject.Transform.scale.Y));

            Vector2 scaledOrigin = sprite.AbsoluteOrigin * gameObject.Transform.scale;

            Point topLeft = (gameObject.Transform.position - scaledOrigin).ToPoint();

            return new Rectangle(topLeft, size);
        }

        public void UpdateSprite()
        {
            switch (_state)
            {
                case ButtonState.Pressed:
                    _spriteRenderer.sprite = pressed;
                    break;
                case ButtonState.Hovered:
                    _spriteRenderer.sprite = hover;
                    break;
                case ButtonState.Normal:
                    _spriteRenderer.sprite = normal;
                    break;
            }
        }
    }
}
