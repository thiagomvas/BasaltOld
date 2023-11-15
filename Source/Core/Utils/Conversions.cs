using Basalt.Source.Core.Types;
using System.Numerics;
using System.Reflection;

namespace Basalt.Source.Core.Utils
{
    public static class Conversions
    {
        /// <summary>
        /// Converts a Vector3 into a Vector2 by removing the Z axis
        /// </summary>
        /// <param name="vector">The vector to convert from</param>
        /// <returns>A Vector2 with the X and Y components of the original vector</returns>
        public static Vector2 XYFromVector3(Vector3 vector) => new Vector2(vector.X, vector.Y);

        /// <summary>
        /// Converts a Vector2 into a Vector3 using it for X and Y axis
        /// </summary>
        /// <param name="vector">The Vector to convert from</param>
        /// <returns>A Vector3 with the same X and Y from the original vector, but Z = 0</returns>
        public static Vector3 XYToVector3(Vector2 vector) => new Vector3(vector.X, vector.Y, 0);

        /// <summary>
        /// Gets the forward normalized vector from a rotation.
        /// </summary>
        /// <param name="rotation">The rotation quaternionn</param>
        /// <returns>The forward vector from the rotation</returns>
        public static Vector3 ForwardDirectionFromQuaternion(Quaternion rotation) => Vector3.Normalize(new Vector3(2 * (rotation.X * rotation.Z - rotation.W * rotation.Y),
                                                                                                 2 * (rotation.Y * rotation.Z + rotation.W * rotation.X),
                                                                                                 1 - 2 * (rotation.X * rotation.X + rotation.Y * rotation.Y)));

        /// <summary>
        /// Turns a game object and all it's components into readable text.
        /// </summary>
        /// <param name="obj">The game object to convert</param>
        /// <returns>a string containing the object's data and the component's aswell</returns>
        public static string StringifyGameObject(GameObject obj)
        {
            string text = obj.GetType().Name;
            text += $"\n    IsActive:{obj.IsActive}";
            text += "\n    Components:\n";
            foreach (var component in obj.Components)
            {
                text += "        -" + component.GetType().Name + "\n";
                foreach (var field in component.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    text += $"            {field.Name}: {field.GetValue(component)}\n";
                }
            }


            return text;
        }
    }
}
