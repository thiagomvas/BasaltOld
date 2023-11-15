using Basalt.Source.Core.Types;
using Raylib_cs;
using System.Numerics;

namespace Basalt.Source.Core.UI
{
    public class Panel : UIElement
    {
        public int Width;
        public int Height;
        public Color Color;

        public Panel(Vector2 position) : base(position)
        {
        }

        public override void Render()
        {
            Raylib.DrawRectangle((int)Position.X - Width / 2, (int)Position.Y - Height / 2, Width, Height, Color);
        }
    }
}
