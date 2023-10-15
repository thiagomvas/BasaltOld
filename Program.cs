using GameEngineProject.Source.Components;
using GameEngineProject.Source.Core;
using GameEngineProject.Source.Core.Graphics;
using GameEngineProject.Source.Entities;
using System.Numerics;

namespace GameEngineProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameObject obj = new GameObject(new Vector3(400, 400, 0));
            obj.AddComponent<Renderer>();
            Globals.Instantiate(obj);
            GraphicsWindow2D.Init(800, 800);
        }
    }
}