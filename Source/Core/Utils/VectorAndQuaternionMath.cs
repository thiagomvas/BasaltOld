using Raylib_cs;
using System.Numerics;

namespace GameEngineProject.Source.Core.Utils
{
    public static class VectorAndQuaternionMath
    {
        /// <summary>
        /// Returns the rotation from the origin if it was looking at a target
        /// </summary>
        /// <param name="origin">The origin coordinates</param>
        /// <param name="target">The target's position to rotate towards</param>
        /// <returns>A rotation representing the direction an object is looking at</returns>
        public static Quaternion LookAtRotation(Vector3 origin, Vector3 target)
        {
            Vector2 direction = Vector2.Normalize(Conversions.XYFromVector3(target) - Conversions.XYFromVector3(origin));
            float angleInRadians = MathF.Atan2(direction.Y, direction.X);
            Quaternion rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, angleInRadians);
            return rotation;
        }

        /// <summary>
        /// Gets the forward vector of a rotation.
        /// </summary>
        /// <param name="rotation">The rotation</param>
        /// <returns>The forward vector</returns>
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

        public static float GetZRotation(Quaternion quaternion)
        {
            float angle = 2 * (float)Math.Acos(quaternion.W);
            float degrees = angle * 180 / (float)Math.PI;
            if (quaternion.Z > 0) return degrees + 90;
            else return -degrees + 90;
        }
    }
}
