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
                UpdateCamera(ref Engine.Camera.Camera3D, CameraMode.CAMERA_FIRST_PERSON);

                
                if (IsKeyDown(KeyboardKey.KEY_J))
                {
                    cameraObject.Camera3D.position += Vector3.UnitY * Time.DeltaTime;
                    cameraObject.Camera3D.target += Vector3.UnitY * Time.DeltaTime;
                }


                Engine.Camera.Camera3D.position = Engine.p1.gameObject.Transform.Position;
                Engine.p1.gameObject.Transform.Rotation = MathExtended.LookAtRotation(Engine.p1.gameObject.Transform.Position, Engine.Camera.Camera3D.target, Vector3.UnitY);
                // Draw
                BeginDrawing();
                {
                    ClearBackground(Color.RAYWHITE);

                    // Set camera mode and update it

                    // Draw a 3D cube
                    BeginMode3D(cameraObject.Camera3D);
                    DrawSphere(new Vector3(25, 0, 0), 5, Color.RED);
                    DrawSphere(new Vector3(-25, 0, 0), 5, Color.RED);
                    DrawSphere(new Vector3(0, 25, 0), 5, Color.BLUE);
                    DrawSphere(new Vector3(0, -25, 0), 5, Color.BLUE);
                    DrawSphere(new Vector3(0, 0, 25), 5, Color.GREEN);
                    DrawSphere(new Vector3(0, 0, -25), 5, Color.GREEN);
                    DrawSphere(Engine.p1.gameObject.Transform.Position + Engine.p1.gameObject.Transform.Forward * 5, 0.1f, Color.YELLOW);
                    EndMode3D();
                    DrawText($"Player Pos: {Engine.p1.gameObject.Transform.Position}\n Camera Pos: {Engine.Camera.Camera3D.position}\n Rotation: {Engine.p1.gameObject.Transform.Rotation}\n {Engine.p1.gameObject.Transform.Position + Engine.p1.gameObject.Transform.Forward * 5}", 20, 10, 10, Color.GREEN);
                    DrawFPS(10, 10);

                    // End the drawing
                    EndDrawing();
                }
            }
        }
    }
}
