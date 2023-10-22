using Raylib_cs;
using System.Numerics;

namespace GameEngineProject.Source.Core.Utils
{
    /// <summary>
    /// A support math class with more methods and functions.
    /// </summary>
    public static class MathExtended
    {
        /// <summary>
        /// Returns the rotation from the origin if it was looking at a target
        /// </summary>
        /// <param name="origin">The origin coordinates</param>
        /// <param name="target">The target's position to rotate towards</param>
        /// <param name="up">The up vector from the origin</param>
        /// <returns>A rotation representing the direction an object is looking at</returns>
        public static Quaternion LookAtRotation(Vector3 origin, Vector3 target, Vector3 up)
        {
            Vector3 forward = Vector3.Normalize(target - origin);
            Vector3 right = Vector3.Normalize(Vector3.Cross(up, forward));
            Vector3 newUp = Vector3.Cross(forward, right);

            Matrix4x4 matrix = new Matrix4x4(
                right.X, right.Y, right.Z, 0,
                newUp.X, newUp.Y, newUp.Z, 0,
                forward.X, forward.Y, forward.Z, 0,
                0, 0, 0, 1
            );

            return Quaternion.CreateFromRotationMatrix(matrix);
        }

        /// <summary>
        /// Gets the forward vector of a rotation.
        /// </summary>
        /// <param name="rotation">The rotation</param>
        /// <returns>The forward vector</returns>
        public static Vector3 GetForwardVector(Quaternion rotation)
        {
            Vector3 rotatedForward = Vector3.Normalize(Vector3.Transform(Vector3.UnitZ, Quaternion.Normalize(rotation)));
            return rotatedForward;
        }

        /// <summary>
        /// Converts a world coordinate into a screen coordinate
        /// </summary>
        /// <param name="worldPosition">The world position</param>
        /// <param name="camera">The camera used</param>
        /// <returns>The screen position equivalent to that world position</returns>
        public static Vector2 WorldToScreenPosition(Vector2 worldPosition, Camera2D camera)
        {
            Vector2 topLeftScreenCornerRelativePos = camera.target - new Vector2((int)(Raylib.GetScreenWidth() / 2), (int)(Raylib.GetScreenHeight() / 2));
            Vector2 onScreenCoords = worldPosition - topLeftScreenCornerRelativePos;
            return onScreenCoords;
        }

        /// <summary>
        /// Converts a screen position to world position
        /// </summary>
        /// <param name="position">The screen position</param>
        /// <param name="camera">The camera used</param>
        /// <returns>The world position equivalent to that screen position</returns>
        public static Vector2 ScreenToWorldPosition(Vector2 position, Camera2D camera)
        {
            Vector2 topLeftScreenCornerRelativePos = camera.target - new Vector2((int)(Raylib.GetScreenWidth() / 2), (int)(Raylib.GetScreenHeight() / 2));
            Vector2 worldPosition = topLeftScreenCornerRelativePos + position;
            return worldPosition;
        }

        /// <summary>
        /// Gets the rotation in the Z axis from a Quaternion
        /// </summary>
        /// <param name="quaternion">The rotation quaternion</param>
        /// <returns>The angle in degrees</returns>
        public static float GetZRotation(Quaternion quaternion)
        {
            float angle = 2 * (float)Math.Acos(quaternion.W);
            float degrees = angle * 180 / (float)Math.PI;
            if (quaternion.Z > 0) return degrees + 90;
            else return -degrees + 90;
        }
    }
}
