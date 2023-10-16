using GameEngineProject.Source.Components;
using GameEngineProject.Source.Core.Graphics;
using GameEngineProject.Source.Entities;
using System.Numerics;
using static GameEngineProject.Source.Core.Globals;

namespace GameEngineProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Camera2DObject camera = new Camera2DObject();
            GameObject obj = new GameObject(new Vector3(400, 400, 0));
            obj.AddComponent<SpriteRenderer>();
            Instantiate(obj);
            GameObject obj2 = new GameObject(new Vector3(430, 430, 0));
            obj2.AddComponent<SpriteRenderer>();
            obj2.AddChildren(obj);
            obj2.AddChildren(camera);
            Instantiate(obj2);
            Player player = new Player(obj2);
            GraphicsWindow2D.Init(800, 800, camera);
        }
    }
}