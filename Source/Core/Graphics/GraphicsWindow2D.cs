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
        /// <summary>
        /// Background color for the world.
        /// </summary>
        public static Color BackgroundColor = Color.BLACK;

        /// <summary>
        /// Font color used on UI;
        /// </summary>
        public static Color FontColor = Color.WHITE;

        /// <summary>
        /// Event called every frame.
        /// </summary>
        public static event Action OnScreenRedraw;
        public static event Action OnScreenResize;
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
                foreach (var component in obj.Components) component.Awake(obj);

            foreach (var obj in Globals.GameObjectsOnScene)
                foreach (var component in obj.Components) component.Start(obj);

            foreach (var element in Globals.UIElementsOnScene)
            {
                element.UpdatePosition();
                OnScreenResize += element.UpdatePosition;
            }
                



            while (!WindowShouldClose())
            {
                if (IsWindowResized()) OnScreenResize?.Invoke();
                Engine.Camera2D = cameraObject.camera;

                if (IsKeyPressed(KeyboardKey.KEY_F1)) Debug.ToggleDebug(); // Temporary
                if (Debug.IsDebugEnabled && IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
                    Debug.SelectedNearestGameObject(GetScreenToWorld2D(GetMousePosition(), cameraObject.camera));

                OnScreenRedraw?.Invoke();
                
                if(cameraObject is not null) cameraObject.camera.offset = new(Raylib.GetScreenWidth()/2, Raylib.GetScreenHeight()/2);
                else defaultCamera.offset = new(Raylib.GetScreenWidth()/2, Raylib.GetScreenHeight()/2);

                BeginDrawing();
                ClearBackground(BackgroundColor);

                    BeginMode2D(cameraObject is not null ? cameraObject.camera : defaultCamera); // Setting the camera view | Anything drawn inside Mode2D will be affected by the camera's POV
                    DrawWorldSpace();
                    EndMode2D();

                DrawUI(); // Anything outside Mode2D will always be on screen
                if (Debug.IsDebugEnabled) Debug.DrawDebugUI();

                EndDrawing();

            }

        }


        /// <summary>
        /// Draws all the UI;
        /// </summary>
        private static void DrawUI()
        {
            int i = 0;
            //foreach (var pair in Globals.AllComponentsOnScene)
            //{
            //    DrawText($"{pair.Key} : {pair.Value.Count}", 12, 30 + 15 * i, 20, FontColor);
            //    i++;
            //}

            //foreach(var obj in Globals.GameObjectsOnScene)
            //{
            //    DrawText($"Position of object #{i} {obj.transform.Position}", 12, 30 + 15 * i, 20, FontColor);
            //    i++;
            //}

            foreach(var element in Globals.UIElementsOnScene)
                element.Render();


        }

        /// <summary>
        /// Draws all the GameObjects in the world.
        /// </summary>
        private static void DrawWorldSpace()
        {
            DrawRectangle(200, 200, 21, 21, Color.RED);
            int j = 0;
            foreach (var obj in Globals.GameObjectsOnScene)
            {
                if (obj.TryGetComponent<Renderer2D>(out Renderer2D rend)) rend.Render();
                j++;
            }
        }
    }
}
