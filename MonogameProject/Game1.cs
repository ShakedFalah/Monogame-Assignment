using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameProject.MyEngine;
using MonogameProject.MyEngine.Components;
using MonogameProject.MyEngine.GameObjects;
using MonogameProject.MyEngine.Rendering;
using MonogameProject.MyEngine.Services;

namespace MonogameProject
{
    public class Game1 : Game
    {
        public Game1()
        {
            Engine.Load(this);
        }

        protected override void Initialize()
        {
            Engine.Instance.Initialize(GraphicsDevice);
            Scene defaultScene = Engine.SceneManager.AddScene("Default");
            Scene empty = Engine.SceneManager.AddScene("Empty");
            RenderLayer uiLayer = LayerManager.Instance.CreateLayer("UI", 20);
            // TODO: Add your initialization logic here
            GameObject buttonObject = new GameObject(defaultScene);
            buttonObject.AddComponent<UIButton>();
            buttonObject.AddComponent<UIText>();
            SpriteRenderer spriteRenderer = buttonObject.GetComponent<SpriteRenderer>().SetLayer(uiLayer);
            UIText text = buttonObject.GetComponent<UIText>().SetLayer(uiLayer).SetOrder(1);
            UIButton button = buttonObject.GetComponent<UIButton>();
            spriteRenderer.SetSize(new Vector2(50, 50));
            button.OnClick += setSceneTo;
            text.SetText("Hello");

            buttonObject.Transform.position = Engine.Instance.GraphicsManager.ScreenCenter;

            Engine.SceneManager.SetScene("Default");
            base.Initialize();
        }

        public void setSceneTo()
        {
            Engine.SceneManager.SetScene("Empty");
        }

        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Engine.SceneManager.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here

            Engine.SceneManager.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
