using GameEngineProject.Source.Entities;
using GameEngineProject.Source.Interfaces;
using Raylib_cs;

namespace GameEngineProject.Source.Components
{
    /// <summary>
    /// Generic renderer component used for rendering Game Objects.
    /// </summary>
    public class Renderer2D : Component
    {
        /// <summary>
        /// The parent's transform.
        /// </summary>
        public Transform transform { get; private set; }


        public override void Awake(GameObject gameObject)
        {
            base.Awake(gameObject);
            transform = gameObject.Transform;
        }


        /// <summary>
        /// How the object will be drawn by the GraphicsManager2D.
        /// </summary>
        public virtual void Render()
        {
            if (!parent.IsActive) return;
        }

    }
}
