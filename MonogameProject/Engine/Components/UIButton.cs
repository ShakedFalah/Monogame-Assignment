using Microsoft.Xna.Framework;
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

    internal class UIButton : Component, Interfaces.IUpdateable, Interfaces.IStartable
    {
        public event Action OnClick;
        private SpriteRenderer _spriteRenderer;

        public Sprite normal;
        public Sprite hover;
        public Sprite pressed;

        private ButtonState _state;
        private ButtonState _lastState;

        public UIButton(GameObject parent) : base(parent)
        {
        }
        public void Start()
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        public void Update(GameTime gameTime)
        {
            Microsoft.Xna.Framework.Input.MouseState mouse = Microsoft.Xna.Framework.Input.Mouse.GetState();

            bool hovered = _spriteRenderer.DestinationRectangle.Contains(mouse.Position);
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
                default:
                    _spriteRenderer.sprite = normal;
                    break;
            }
        }
    }
}
