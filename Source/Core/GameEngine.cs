using GameEngineProject.Source.Components;
using GameEngineProject.Source.Core.Graphics;
using GameEngineProject.Source.Core.Utils;
using GameEngineProject.Source.Entities;
using GameEngineProject.Source.Entities.UI;
using Raylib_cs;
using System.Numerics;
using static GameEngineProject.Source.Core.Globals;

namespace GameEngineProject.Source.Core
{
    public static class Engine
    {
        public static Camera2D? Camera2D;
        public static void Setup()
        {
            Camera2DObject camera = new Camera2DObject();
            Camera2D = camera.camera;
            GameObject obj = new GameObject(new Vector3(400, 400, 0));
            camera.camera.target = Conversions.XYFromVector3(obj.transform.Position);
            camera.transform.Position = obj.transform.Position;
            var rend = obj.AddComponent<SpriteRenderer>();
            obj.AddComponent<CircleCollider>();
            rend.texturePath = Assets.GetAssetPath("circleheadtest.png");
            obj.AddChildren(camera);
            Instantiate(obj);
            Player player = new Player(obj);
            for (int i = 0; i < 5; i++)
            {
                GameObject obstacle = new GameObject(new Vector3(100 + i * 50, 0, 0));
                obstacle.AddComponent<Renderer2D>();
                var col = obstacle.AddComponent<CircleCollider>();
                col.Radius = 25;
                Instantiate(obstacle);
            }


            Label label = new(UI.ScreenBottomLeft + new Vector2(200, -200));
            label.SetPivot(UIElement.PivotPoint.BottomLeft);
            label.Text = "This is a label";
            label.FontSize = 24;
            label.TextColor = Color.GREEN;
            UI.Instantiate(label);




            GraphicsWindow2D.Init(800, 800, camera);
        }
    }
}
