using Microsoft.Xna.Framework;
using MonogameProject.MyEngine;
using MonogameProject.MyEngine.Components;

namespace MonogameProject
{
    internal class PlayerScript : Script
    {
        private float speed = 500f;
        private Vector2 movingDirection = Vector2.Zero;
        private Rigidbody rigidbody;
        public override void Start()
        {
            Engine.InputManager.GetAction<Vector2>("Move").Performed += OnMove;
            Engine.InputManager.GetAction<Vector2>("Move").Canceled += OnMove;
            rigidbody = gameObject.GetComponent<Rigidbody>();
        }

        public override void FixedUpdate(float deltaTime)
        {
            rigidbody.AddForce(movingDirection * speed);
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
