using GameEngineProject.Source.Core.Utils;
using Raylib_cs;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using static Raylib_cs.Raylib;


namespace GameEngineProject.Source.Entities.UI
{
    /// <summary>
    /// Represents a progress bar that can be used for visualizing progress or completion.
    /// </summary>
    public class ProgressBar : UIElement
    {
        /// <summary>
        /// The width of the background of the progress bar.
        /// </summary>
        public int BackgroundWidth = 300;

        /// <summary>
        /// The height of the background of the progress bar.
        /// </summary>
        public int BackgroundHeight = 50;

        /// <summary>
        /// The color of the background of the progress bar.
        /// </summary>
        public Color BackgroundColor = Color.GRAY;

        /// <summary>
        /// The width of the progress bar itself.
        /// </summary>
        public int BarWidth = 300;

        /// <summary>
        /// The height of the progress bar itself.
        /// </summary>
        public int BarHeight = 50;

        /// <summary>
        /// The color of the progress bar.
        /// </summary>
        public Color BarColor = Color.RED;

        /// <summary>
        /// The offset from the top-left corner of the progress bar's parent element.
        /// </summary>
        public Vector2 OffsetFromCorner = Vector2.Zero;

        /// <summary>
        /// The progress value, ranging from 0 to 1, indicating the completion status.
        /// </summary>
        [Range(0, 1)]
        public float Progress = 0.35f;
        public ProgressBar(Vector2 position) : base(position) { }

        /// <summary>
        /// Calculates and returns the offset required to center the progress bar within its background.
        /// </summary>
        /// <returns>A vector representing the centered offset.</returns>
        public Vector2 CenteredOffset() => new((BarWidth - BackgroundWidth) / 2, (BarHeight - BackgroundHeight) / 2);

        public override void Render()
        {
            base.Render();
            float rotation = MathExtended.GetZRotation(Rotation) - 90;
            Vector2 backgroundPosition = Position - new Vector2(BackgroundWidth, BackgroundHeight) / 2;
            Rectangle backgroundRect = new Rectangle(backgroundPosition.X, backgroundPosition.Y, BackgroundWidth, BackgroundHeight);
            Rectangle barRect = new Rectangle(backgroundPosition.X, backgroundPosition.Y, BarWidth * Progress, BarHeight);
            DrawRectanglePro(backgroundRect, new Vector2(BackgroundWidth, BackgroundHeight) / 2, rotation, BackgroundColor);
            DrawRectanglePro(barRect, new Vector2(BackgroundWidth, BackgroundHeight) / 2, rotation, Color.RED);
        }
    }
}
