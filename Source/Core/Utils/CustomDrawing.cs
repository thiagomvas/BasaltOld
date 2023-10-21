using Raylib_cs;
using System.Numerics;

namespace GameEngineProject.Source.Core.Utils
{
    /// <summary>
    /// Extends the Drawing calls from Raylib to accept different parameters
    /// </summary>
    public static class CustomDrawing
    {
        /// <summary>
        /// Draws a circle with a Vector2 as position
        /// </summary>
        /// <param name="position">The position to draw in</param>
        /// <param name="radius">The circle radius</param>
        /// <param name="color">The color used</param>
        public static void DrawCircle(Vector2 position, float radius, Color color) => Raylib.DrawCircle((int)position.X, (int)position.Y, radius, color);

        /// <summary>
        /// Draws text using the default font with a Vector2 as position
        /// </summary>
        /// <param name="text">The text drawn</param>
        /// <param name="position">The position to draw in</param>
        /// <param name="fontSize">The font size used</param>
        /// <param name="color">The text color</param>
        public static void DrawText(string text, Vector2 position, int fontSize, Color color) => Raylib.DrawText(text, (int)position.X, (int)position.Y, fontSize, color);

    }
}
