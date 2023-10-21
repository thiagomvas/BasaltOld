using Raylib_cs;
using System.Numerics;

namespace GameEngineProject.Source.Core.Utils
{
    public static class CustomShapes
    {
        /// <summary>
        /// Draws a filled polygon using Raylib library.
        /// </summary>
        /// <param name="points">An array of Vector2 representing the polygon's vertices.</param>
        /// <param name="color">The fill color of the polygon.</param>
        public static void DrawFilledPoly(Vector2[] points, Color color)
        {
            Vector2[] pointsLooped = points.Append(points[0]).ToArray();
            Raylib.DrawLineStrip(pointsLooped, pointsLooped.Length, color);
            for(int i = 1; i < points.Length - 1; i++)
            {
                Raylib.DrawTriangle(points[0], points[i], points[i + 1], color);
            }
        }
    }
}
