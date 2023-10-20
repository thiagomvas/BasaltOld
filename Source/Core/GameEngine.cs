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
            GameObject obj = new GameObject(new Vector2(400, 400));
            camera.camera.target = obj.transform.Position;
            camera.transform.Position = obj.transform.Position;
            var rend = obj.AddComponent<SpriteRenderer>();
            obj.AddComponent<CircleCollider>();
            obj.AddComponent<Rigidbody>();
            rend.texturePath = Assets.GetAssetPath("circleheadtest.png");
            obj.AddChildren(camera);
            Instantiate(obj);
            Player player = new Player(obj);
            for (int i = 0; i < 5; i++)
            {
                GameObject obstacle = new GameObject(new Vector2(100 + i * 50, 0));
                obstacle.AddComponent<CircleRenderer>();
                var col = obstacle.AddComponent<CircleCollider>();
                col.Radius = 25;
                Instantiate(obstacle);
            }


            Label label = new(UI.ScreenBottom + new Vector2(0, -25));
            label.SetPivot(UIElement.PivotPoint.Bottom);
            label.Text = "PROTOTYPE ENGINE TEST";
            label.FontSize = 24;
            label.TextColor = Color.GREEN;
            UI.Instantiate(label);





            GraphicsWindow2D.Init(800, 800, camera);
        }
    }
}
