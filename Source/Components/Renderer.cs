using GameEngineProject.Source.Core;
using GameEngineProject.Source.Core.Graphics;
using GameEngineProject.Source.Entities;
using GameEngineProject.Source.Interfaces;
using Raylib_cs;

namespace GameEngineProject.Source.Components
{
    /// <summary>
    /// Generic renderer component used for rendering Game Objects.
    /// </summary>
    public class Renderer : Component
    {
        /// <summary>
        /// The parent's transform.
        /// </summary>
        public Transform transform { get; private set; }


        public override void Awake(GameObject gameObject)
        {
            base.Awake(gameObject);
            transform = gameObject.Transform;
            Engine.window.RenderWorldSpace += OnRender;
        }

        /// <summary>
        /// Passes a few checks before calling <see cref="Render()"/>
        /// </summary>
        public void OnRender()
        {
            if(!parent.IsActive) return;
            Render();
        }

        /// <summary>
        /// How the object will be drawn by the GraphicsManager2D.
        /// </summary>
        public virtual void Render()
        {
        }

    }
}
