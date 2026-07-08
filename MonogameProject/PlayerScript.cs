using Microsoft.Xna.Framework;
using MonogameProject.MyEngine;
using MonogameProject.MyEngine.Components;

namespace MonogameProject
{
    internal class PlayerScript : Script
    {
        private float speed = 500f;
        private Vector2 movingDirection = Vector2.Zero;
        public override void Start()
        {
            Engine.InputManager.GetAction<Vector2>("Move").Performed += OnMove;
            Engine.InputManager.GetAction<Vector2>("Move").Canceled += OnMove;
        }

        public override void Update(GameTime gameTime)
        {
            gameObject.Transform.position += movingDirection * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void OnMove(Vector2 direction)
        {
            movingDirection = direction;
            if (movingDirection != Vector2.Zero)
            {
                movingDirection.Normalize();
            }
        }
    }
}
