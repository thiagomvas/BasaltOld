using Raylib_cs;
using System.Numerics;

namespace GameEngineProject.Source.Core.Utils
{
    public static class VectorAndQuaternionMath
    {
        public static Quaternion LookAtRotation(Vector3 origin, Vector3 target)
        {
            Vector2 direction = Vector2.Normalize(Conversions.XYFromVector3(target) - Conversions.XYFromVector3(origin));
            float angleInRadians = MathF.Atan2(direction.Y, direction.X);
            Quaternion rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, angleInRadians);
            return rotation;
        }

        public static Vector2 GetForwardVector(Quaternion rotation)
        {
            Vector2 forward = new Vector2(1, 0);
            Vector2 rotatedForward = Vector2.Transform(forward, Quaternion.Normalize(rotation));
            return rotatedForward;
        }

        public static Vector2 WorldToScreenPosition(Vector2 worldPosition, Camera2D camera)
        {
            Vector2 topLeftScreenCornerRelativePos = camera.target - new Vector2((int)(Raylib.GetScreenWidth() / 2), (int)(Raylib.GetScreenHeight() / 2));
            Vector2 onScreenCoords = worldPosition - topLeftScreenCornerRelativePos;
            return onScreenCoords;
        }

        public static Vector2 ScreenToWorldPosition(Vector2 position, Camera2D camera)
        {
            Vector2 topLeftScreenCornerRelativePos = camera.target - new Vector2((int)(Raylib.GetScreenWidth() / 2), (int)(Raylib.GetScreenHeight() / 2));
            Vector2 worldPosition = topLeftScreenCornerRelativePos + position;
            return worldPosition;
        }
    }
}
