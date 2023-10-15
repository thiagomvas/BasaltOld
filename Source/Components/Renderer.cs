using GameEngineProject.Source.Entities;
using GameEngineProject.Source.Interfaces;
using Raylib_cs;

namespace GameEngineProject.Source.Components
{
    public class Renderer : IComponent
    {
        public Transform transform { get; private set; }
        public void Initialize(GameObject gameObject)
        {
            transform = gameObject.transform;
        }

        public void Update(float deltaTime)
        {
            throw new NotImplementedException();
        }

        public virtual void Render()
        {
            Raylib.DrawCircle((int)transform.Position.X, (int)transform.Position.Y, 25, new Color(255, 0, 255, 255));
        }
    }
}
