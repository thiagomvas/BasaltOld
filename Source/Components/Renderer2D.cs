using GameEngineProject.Source.Entities;
using GameEngineProject.Source.Interfaces;
using Raylib_cs;

namespace GameEngineProject.Source.Components
{
    /// <summary>
    /// Generic renderer component used for rendering Game Objects.
    /// </summary>
    public class Renderer2D : IComponent
    {
        /// <summary>
        /// The parent's transform.
        /// </summary>
        public Transform transform { get; private set; }
        public void Initialize(GameObject gameObject)
        {
            transform = gameObject.transform;
        }

        public void Update(float deltaTime)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// How the object will be drawn by the GraphicsManager2D.
        /// </summary>
        public virtual void Render()
        {
            Raylib.DrawCircle((int)transform.Position.X, (int)transform.Position.Y, 25, new Color(255, 0, 255, 255));
        }
    }
}
