using GameEngineProject.Source.Core.Types;
using GameEngineProject.Source.Core.Utils;
using Raylib_cs;
namespace GameEngineProject.Source.Entities
{
    /// <summary>
    /// A 2D Camera object with the same properties as a GameObject for ease of control.
    /// </summary>
    public class Camera2DObject : GameObject
    {
        /// <summary>
        /// The actual Camera2D used for rendering.
        /// </summary>
        public Camera2D camera = new();

        public Camera2DObject()
        {
            camera = new Camera2D();
            camera.rotation = 0.0f;
            camera.zoom = 1.0f;


            Transform.OnPositionChanged += UpdateCameraPosition;
        }
        /// <summary>
        /// Updates the camera's focus position
        /// </summary>
        void UpdateCameraPosition(object? sender, TransformPositionUpdatedEventArgs e)
        {
            camera.target = Transform.Position;
        }


        public override void Destroy()
        {
            Transform.OnPositionChanged -= UpdateCameraPosition;
            base.Destroy();
        }
    }
}
