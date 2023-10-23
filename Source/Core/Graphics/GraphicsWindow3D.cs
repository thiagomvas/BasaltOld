using GameEngineProject.Source.Core.Types;
using static Raylib_cs.Raylib;
using Raylib_cs;
using System.Numerics;
using GameEngineProject.Source.Core.Utils;

namespace GameEngineProject.Source.Core.Graphics
{
    public class GraphicsWindow3D : GraphicsWindow
    {
        public override void Init(int Width = -1, int Height = -1, Camera cameraObject = null)
        {
            InitWindow(Width, Height, "3D Game");

            cameraObject.Camera3D.target = Vector3.UnitX;
            cameraObject.Camera3D.up = Vector3.UnitY;
            cameraObject.Camera3D.fovy = 45;
            SetTargetFPS(120);
            HideCursor();
            DisableCursor();
            while (!WindowShouldClose())
            {
                // Update
                // You can add your game logic here.
                CallOnRedraw();

                Vector3 movement = new Vector3((IsKeyDown(KeyboardKey.KEY_W) || IsKeyDown(KeyboardKey.KEY_UP) ? 1 : 0) * 0.1f -      // Move forward-backward
                                (IsKeyDown(KeyboardKey.KEY_S) || IsKeyDown(KeyboardKey.KEY_DOWN) ? 1 : 0) * 0.1f,
                                (IsKeyDown(KeyboardKey.KEY_D) || IsKeyDown(KeyboardKey.KEY_RIGHT) ? 1 : 0) * 0.1f -   // Move right-left
                                (IsKeyDown(KeyboardKey.KEY_A) || IsKeyDown(KeyboardKey.KEY_LEFT) ? 1 : 0) * 0.1f,
                                0.0f);
                Vector3 rotation = new(GetMouseDelta().X * 0.05f,                            // Rotation: yaw
                                       GetMouseDelta().Y * 0.05f,                            // Rotation: pitch
                                       0.0f);                                             // Rotation: roll

                UpdateCameraPro(ref Engine.Camera.Camera3D,
                                Engine.p1.Movement,
                                rotation,
                                GetMouseWheelMove() * 2.0f);


                BeginDrawing();
                {
                    ClearBackground(Color.RAYWHITE);

                    // Set camera mode and update it

                    // Draw a 3D cube
                    BeginMode3D(Engine.Camera.Camera3D);
                    DrawSphere(new Vector3(25, 0, 0), 5, Color.RED);
                    DrawSphere(new Vector3(-25, 0, 0), 5, Color.RED);
                    DrawSphere(new Vector3(0, 25, 0), 5, Color.BLUE);
                    DrawSphere(new Vector3(0, -25, 0), 5, Color.BLUE);
                    DrawSphere(new Vector3(0, 0, 25), 5, Color.GREEN);
                    DrawSphere(new Vector3(0, 0, -25), 5, Color.GREEN);
                    DrawSphere(Engine.Camera.Camera3D.target, 0.1f, Color.YELLOW);
                    EndMode3D();
                    DrawText($"Player Pos: {Engine.p1.gameObject.Transform.Position}\n Camera Pos: {Engine.Camera.Camera3D.position}\n Rotation: {Engine.p1.gameObject.Transform.Rotation}\n {Engine.p1.gameObject.Transform.Position + Engine.p1.gameObject.Transform.Forward * 5}\n Camera Target {Engine.Camera.Camera3D.target}", 20, 10, 10, Color.GREEN);
                    DrawFPS(10, 10);

                    // End the drawing
                    EndDrawing();
                }
            }
        }
    }
}
