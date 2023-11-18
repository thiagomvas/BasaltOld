using static Raylib_cs.Raylib;
using Raylib_cs;
using System.Numerics;
using Basalt.Source.Core.Utils;
using Basalt.Source.Core.Types;
using Basalt.Source.Components;

namespace Basalt.Source.Core.Graphics
{
    public class GameWindow3D : GameWindow
    {
        public unsafe override void Start(string name = "Window")
        {
            Configuration.PreInitConfiguration();
            InitWindow(800, 800, "3D Game");
            Configuration.PostInitConfiguration();

            Camera cameraObject = Engine.CurrentScene.Cameras[0];

            foreach (UIElement elem in Engine.CurrentScene.UI)
            {
                elem.UpdatePositionOnResize();
            }

            int cubeSize = 1;
            int cubeWidth = 1;
            Model plane = LoadModelFromMesh(GenMeshPlane(250, 250, 3, 3));
            Model cube = LoadModelFromMesh(GenMeshCube(4, 4, 4));

            plane.Materials[0].Shader = Assets.LoadedShaders["lighting.fs"];
            cube.Materials[0].Shader = Assets.LoadedShaders["lighting.fs"];

            List<GameObject> cubes = new();

            Music music = LoadMusicStream(Assets.GetResourcesPath("Audio\\country.mp3"));
            PlayMusicStream(music);


            while (!WindowShouldClose())
            {
                Engine.CallUpdate();
                SetMusicPan(music, 0.5f + (float)Math.Sin(GetTime()) * 0.5f);           // Temporary until proper audio system
                UpdateMusicStream(music);                                               // Temporary until proper audio system




                // Testing purposes
                if (IsKeyPressed(KeyboardKey.KEY_K))
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
                                obj.AddComponent<SphereRenderer>();
                                Engine.CurrentScene.InstantiateGameObject(obj);
                            }
                        }
                    }
                }

                // Update basic lighting shader
                SetShaderValue(
                    Assets.LoadedShaders["lighting.fs"],
                    Assets.LoadedShaders["lighting.fs"].Locs[(int)ShaderLocationIndex.SHADER_LOC_VECTOR_VIEW],
                    Engine.CurrentScene.Cameras[0].Camera3D.Position,
                    ShaderUniformDataType.SHADER_UNIFORM_VEC3);

                BeginDrawing();
                {
                    ClearBackground(Color.BLACK);

                    BeginMode3D(cameraObject.Camera3D);



                    DrawModel(plane, Vector3.Zero - Vector3.UnitY * 5, 1, Color.WHITE);
                    int renders = 0;
                    foreach (var obj in Engine.CurrentScene.GameObjects)
                    {
                        if (obj.Renderer != null && PassByCulling(cameraObject, obj))
                        {
                            obj.Renderer.Render();
                            renders++;
                        }
                    }
                    EndMode3D();
                    DrawText($"{Engine.CurrentScene.GameObjects.Count} objects", 20, 60, 15, Color.GREEN);
                    DrawText($"{renders} rendered", 20, 100, 15, Color.GREEN);
                    DrawText($"Camera: {cameraObject.Camera3D.Position}", 20, 140, 15, Color.GREEN);
                    foreach (UIElement elem in Engine.CurrentScene.UI)
                    {
                        elem.Render();
                    }


                    DrawFPS(10, 10);

                    // End the drawing
                    EndDrawing();
                }
            }
            Configuration.Deinitialize();
        }
        public unsafe override void Init(int Width = -1, int Height = -1, Camera cameraObject = null)
        {
            Configuration.PreInitConfiguration();
            InitWindow(800, 800, "3D Game");
            Configuration.PostInitConfiguration();


            foreach (UIElement elem in Engine.CurrentScene.UI)
            {
                elem.UpdatePositionOnResize();
            }

            int cubeSize = 1;
            int cubeWidth = 1;
            Model plane = LoadModelFromMesh(GenMeshPlane(250, 250, 3, 3));
            Model cube = LoadModelFromMesh(GenMeshCube(4, 4, 4));

            plane.Materials[0].Shader = Assets.LoadedShaders["lighting.fs"];
            cube.Materials[0].Shader = Assets.LoadedShaders["lighting.fs"];

            List<GameObject> cubes = new();

            Music music = LoadMusicStream(Assets.GetResourcesPath("Audio\\country.mp3"));
            PlayMusicStream(music);


            while (!WindowShouldClose())
            {
                Engine.CallUpdate();
                SetMusicPan(music, 0.5f + (float)Math.Sin(GetTime()) * 0.5f);           // Temporary until proper audio system
                UpdateMusicStream(music);                                               // Temporary until proper audio system




                // Testing purposes
                if (IsKeyPressed(KeyboardKey.KEY_K))
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
                                obj.AddComponent<SphereRenderer>();
                                Engine.CurrentScene.InstantiateGameObject(obj);
                            }
                        }
                    }
                }

                // Update basic lighting shader
                SetShaderValue(
                    Assets.LoadedShaders["lighting.fs"],
                    Assets.LoadedShaders["lighting.fs"].Locs[(int)ShaderLocationIndex.SHADER_LOC_VECTOR_VIEW],
                    Engine.CurrentScene.Cameras[0].Camera3D.Position,
                    ShaderUniformDataType.SHADER_UNIFORM_VEC3);

                BeginDrawing();
                {
                    ClearBackground(Color.BLACK);

                    BeginMode3D(cameraObject.Camera3D);



                    DrawModel(plane, Vector3.Zero - Vector3.UnitY * 5, 1, Color.WHITE);
                    int renders = 0;
                    foreach (var obj in Engine.CurrentScene.GameObjects)
                    {
                        if (obj.Renderer != null && PassByCulling(cameraObject, obj))
                        {
                            obj.Renderer.Render();
                            renders++;
                        }
                    }
                    EndMode3D();
                    DrawText($"{Engine.CurrentScene.GameObjects.Count} objects", 20, 60, 15, Color.GREEN);
                    DrawText($"{renders} rendered", 20, 100, 15, Color.GREEN);
                    DrawText($"Camera: {cameraObject.Camera3D.Position}", 20, 140, 15, Color.GREEN);
                    foreach (UIElement elem in Engine.CurrentScene.UI)
                    {
                        elem.Render();
                    }


                    DrawFPS(10, 10);

                    // End the drawing
                    EndDrawing();
                }
            }
            Configuration.Deinitialize();
        }

        bool PassByCulling(Camera origin, GameObject target)
        {
            if (Vector3.Dot(Vector3.Normalize(origin.Forward), Vector3.Normalize(target.Transform.Position - origin.Camera3D.Position)) > 0.5) return true;
            else return false;

        }
    }
}
