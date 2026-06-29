using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameProject.MyEngine;
using MonogameProject.MyEngine.Components;
using MonogameProject.MyEngine.GameObjects;
using MonogameProject.MyEngine.Rendering;

namespace MonogameProject
{
    public class Game1 : Game
    {
        private Scene _activeScene;


        public Game1()
        {
            Engine.Load(this);
        }

        protected override void Initialize()
        {
            Engine.Instance.Initialize(GraphicsDevice);
            _activeScene = new Scene(GraphicsDevice);
            RenderLayer uiLayer = LayerManager.Instance.CreateLayer("UI", 20);
            // TODO: Add your initialization logic here
            GameObject button = new GameObject(_activeScene);
            button.AddComponent<UIButton>();
            button.AddComponent<UIText>();
            SpriteRenderer spriteRenderer = button.GetComponent<SpriteRenderer>().SetLayer(uiLayer);
            UIText text = button.GetComponent<UIText>().SetLayer(uiLayer).SetOrder(1);
            spriteRenderer.SetSize(new Vector2(50, 50));
            text.SetText("Hello");

            button.Transform.position = Engine.Instance.GraphicsManager.ScreenCenter;

            _activeScene.Start();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _activeScene.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _activeScene.Draw(gameTime);
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
