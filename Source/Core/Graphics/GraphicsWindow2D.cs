using GameEngineProject.Source.Components;
using GameEngineProject.Source.Core.Types;
using GameEngineProject.Source.Core.Utils;
using GameEngineProject.Source.Entities;
using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace GameEngineProject.Source.Core.Graphics
{
    public class GraphicsWindow2D : GraphicsWindow
    {
        public override void Init(int Width, int Height, Camera cameraObject)
        {
            Debug.Setup();
            SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
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


            foreach (var obj in Globals.GameObjectsOnScene)
            {
                if (obj.TryGetComponent<Renderer>(out Renderer rend)) RenderWorldSpace += rend.OnRender;
            }




            while (!WindowShouldClose())
            {
                if (IsWindowResized()) CallOnResize();

                if (IsKeyPressed(KeyboardKey.KEY_F1)) Debug.ToggleDebug(); // Temporary
                if (Debug.IsDebugEnabled && IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
                    Debug.SelectedNearestGameObject(GetScreenToWorld2D(GetMousePosition(), cameraObject.Camera2D));

                CallOnRedraw();

                BeginDrawing();
                ClearBackground(BackgroundColor);

                BeginMode2D(cameraObject.Camera2D); // Setting the camera view | Anything drawn inside Mode2D will be affected by the camera's POV
           
                CallRenderWorldSpace();
                EndMode2D();

                CallRenderUI();
                Debug.DrawDebugUI();

                EndDrawing();

            }

        }


        /// <summary>
        /// Draws all the UI;
        /// </summary>
        private void DrawUI()
        {
            int i = 0;
            //foreach (var pair in Globals.AllComponentsOnScene)
            //{
            //    DrawText($"{pair.Key} : {pair.Value.Count}", 12, 30 + 15 * i, 20, FontColor);
            //    i++;
            //}

            foreach (var obj in Globals.GameObjectsOnScene)
            {
                DrawText($"Position of object #{i} {obj.Transform.Position}", 400, 30 + 15 * i, 20, FontColor);
                i++;
            }

            foreach (var element in Globals.UIElementsOnScene)
                element.Render();


        }

    }
}
