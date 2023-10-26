using GameEngineProject.Source.Core.Types;
using static Raylib_cs.Raylib;
using Raylib_cs;
using System.Numerics;
using GameEngineProject.Source.Core.Utils;
using GameEngineProject.Source.Entities;
using System;
using System.Text;
using GameEngineProject.Libraries;
using System.Runtime.InteropServices;

namespace GameEngineProject.Source.Core.Graphics
{
    public class GraphicsWindow3D : GraphicsWindow
    {
        public unsafe override void Init(int Width = -1, int Height = -1, Camera cameraObject = null)
        {
            Configuration.PreInitConfiguration();
            InitWindow(800, 800, "3D Game");
            Configuration.PostInitConfiguration();
            int cubeSize = 1;
            int cubeWidth = 1;

            Model plane = LoadModelFromMesh(GenMeshPlane(25, 25, 3, 3));
            Model cube = LoadModelFromMesh(GenMeshCube(4, 4, 4));

            plane.materials[0].shader = Assets.LoadedShaders["lighting.fs"];
            cube.materials[0].shader = Assets.LoadedShaders["lighting.fs"];

            //Light[] lights = new Light[1];
            //lights[0] = Rlights.CreateLight(0,
            //    LightType.Point,
            //    new Vector3(25, 0, 0),
            //    Vector3.Zero,
            //    Color.WHITE,
            //    Assets.LoadedShaders["lighting.fs"]);

            List<GameObject> cubes = new();

            Music music = LoadMusicStream(Assets.GetResourcesPath("Audio\\country.mp3"));
            PlayMusicStream(music);


            while (!WindowShouldClose())
            {
                SetMusicPan(music, 0.5f + (float)Math.Sin(GetTime()) * 0.5f);
                UpdateMusicStream(music);
                // Update
                // You can add your game logic here.
                CallOnRedraw();


                Vector3 rotation = new(GetMouseDelta().X * 0.05f,                            // Rotation: yaw
                                       GetMouseDelta().Y * 0.05f,                            // Rotation: pitch
                                       0.0f);                                             // Rotation: roll

                UpdateCameraPro(ref Engine.Camera.Camera3D,
                                Engine.Player.Movement,
                                rotation,
                                0);


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

                //lights[0].Position = new Vector3(MathF.Sin((float)GetTime()) * 100, 0 ,MathF.Cos((float)GetTime()) * 100);

                //Rlights.UpdateLightValues(Assets.LoadedShaders["lighting.fs"], lights[0]);
                SetShaderValue(
                    Assets.LoadedShaders["lighting.fs"],
                    Assets.LoadedShaders["lighting.fs"].locs[(int)ShaderLocationIndex.SHADER_LOC_VECTOR_VIEW],
                    Engine.Camera.Camera3D.position,
                    ShaderUniformDataType.SHADER_UNIFORM_VEC3);
                BeginDrawing();
                {
                    ClearBackground(Color.BLACK);

                    // Set camera mode and update it

                    // Draw a 3D cube
                    BeginMode3D(Engine.Camera.Camera3D);

                    CallRenderWorldSpace();

                    DrawSphere(new Vector3(25, 0, 0), 1, Color.RED);
                    DrawSphere(new Vector3(-25, 0, 0), 1, Color.RED);
                    DrawSphere(new Vector3(0, 25, 0), 1, Color.BLUE);
                    DrawSphere(new Vector3(0, -25, 0), 1, Color.BLUE);
                    DrawSphere(new Vector3(0, 0, 25), 1, Color.GREEN);
                    DrawSphere(new Vector3(0, 0, -25), 1, Color.GREEN);

                    DrawCube(Engine.Player.gameObject.Transform.Position, 2, 2, 2, Color.RED);


                    DrawModel(plane, Vector3.Zero - Vector3.UnitY * 5, 1, Color.WHITE);
                    int renders = 0;
                    foreach(var obj in cubes)
                    {
                        if (PassByCulling(Engine.Camera, obj))
                        {
                            DrawModel(cube, obj.Transform.Position, 1, Color.WHITE);
                            renders++;
                        }
                    }
                    EndMode3D();
                    int totalObjs = cubeSize * cubeSize * cubeSize;
                    DrawText($"{totalObjs} objects", 20, 60, 15, Color.GREEN);
                    DrawText($"{renders} rendered", 20, 100, 15, Color.GREEN);
                    DrawText($"Camera: {Engine.Camera.Camera3D.position}", 20, 140, 15, Color.GREEN);
                    DrawText($"Player: {Engine.Player.gameObject.Transform.Position}", 20, 180, 15, Color.GREEN);
                    DrawFPS(10, 10);

                    // End the drawing
                    EndDrawing();
                }
            }
            Configuration.Deinitialize();
        }

        bool PassByCulling(Camera origin, GameObject target)
        {
            if (Vector3.Dot(Vector3.Normalize(origin.Forward), Vector3.Normalize(target.Transform.Position - origin.Camera3D.position)) > 0.5) return true;
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
