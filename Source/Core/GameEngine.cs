using GameEngineProject.Source.Components;
using GameEngineProject.Source.Core.Graphics;
using GameEngineProject.Source.Core.Types;
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
        public static Camera Camera = new(Camera.RenderType.Camera3D);
        public static GraphicsWindow window;
        public static Player p1;
        public static void Setup()
        {
            Example3DSetup();
        }

        private static void Example3DSetup()
        {
            int cubeSize = 5;
            window = new GraphicsWindow3D();
            Camera.Camera3D.target = new(50, 0, 0);
            GameObject obj = new();
            obj.AddComponent<Rigidbody>();
            obj.AddChildren(Camera);
            Player player = new(obj);
            p1 = player;
            Instantiate(obj);
            window.Init(1000, 1000, Camera);

        }

        private static void Example2DSetup()
        {
            window = new GraphicsWindow2D();
            GameObject obj = new GameObject(new Vector3(400, 400, 0));
            Camera.Transform.Position = obj.Transform.Position;
            var rend = obj.AddComponent<CircleRenderer>();
            obj.AddComponent<CircleCollider>();
            obj.AddComponent<Rigidbody>();
            obj.AddChildren(Camera);
            //Instantiate(obj);
            Player player = new Player(obj);
            for (int i = 0; i < 5; i++)
            {
                GameObject obstacle = new GameObject(new Vector3(100 + i * 50, 0, 0));
                obstacle.AddComponent<SpriteRenderer>().texturePath = Assets.GetAssetPath("circleheadtest.png");
                var col = obstacle.AddComponent<CircleCollider>();
                col.Radius = 25;
                Instantiate(obstacle);
            }


            Label label = new(UI.ScreenBottom + new Vector2(0, -50));
            label.SetPivot(UIElement.PivotPoint.Bottom);
            label.Text = "PROTOTYPE ENGINE TEST";
            label.FontSize = 24;
            label.TextColor = Color.GREEN;
            UI.Instantiate(label);




            window.Init(800, 800, Camera);
        }
    }
}
