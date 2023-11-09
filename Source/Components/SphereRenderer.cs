using Raylib_cs;
namespace GameEngineProject.Source.Components
{
    public class SphereRenderer : Renderer
    {
        public float Radius = 10;
        public Color Color = Color.PINK;
        public override void Render()
        {
            Raylib.DrawSphereEx(transform.Position, Radius, 5, 5, Color);
        }
    }
}