using GameEngineProject.Source.Core.Types;
using static Raylib_cs.Raylib;
using Raylib_cs;
using System.Numerics;
using GameEngineProject.Source.Core.Utils;
using GameEngineProject.Source.Entities;
using System;
using System.Text;

namespace GameEngineProject.Source.Core.Graphics
{
    public class GraphicsWindow3D : GraphicsWindow
    {
        public override void Init(int Width = -1, int Height = -1, Camera cameraObject = null)
        {
            SetConfigFlags(ConfigFlags.FLAG_WINDOW_MAXIMIZED);

            InitWindow(1920, 1080, "3D Game");

            cameraObject.Camera3D.target = Vector3.UnitX;
            cameraObject.Camera3D.up = Vector3.UnitY;
            cameraObject.Camera3D.fovy = 70;
            SetTargetFPS(120);
            HideCursor();
            DisableCursor();
            int cubeSize = 1;
            int cubeWidth = 1;

            List<GameObject> cubes = new();

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
                                Engine.Player.Movement,
                                rotation,
                                GetMouseWheelMove() * 2.0f);

                if(IsKeyPressed(KeyboardKey.KEY_K))
                {
                    cubeSize++;
                    cubes.Clear();
                    for (int x = 0; x < cubeSize; x++)
                    {
                        for (int y = 0; y < cubeSize; y++)
                        {
                            for (int z = 0; z < cubeSize; z++)
                            {
                                GameObject obj = new GameObject(new Vector3(10 * x * cubeWidth, 10 * y * cubeWidth, 10 * z * cubeWidth));
                                cubes.Add(obj);
                            }
                        }
                    }
                }


                BeginDrawing();
                {
                    ClearBackground(Color.BLACK);

                    // Set camera mode and update it

                    // Draw a 3D cube
                    BeginMode3D(Engine.Camera.Camera3D);
                    DrawSphere(new Vector3(25, 0, 0), 5, Color.RED);
                    DrawSphere(new Vector3(-25, 0, 0), 5, Color.RED);
                    DrawSphere(new Vector3(0, 25, 0), 5, Color.BLUE);
                    DrawSphere(new Vector3(0, -25, 0), 5, Color.BLUE);
                    DrawSphere(new Vector3(0, 0, 25), 5, Color.GREEN);
                    DrawSphere(new Vector3(0, 0, -25), 5, Color.GREEN);








                    int renders = 0;

                    foreach(var obj in cubes)
                    {
                        if (PassByCulling(Engine.Camera, obj))
                        {   
                            DrawCube(obj.Transform.Position, cubeWidth, cubeWidth, cubeWidth, Color.GREEN);
                            renders++;
                        }
                    }
                    EndMode3D();
                    int totalObjs = cubeSize * cubeSize * cubeSize;
                    DrawText($"{totalObjs} objects", 20, 60, 15, Color.GREEN);
                    DrawText($"{renders} rendered", 20, 100, 15, Color.GREEN);
                    DrawText($"{Engine.Camera.Camera3D.target - Engine.Camera.Camera3D.position}", 20, 140, 15, Color.GREEN);
                    DrawFPS(10, 10);

                    // End the drawing
                    EndDrawing();
                }
            }
        }

        bool PassByCulling(Camera origin, GameObject target)
        {
            if (Vector3.Dot(Vector3.Normalize(origin.Forward), Vector3.Normalize(target.Transform.Position)) > 0.5) return true;
            else return false;

            // Crappy attempt at using frustum (or whatever the hell this is)
            const int range = 1000;
            const int startWidth = 10;
            const int startHeight = 13;
            Vector3 originR = Engine.Camera.Camera3D.position + Engine.Camera.Right * startWidth + Engine.Camera.Forward * 5 + Engine.Camera.Up * startHeight / 2;
            Vector3 originL = Engine.Camera.Camera3D.position - Engine.Camera.Right * startWidth + Engine.Camera.Forward * 5 - Engine.Camera.Up * startHeight / 2;
            Vector3 rightDiag = Vector3.Normalize(originR - Engine.Camera.Camera3D.position);
            Vector3 leftDiag = Vector3.Normalize(originL - Engine.Camera.Camera3D.position);
            Vector3 endR = Engine.Camera.Camera3D.position + Engine.Camera.Right * startWidth + rightDiag * range;
            Vector3 endL = Engine.Camera.Camera3D.position - Engine.Camera.Right * startWidth + leftDiag * range;


            float biggestX = new float[] { originR.X, originL.X, endL.X, endR.X }.Max();
            float smallestX = new float[] { originR.X, originL.X, endL.X, endR.X }.Min();
            float biggestY = new float[] { originR.Y, originL.Y, endL.Y, endR.Y }.Max();
            float smallestY = new float[] { originR.Y, originL.Y, endL.Y, endR.Y }.Min();
            float biggestZ = new float[] { originR.Z, originL.Z, endL.Z, endR.Z }.Max();
            float smallestZ = new float[] { originR.Z, originL.Z, endL.Z, endR.Z }.Min();



            if (smallestX <= target.Transform.Position.X && target.Transform.Position.X <= biggestX
                && smallestY <= target.Transform.Position.Y && target.Transform.Position.Y <= biggestY
                && smallestZ <= target.Transform.Position.Z && target.Transform.Position.Z <= biggestZ) return true;
            else return false;
        }
    }
}
