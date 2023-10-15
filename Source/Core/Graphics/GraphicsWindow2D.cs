using GameEngineProject.Source.Components;
using GameEngineProject.Source.Entities;
using Raylib_cs;
using System.Numerics;

namespace GameEngineProject.Source.Core.Graphics
{
    public static class GraphicsWindow2D
    {
        public static Color BackgroundColor = Color.BLACK;
        public static Color FontColor = Color.WHITE;
        public static void Init(int Width = -1, int Height = -1)
        {

            Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
            Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_ALWAYS_RUN);
            Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_MAXIMIZED);

            Raylib.InitWindow(Width, Height, "New Game");

            Raylib.SetTargetFPS(60);

            while(!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(BackgroundColor);

                int i = 0;
                foreach(var pair in Globals.AllComponentsOnScene)
                {
                    Raylib.DrawText($"{pair.Key} : {pair.Value.Count}", 12, 30 + 15 * i, 20, FontColor);
                    i++;
                }

                int j = 0;
                foreach(var obj in Globals.GameObjectsOnScene)
                {
                    obj.transform.Position = new Vector3((float) Math.Sin(Raylib.GetTime()*1)*100 + 400, 400 + j*100, 0);
                    if (obj.TryGetComponent<Renderer>(out Renderer rend)) rend.Render();
                    j++;
                }

                if(Raylib.IsKeyPressed(KeyboardKey.KEY_A))
                {
                    var obj = new GameObject();
                    obj.AddComponent<Renderer>();
                    Globals.Instantiate(obj);
                }

                Raylib.DrawText($"{Globals.GameObjectsOnScene.Count} - {Globals.AllComponentsOnScene.Count} - {DateTime.Now}", 12, 12, 20, FontColor);

                Raylib.EndDrawing();
            }
        }
    }
}
