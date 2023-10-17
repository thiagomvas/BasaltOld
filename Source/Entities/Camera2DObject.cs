using GameEngineProject.Source.Core;
using GameEngineProject.Source.Core.Types;
using Raylib_cs;

namespace GameEngineProject.Source.Entities
{
    /// <summary>
    /// A 2D Camera object with the same properties as a GameObject for ease of control.
    /// </summary>
    public class Camera2DObject : GameObject
    {
        public Camera2D camera = new();

        public Camera2DObject()
        {
            camera = new Camera2D();
            camera.rotation = 0.0f;
            camera.zoom = 1.0f;


            transform.OnPositionChanged += UpdateCameraPosition;
        }
        void UpdateCameraPosition(object? sender, TransformPositionUpdatedEventArgs e)
        {
            camera.target = Conversions.XYFromVector3(e.NewPosition);
        }
    }
}
