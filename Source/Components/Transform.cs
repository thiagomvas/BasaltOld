using GameEngineProject.Source.Core.Types;
using GameEngineProject.Source.Entities;
using GameEngineProject.Source.Interfaces;
using System.Numerics;
using static GameEngineProject.Source.Core.Utils.MathExtended;
using static GameEngineProject.Source.Core.Utils.Conversions;

namespace GameEngineProject.Source.Components
{
    /// <summary>
    /// Holds the object's positional data, like the Position and Rotation. It is always included in every Game Object
    /// </summary>
    public class Transform : Component
    {
        /// <summary>
        /// This object's current position.
        /// </summary>
        public Vector2 Position { get; set; }
        /// <summary>
        /// This object's current rotation.
        /// </summary>
        public Quaternion Rotation { get; set; }

        /// <summary>
        /// Returns a direction vector representing the direction this object is looking at.
        /// </summary>
        public Vector2 Forward { get { return GetForwardVector(Rotation); } }

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
            Position = Vector2.Zero;
            Rotation = Quaternion.Identity;
        }

        public Transform(Vector2 position, Quaternion rotation, List<Transform> children, GameObject? parent = null)
        {
            Position = position;
            Rotation = rotation;
            Children = children;
            this.parent = parent;
        }

        public Transform(Transform other)
        {
            this.Position = other.Position;
            this.Rotation = other.Rotation;
            this.parent = other.parent;
            this.Children = new List<Transform>(other.Children);
        }

        public Transform(Vector2 position)
        {
            Position = position;
            Rotation = Quaternion.Identity;
        }

        #endregion



        /// <summary>
        /// Moves the transform and all it's children by an amount in each axis
        /// </summary>
        /// <param name="units">The amount to move in each axis</param>
        public void Move(Vector2 units)
        {
            foreach(Transform t in Children)
                t.Move(units);

            Position += units;
            OnPositionChanged?.Invoke(this, new TransformPositionUpdatedEventArgs(Position));
        }

        /// <summary>
        /// Moves the transform and all it's chidren to a point
        /// </summary>
        /// <param name="point">The point to set the position as</param>
        public void MoveTo(Vector2 point)
        {
            foreach(Transform t in Children)
            {
                Vector2 offset = t.Position - Position;
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
