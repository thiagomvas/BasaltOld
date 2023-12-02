using Raylib_cs;
namespace Basalt.Source.Components
{
    public class SphereRenderer : Renderer
    {
        public float Radius = 10;
        protected override void Render()
        {
            Raylib.DrawSphereEx(transform.Position, Radius, 8, 8, Color);
        }
    }
}
