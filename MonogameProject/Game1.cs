using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonogameProject.MyEngine;
using MonogameProject.MyEngine.Components;
using MonogameProject.MyEngine.GameObjects;
using MonogameProject.MyEngine.Input;
using MonogameProject.MyEngine.Rendering;
using MonogameProject.MyEngine.Sprites;

namespace MonogameProject
{
    public class Game1 : Game
    {
        public Game1()
        {
            Engine.CreateInstance(this);
        }

        protected override void Initialize()
        {
            Engine.Instance.Initialize(GraphicsDevice);

            base.Initialize();
        }
        protected override void LoadContent()
        {
            Scene defaultScene = Engine.SceneManager.GetScene(Engine.defaultName);
            Scene gameScene = Engine.SceneManager.AddScene("Game");
            RenderLayer uiLayer = Engine.LayerManager.CreateLayer("UI", 20);
            RenderLayer backgroundLayer = Engine.LayerManager.CreateLayer("Background", 5);
            Engine.Assets.SetImage("Player", "Pawn_Run");
            Engine.Assets.SetImage("Background", "Tilemap_color5");
            Engine.Assets.SetImage("Building", "Tower");
            Engine.InputManager.AddAction("Move", new Vector2Binding(Keys.W, Keys.S, Keys.A, Keys.D));

            ObjectGeneration objectGeneration = new ObjectGeneration();

            objectGeneration.StartButton(defaultScene);
            objectGeneration.SettingsButton(defaultScene);
            objectGeneration.ExitButton(defaultScene, this);
            objectGeneration.Player(gameScene);
            objectGeneration.Building(gameScene);
            objectGeneration.Background(gameScene);

            Engine.Instance.Load();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Engine.Instance.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here

            Engine.Instance.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
