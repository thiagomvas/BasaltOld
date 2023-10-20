using GameEngineProject.Source.Core.Utils;
using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace GameEngineProject.Source.Entities.UI
{
    public class Label : UIElement
    {
        /// <summary>
        /// The text for this label
        /// </summary>
        public string Text = "Lorem Ipsum";

        /// <summary>
        /// The font size for this label's text
        /// </summary>
        public int FontSize = 24;

        /// <summary>
        /// The color of this label's text
        /// </summary>
        public Color TextColor = Color.WHITE;

        /// <summary>
        /// The spacing between each character in this label.
        /// </summary>
        public int Spacing = 5;
        public Label(Vector2 position) : base(position)
        {
        }

        public override void Render()
        {
            base.Render();
            DrawTextPro(GetFontDefault(),
                        Text,
                        transform.Position,
                        MeasureTextEx(GetFontDefault(), Text, FontSize, Spacing)/2,
                        MathExtended.GetZRotation(transform.Rotation) - 90,
                        FontSize,
                        Spacing,
                        TextColor);

        }
    }
}
