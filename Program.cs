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
            GameObject obj = new GameObject(new Vector3(400, 400, 0));
            obj.AddComponent<Renderer>();
            Instantiate(obj);
            GraphicsWindow2D.Init(800, 800);
        }
    }
}