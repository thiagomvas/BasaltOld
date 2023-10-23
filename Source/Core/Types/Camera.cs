using GameEngineProject.Source.Core.Utils;
using GameEngineProject.Source.Entities;
using Raylib_cs;

namespace GameEngineProject.Source.Core.Types
{
    public class Camera : GameObject
    {
        public enum RenderType { Camera2D,  Camera3D }
        public RenderType Type;
        /// <summary>
        /// The actual Camera2D used for rendering.
        /// </summary>
        public Camera2D Camera2D = new();
        public Camera3D Camera3D = new();

        public Camera(RenderType type)
        {
            Transform.OnPositionChanged += UpdateCameraPosition;
            Type = type;

            if(type == RenderType.Camera2D)
            {
                Camera2D.zoom = 1;
                Camera2D.rotation = 0;
            }

        }
        /// <summary>
        /// Updates the camera's focus position
        /// </summary>
        public void UpdateCameraPosition(object? sender, TransformPositionUpdatedEventArgs e)
        {
            Camera2D.target = Conversions.XYFromVector3(Transform.Position);
            Camera2D.offset = new(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2);
            Camera3D.target = Transform.Position + Transform.Forward;
            Camera3D.position = Transform.Position;
        }


        public override void Destroy()
        {
            Transform.OnPositionChanged -= UpdateCameraPosition;
            base.Destroy();
        }
    }
}
