using GameEngineProject.Source.Core.Utils;
using GameEngineProject.Source.Entities;
using Raylib_cs;
using static Raylib_cs.Raylib;
namespace GameEngineProject.Source.Components
{
    public class CircleRenderer : Renderer2D
    {
        public int Radius = 25;
        public Color Color = Color.WHITE;

        public override void Start(GameObject gameObject)
        {
            base.Start(gameObject);
            if (gameObject.TryGetComponent(out CircleCollider col)) Radius = col.Radius;
        }

        public override void Render()
        {
            base.Render();

            CustomDrawing.DrawCircle(transform.Position, Radius, Color);
        }
    }
}
