using System.Numerics;
using static Basalt.Source.Core.Utils.MathExtended;
using Basalt.Source.Core.Types;

namespace Basalt.Source.Components
{
    /// <summary>
    /// Holds the object's positional data, like the Position and Rotation. It is always included in every Game Object
    /// </summary>
    public class Transform : Component
    {
        /// <summary>
        /// This object's current position.
        /// </summary>
        public Vector3 Position { get; set; }
        /// <summary>
        /// This object's current rotation.
        /// </summary>
        public Quaternion Rotation { get; set; }

        /// <summary>
        /// This object's current scale.
        /// </summary>
        public Vector3 Scale { get; set; } = Vector3.One;

        /// <summary>
        /// Returns a direction vector representing the direction this object is looking at.
        /// </summary>
        public Vector3 Forward { get { return GetForwardVector(Rotation); } }

        /// <summary>
        /// All the children of this transform. Children get moved and rotated with a pivot on this object's Position and Rotation.
        /// </summary>
        public List<Transform> Children { get; private set; } = new();

        /// <summary>
        /// Event triggered whenever this object is moved.
        /// </summary>
        public event EventHandler<TransformPositionUpdatedEventArgs>? OnPositionChanged;

        #region Constructors
        public Transform()
        {
            Position = Vector3.Zero;
            Rotation = Quaternion.Identity;
        }
        public Transform(Vector3 position)
        {
            Position = position;
            Rotation = Quaternion.Identity;
        }
        public Transform(Vector3 position, Quaternion rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        #endregion



        /// <summary>
        /// Moves the transform and all it's children by an amount in each axis
        /// </summary>
        /// <param name="units">The amount to move in each axis</param>
        public void Move(Vector3 units)
        {
            foreach (Transform t in Children)
                t.Move(units);

            Position += units;
            OnPositionChanged?.Invoke(this, new TransformPositionUpdatedEventArgs(Position));
        }

        /// <summary>
        /// Moves the transform and all it's chidren to a point
        /// </summary>
        /// <param name="point">The point to set the position as</param>
        public void MoveTo(Vector3 point)
        {
            foreach (Transform t in Children)
            {
                Vector3 offset = t.Position - Position;
                t.MoveTo(point + offset);
            }
            Position = point;
            OnPositionChanged?.Invoke(this, new TransformPositionUpdatedEventArgs(Position));
        }

        /// <summary>
        /// Adds a children to this transform
        /// </summary>
        /// <param name="obj">The game object to set as children</param>
        public void AddChildren(GameObject obj) => Children.Add(obj.Transform);

        /// <summary>
        /// Adds a children to this transform
        /// </summary>
        /// <param name="transform">The transform to set as children</param>
        public void AddChildren(Transform transform) => Children.Add(transform);

        public override void Destroy()
        {
            foreach (Transform t in Children) t.Destroy();
        }

    }
}
