using Microsoft.Xna.Framework;
using MonogameProject.MyEngine;
using MonogameProject.MyEngine.Components;
using MonogameProject.MyEngine.GameObjects;
using MonogameProject.MyEngine.Rendering;
using MonogameProject.MyEngine.Sprites;

namespace MonogameProject
{
    internal class ObjectGeneration
    {
        public void StartButton(Scene scene)
        {
            GameObject buttonObject = new GameObject(scene);
            buttonObject.AddComponent<UIButton>();
            buttonObject.AddComponent<UIText>();
            RenderLayer uiLayer = Engine.LayerManager.GetLayer("UI");
            SpriteRenderer spriteRenderer = buttonObject.GetComponent<SpriteRenderer>().SetLayer(uiLayer);
            UIText text = buttonObject.GetComponent<UIText>().SetLayer(uiLayer).SetOrder(1);
            UIButton button = buttonObject.GetComponent<UIButton>();
            spriteRenderer.SetSize(new Vector2(200, 80));
            button.OnClick += SetSceneToGame;
            text.SetText("Start");
            buttonObject.Transform.Position = Engine.GraphicsManager.ScreenCenter + new Vector2(0, -200);
        }

        public void SettingsButton(Scene scene)
        {
            GameObject buttonObject = new GameObject(scene);
            buttonObject.AddComponent<UIButton>();
            buttonObject.AddComponent<UIText>();
            RenderLayer uiLayer = Engine.LayerManager.GetLayer("UI");
            SpriteRenderer spriteRenderer = buttonObject.GetComponent<SpriteRenderer>().SetLayer(uiLayer);
            UIText text = buttonObject.GetComponent<UIText>().SetLayer(uiLayer).SetOrder(1);
            UIButton button = buttonObject.GetComponent<UIButton>();
            spriteRenderer.SetSize(new Vector2(200, 80));
            button.OnClick += Settings;
            text.SetText("Settings");
            buttonObject.Transform.Position = Engine.GraphicsManager.ScreenCenter;
        }

        public void ExitButton(Scene scene, Game game)
        {
            GameObject buttonObject = new GameObject(scene);
            buttonObject.AddComponent<UIButton>();
            buttonObject.AddComponent<UIText>();
            RenderLayer uiLayer = Engine.LayerManager.GetLayer("UI");
            SpriteRenderer spriteRenderer = buttonObject.GetComponent<SpriteRenderer>().SetLayer(uiLayer);
            UIText text = buttonObject.GetComponent<UIText>().SetLayer(uiLayer).SetOrder(1);
            UIButton button = buttonObject.GetComponent<UIButton>();
            spriteRenderer.SetSize(new Vector2(200, 80));
            button.OnClick += game.Exit;
            text.SetText("Exit");
            buttonObject.Transform.Position = Engine.GraphicsManager.ScreenCenter + new Vector2(0, 200);
        }



        public void Player(Scene scene)
        {
            GameObject player = new GameObject(scene);
            player.Transform.Position = Engine.GraphicsManager.ScreenCenter;
            SpriteSheet playerSpriteSheet = new SpriteSheet(Engine.Assets.GetImage("Player"), 6);
            SpritesheetSprite sprite = new SpritesheetSprite(playerSpriteSheet);
            SpriteRenderer playerRenderer = player.AddComponent<SpriteRenderer>();
            playerRenderer.sprite = sprite;
            playerRenderer.SetSize(new Vector2(500, 500));
            player.AddComponent<PlayerScript>();
            Animator playerAnimator = player.AddComponent<Animator>();
            AnimationClip clip = new AnimationClip(true, 8);
            foreach (var animationSprite in sprite.SplitToSprites())
            {
                clip.frames.Add(new AnimationFrame(animationSprite));
            }

            playerAnimator.SetClip(clip);
        }
        
        public void Background(Scene scene)
        {
            GameObject background = new GameObject(scene);
            background.Transform.Position = Engine.GraphicsManager.ScreenCenter;
            SpriteRenderer backgroundRenderer = background.AddComponent<SpriteRenderer>().SetLayer(Engine.LayerManager.GetLayer("Background"));
            backgroundRenderer.SetSize(new Vector2(1000, 1000));
            SpriteSheet backgroundSheet = new SpriteSheet(Engine.Assets.GetImage("Background"), 9, 6);
            SpritesheetSprite backgroundSprite = new SpritesheetSprite(backgroundSheet, 1, 1);
            backgroundRenderer.sprite = backgroundSprite;
        }

        public void Building(Scene scene)
        {
            GameObject building = new GameObject(scene);
            building.Transform.Position = Engine.GraphicsManager.ScreenCenter + new Vector2(100, 0);
            SpriteRenderer buildingRenderer = building.AddComponent<SpriteRenderer>().SetLayer(Engine.LayerManager.GetLayer("Background")).SetOrder(1);
            TextureSprite buildingSprite = new TextureSprite();
            buildingSprite.SetTexture(Engine.Assets.GetImage("Building"));
            buildingRenderer.sprite = buildingSprite;
            buildingRenderer.SetSize(new Vector2(200, 400));

        }
        public void SetSceneToGame()
        {
            Engine.SceneManager.SetScene("Game");
        }

        public void Settings()
        {
            System.Diagnostics.Debug.WriteLine("Settings");
        }

    }
}
