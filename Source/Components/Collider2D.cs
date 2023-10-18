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

        public void CheckAllCollisions(object? sender, EventArgs e)
        {
            foreach(var obj in Globals.GameObjectsOnScene)
            {
                if (obj != parent && obj.TryGetComponent(out Collider2D col)) CheckCollision(obj);
            }
        }
        public void Update(float deltaTime)
        {

        }

        public virtual void CheckCollision(GameObject other)
        {

        }

        public virtual void SolveCollision(Collider2D collided){}

        public virtual void InvokeOnCollision(GameObject collided) => OnCollision?.Invoke(this, new OnCollisionEnterEventArgs(collided));
    }
}
