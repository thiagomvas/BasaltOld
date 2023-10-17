using GameEngineProject.Source.Components;
using GameEngineProject.Source.Core.Graphics;
using GameEngineProject.Source.Entities;
using Raylib_cs;
using System.Numerics;
using static GameEngineProject.Source.Core.Globals;

namespace GameEngineProject.Source.Core
{
    public static class Engine
    {
        public static void Setup()
        {

            Camera2DObject camera = new Camera2DObject();
            GameObject obj = new GameObject(new Vector3(400, 400, 0));
            var rend = obj.AddComponent<SpriteRenderer>();
            obj.AddComponent<CircleCollider>();
            rend.texturePath = "C:\\Users\\Thiago\\source\\repos\\GameEngineProject\\Assets\\circleheadtest.png";
            obj.AddChildren(camera);
            Instantiate(obj);
            Player player = new Player(obj);

            GameObject obstacle = new GameObject(new Vector3(600, 600, 0));
            obstacle.AddComponent<Renderer2D>();
            var col = obstacle.AddComponent<CircleCollider>();
            col.Radius = 25;
            Instantiate(obstacle);


            GraphicsWindow2D.Init(800, 800, camera);
        }
    }
}