using GameEngineProject.Source.Core;
using GameEngineProject.Source.Core.Graphics;
using GameEngineProject.Source.Core.Types;
using GameEngineProject.Source.Entities;
using GameEngineProject.Source.Interfaces;

namespace GameEngineProject.Source.Components
{
    public class Collider2D : IComponent
    {
        public GameObject parent;

        /// <summary>
        /// Event triggered when this object collides with something.
        /// </summary>
        public event EventHandler<OnCollisionEnterEventArgs> OnCollision;

        public Collider2D() { }
        public void Destroy()
        {
            GraphicsWindow2D.OnScreenRedraw -= CheckAllCollisions;
        }

        public void Initialize(GameObject gameObject)
        {
            parent = gameObject;
            GraphicsWindow2D.OnScreenRedraw += CheckAllCollisions;
        }

        /// <summary>
        /// Method to be ran to check if object is colliding with something.
        /// </summary>
        private void CheckAllCollisions(object? sender, EventArgs e)
        {
            foreach(var obj in Globals.GameObjectsOnScene)
            {
                if (obj != parent && obj.TryGetComponent(out Collider2D col)) CheckCollision(obj);
            }
        }
        public void Update(float deltaTime)
        {

        }

        /// <summary>
        /// The method used to check if an object is colliding with this object.
        /// </summary>
        /// <param name="other">The other object to check collisions with</param>
        public virtual void CheckCollision(GameObject other)
        {

        }

        /// <summary>
        /// The method used to solve the collision (Offset the position so it's not inside the object or do something else)
        /// </summary>
        /// <param name="collided">The object that collided with this</param>
        public virtual void SolveCollision(Collider2D collided){}

        /// <summary>
        /// Invokes the OnCollisionEvent event.
        /// </summary>
        /// <param name="collided">The GameObject that collided with this object</param>
        public virtual void InvokeOnCollision(GameObject collided) => OnCollision?.Invoke(this, new OnCollisionEnterEventArgs(collided));
    }
}
