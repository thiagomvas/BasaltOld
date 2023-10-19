using System.Numerics;

namespace GameEngineProject.Source.Core.Utils
{
    public static class Conversions
    {
        /// <summary>
        /// Converts a Vector3 into a Vector2 by removing the Z axis
        /// </summary>
        /// <param name="vector">The vector to convert from</param>
        /// <returns></returns>
        public static Vector2 XYFromVector3(Vector3 vector) => new Vector2(vector.X, vector.Y);

        public static Vector3 XYToVector3(Vector2 vector) => new Vector3(vector.X, vector.Y, 0);

        public static Vector3 ForwardDirectionFromQuaternion(Quaternion rotation) => Vector3.Normalize(new Vector3(2 * (rotation.X * rotation.Z - rotation.W * rotation.Y),
                                                                                                 2 * (rotation.Y * rotation.Z + rotation.W * rotation.X),
                                                                                                 1 - 2 * (rotation.X * rotation.X + rotation.Y * rotation.Y)));
    }
}
