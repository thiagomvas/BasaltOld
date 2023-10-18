using GameEngineProject.Source.Components;
using GameEngineProject.Source.Core.Utils;
using GameEngineProject.Source.Entities;
using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace GameEngineProject.Source.Core.Graphics
{
    public static class GraphicsWindow2D
    {
        public static Color BackgroundColor = Color.BLACK;
        public static Color FontColor = Color.WHITE;
        public static event EventHandler OnScreenRedraw;
        public static void Init(int Width = -1, int Height = -1, Camera2DObject cameraObject = null)
        {

            SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
            SetConfigFlags(ConfigFlags.FLAG_WINDOW_ALWAYS_RUN);
            SetConfigFlags(ConfigFlags.FLAG_WINDOW_MAXIMIZED);

            InitWindow(Width, Height, "New Game");

            // 2D Camera used on the game
            Camera2D defaultCamera = new Camera2D();
            defaultCamera.rotation = 0.0f;
            defaultCamera.zoom = 1.0f;

            foreach (var obj in Globals.GameObjectsOnScene)
                if (obj.TryGetComponent(out SpriteRenderer rend)) rend.texture = LoadTexture(rend.texturePath);

            //Console.WriteLine(texture.width);



            while (!WindowShouldClose())
            {
                if (IsKeyDown(KeyboardKey.KEY_RIGHT)) defaultCamera.target.X += 5;
                if (IsKeyDown(KeyboardKey.KEY_LEFT)) defaultCamera.target.X -= 5;
                if (IsKeyDown(KeyboardKey.KEY_DOWN)) defaultCamera.target.Y += 5;
                if (IsKeyDown(KeyboardKey.KEY_UP)) defaultCamera.target.Y -= 5;

                if (IsKeyPressed(KeyboardKey.KEY_F1)) Debug.ToggleDebug(); // Temporary
                if (Debug.IsDebugEnabled && IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
                    Debug.SelectedNearestGameObject(Conversions.XYToVector3(GetScreenToWorld2D(GetMousePosition(), cameraObject.camera)));

                OnScreenRedraw?.Invoke(null, EventArgs.Empty);
                
                if(cameraObject is not null) cameraObject.camera.offset = new(Raylib.GetScreenWidth()/2, Raylib.GetScreenHeight()/2);
                else defaultCamera.offset = new(Raylib.GetScreenWidth()/2, Raylib.GetScreenHeight()/2);
                BeginDrawing();
                ClearBackground(BackgroundColor);

                    BeginMode2D(cameraObject is not null ? cameraObject.camera : defaultCamera); // Setting the camera view | Anything drawn inside Mode2D will be affected by the camera's POV
                    DrawWorldSpace();
                    EndMode2D();

                DrawUI(); // Anything outside Mode2D will always be on screen

                EndDrawing();

            }

        }

        private static void DrawUI()
        {
            int i = 0;
            //foreach (var pair in Globals.AllComponentsOnScene)
            //{
            //    DrawText($"{pair.Key} : {pair.Value.Count}", 12, 30 + 15 * i, 20, FontColor);
            //    i++;
            //}

            foreach(var obj in Globals.GameObjectsOnScene)
            {
                DrawText($"Position of object #{i} {obj.transform.Position}", 12, 30 + 15 * i, 20, FontColor);
                i++;
            }

        }

        private static void DrawWorldSpace()
        {
            DrawRectangle(100, 100, 200, 200, Color.RED);
            int j = 0;
            foreach (var obj in Globals.GameObjectsOnScene)
            {
                if (obj.TryGetComponent<Renderer2D>(out Renderer2D rend)) rend.Render();
                j++;
            }
        }
    }
}
