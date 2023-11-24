using Basalt.Source.Core;
using Basalt.Source.Core.Types;
using System.Numerics;

namespace Basalt.Source.Components
{
    public class Collider2D : Component
    {

        /// <summary>
        /// Event triggered when this object collides with something.
        /// </summary>
        public event EventHandler<OnCollisionEnterEventArgs> OnCollision;

        public Collider2D() { }
        public override void Destroy()
        {
            Engine.OnUpdate -= CheckAllCollisions;
        }

        public override void Start(GameObject gameObject)
        {
            base.Start(gameObject);
            Engine.OnUpdate += CheckAllCollisions;
        }

        /// <summary>
        /// Method to be ran to check if object is colliding with something.
        /// </summary>
        private void CheckAllCollisions()
        {
            if (!Parent.IsActive) return;
            foreach (var obj in Globals.GameObjectsOnScene)
            {
                if (obj != Parent && obj.TryGetComponent(out Collider2D col)) CheckCollision(obj);
            }
        }

        /// <summary>
        /// The method used to check if an object is colliding with this object.
        /// </summary>
        /// <param name="other">The other object to check collisions with</param>
        public virtual void CheckCollision(GameObject other)
        {
            if (!Parent.IsActive) return;
        }

        /// <summary>
        /// The method used to solve the collision (Offset the position so it's not inside the object or do something else)
        /// </summary>
        /// <param name="collided">The object that collided with this</param>
        public virtual void SolveCollision(Collider2D collided) { if (!Parent.IsActive) return; }

        /// <summary>
        /// Invokes the OnCollisionEvent event.
        /// </summary>
        /// <param name="collided">The GameObject that collided with this object</param>
        public void InvokeOnCollision(GameObject collided) => OnCollision?.Invoke(this, new OnCollisionEnterEventArgs(collided));

        /// <summary>
        /// Method used by the Debug System to draw the hitboxes on selection.
        /// </summary>
        /// <param name="screenPos">The on screen coordinates to use as center</param>
        public virtual void DrawDebugHitbox(Vector2 screenPos)
        {
            if (!Parent.IsActive) return;
        }
    }
}
