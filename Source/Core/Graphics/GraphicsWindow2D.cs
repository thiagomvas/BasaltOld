using GameEngineProject.Source.Components;
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
            Camera2D camera = new Camera2D();
            camera.rotation = 0.0f;
            camera.zoom = 1.0f;

            foreach (var obj in Globals.GameObjectsOnScene)
                if (obj.TryGetComponent(out SpriteRenderer rend)) rend.texture = LoadTexture(rend.texturePath);

            //Console.WriteLine(texture.width);


            SetTargetFPS(60);

            while (!WindowShouldClose())
            {
                if (IsKeyDown(KeyboardKey.KEY_RIGHT)) camera.target.X += 5;
                if (IsKeyDown(KeyboardKey.KEY_LEFT)) camera.target.X -= 5;
                if (IsKeyDown(KeyboardKey.KEY_DOWN)) camera.target.Y += 5;
                if (IsKeyDown(KeyboardKey.KEY_UP)) camera.target.Y -= 5;

                OnScreenRedraw?.Invoke(null, EventArgs.Empty);

                BeginDrawing();
                ClearBackground(BackgroundColor);

                    BeginMode2D(cameraObject is not null ? cameraObject.camera : camera); // Setting the camera view | Anything drawn inside Mode2D will be affected by the camera's POV
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
