using Basalt.Source.Core.Types;
using Basalt.Source.Core.Utils;
using Raylib_cs;
using static Raylib_cs.Raylib;
namespace Basalt.Source.Components
{
    public class CircleRenderer : Renderer
    {
        /// <summary>
        /// The radius of the rendered circle.
        /// </summary>
        public int Radius = 25;

        /// <summary>
        /// The fill color of the rendered circle.
        /// </summary>
        public Color Color = Color.PINK;

        public override void Start(GameObject gameObject)
        {
            base.Start(gameObject);
            if (gameObject.TryGetComponent(out CircleCollider col)) Radius = col.Radius;
        }

        public override void Render()
        {
            CustomDrawing.DrawCircle(Conversions.XYFromVector3(transform.Position), Radius, Color);
        }
    }
}
