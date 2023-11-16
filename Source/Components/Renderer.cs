using Basalt.Source.Core;
using Basalt.Source.Core.Types;

namespace Basalt.Source.Components
{
    /// <summary>
    /// Generic renderer component used for rendering Game Objects.
    /// </summary>
    public abstract class Renderer : Component
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
        /// Passes a few checks before calling <see cref="Render()"/>
        /// </summary>
        public void OnRender()
        {
            if (!parent.IsActive) return;
            Render();
        }

        /// <summary>
        /// How the object will be drawn by the GraphicsManager2D.
        /// </summary>
        public abstract void Render();

    }
}
