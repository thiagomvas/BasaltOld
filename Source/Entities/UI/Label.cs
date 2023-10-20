using GameEngineProject.Source.Core.Utils;
using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace GameEngineProject.Source.Entities.UI
{
    public class Label : UIElement
    {
        /// <summary>
        /// The Label's text
        /// </summary>
        public string Text = "Lorem Ipsum";

        /// <summary>
        /// Text's font size
        /// </summary>
        public int FontSize = 24;

        /// <summary>
        /// Text's color
        /// </summary>
        public Color TextColor = Color.WHITE;

        public int Spacing = 5;
        public Label(Vector2 position) : base(position)
        {
        }

        public override void Render()
        {
            base.Render();
            DrawTextPro(GetFontDefault(),
                        Text,
                        Conversions.XYFromVector3(transform.Position),
                        MeasureTextEx(GetFontDefault(), Text, FontSize, Spacing)/2,
                        MathExtended.GetZRotation(transform.Rotation) - 90,
                        FontSize,
                        Spacing,
                        TextColor);

        }
    }
}
