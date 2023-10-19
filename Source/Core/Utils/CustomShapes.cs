using Raylib_cs;
using System.Numerics;

namespace GameEngineProject.Source.Core.Utils
{
    public static class CustomShapes
    {
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
