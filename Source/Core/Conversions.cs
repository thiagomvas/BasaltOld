using System.Numerics;

namespace GameEngineProject.Source.Core
{
    public static class Conversions
    {
        /// <summary>
        /// Converts a Vector3 into a Vector2 by removing the Z axis
        /// </summary>
        /// <param name="vector">The vector to convert from</param>
        /// <returns></returns>
        public static Vector2 XYFromVector3(Vector3 vector) => new Vector2(vector.X, vector.Y);
    }
}
