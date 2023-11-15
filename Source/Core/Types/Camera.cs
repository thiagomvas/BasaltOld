using Basalt.Source.Core.Utils;
using Raylib_cs;
using System.Numerics;

namespace Basalt.Source.Core.Types
{
    /// <summary>
    /// Represents a camera for rendering in a 2D or 3D space.
    /// </summary>
    public class Camera : GameObject
    {
        /// <summary>
        /// Specifies the type of rendering for the camera: 2D or 3D.
        /// </summary>
        public enum RenderType { Camera2D, Camera3D }
        /// <summary>
        /// Gets the render type of the camera (2D or 3D).
        /// </summary>
        public RenderType Type { get; init; }
        /// <summary>
        /// The actual Camera2D instance used for 2D rendering.
        /// </summary>
        public Camera2D Camera2D = new();

        /// <summary>
        /// The actual Camera3D instance used for 3D rendering.
        /// </summary>
        public Camera3D Camera3D = new();

        public Vector3 Position
        {
            get
            {
                if (Type == RenderType.Camera2D) return Transform.Position;
                else return Camera3D.position;
            }
        }

        /// <summary>
        /// Gets the forward vector of the object's orientation.
        /// </summary>
        /// <remarks>
        /// For a 2D camera, this property returns the forward vector of the object's transformation. For a 3D camera, it returns the normalized vector pointing from the camera position to the camera target.
        /// </remarks>
        public Vector3 Forward
        {
            get
            {
                if (Type == RenderType.Camera2D)
                {
                    return Transform.Forward;
                }
                else
                {
                    return Vector3.Normalize(Camera3D.target - Camera3D.position);
                }
            }
        }
        /// <summary>
        /// Gets the right vector of the object's orientation.
        /// </summary>
        /// <remarks>
        /// For a 2D camera, this property is not implemented and throws a <see cref="NotImplementedException"/>.
        /// For a 3D camera, it returns the vector that is rotated 90 degrees to the right from the forward vector.
        /// </remarks>
        public Vector3 Right
        {
            get
            {
                if (Type == RenderType.Camera2D)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    float radians = (float)Math.PI / 2;
                    Quaternion rotationQuaternion = Quaternion.CreateFromAxisAngle(Camera3D.up, radians);
                    Vector3 f = Forward;
                    Vector3 forwardOnXZ = Vector3.Normalize(new(f.X, 0, f.Z));
                    Vector3 dir = Vector3.Transform(forwardOnXZ, rotationQuaternion);
                    return Vector3.Normalize(dir);
                }
            }
        }
        /// <summary>
        /// Gets the up vector of the object's orientation.
        /// </summary>

        public Vector3 Up
        {
            get
            {
                if (Type == RenderType.Camera2D)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    return Vector3.Cross(Forward, Right);
                }
            }
        }

        public Camera(RenderType type)
        {
            Transform.OnPositionChanged += UpdateCameraPosition;
            Type = type;

            if (type == RenderType.Camera2D)
            {
                Camera2D.zoom = 1;
                Camera2D.rotation = 0;
            }

            if (type == RenderType.Camera3D)
            {
                Camera3D.target = Vector3.UnitX;
                Camera3D.up = Vector3.UnitY;
                Camera3D.fovy = 70;

            }

        }
        /// <summary>
        /// Updates the camera's focus position
        /// </summary>
        public void UpdateCameraPosition(object? sender, TransformPositionUpdatedEventArgs e)
        {
            if (Type == RenderType.Camera2D)
            {
                Camera2D.target = Conversions.XYFromVector3(Transform.Position);
                Camera2D.offset = new(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2);

            }
            else
            {
                Camera3D.target = Transform.Position + Transform.Forward;
                Camera3D.position = Transform.Position;
            }
        }


        public override void Destroy()
        {
            Transform.OnPositionChanged -= UpdateCameraPosition;
            base.Destroy();
        }
    }
}
