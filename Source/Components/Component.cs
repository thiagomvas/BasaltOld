using GameEngineProject.Source.Core.Graphics;
using GameEngineProject.Source.Entities;
using GameEngineProject.Source.Interfaces;

namespace GameEngineProject.Source.Components
{
    public class Component : IComponent
    {
        public GameObject parent;

        public virtual void Awake(GameObject gameObject)
        {
            parent = gameObject;
            GraphicsWindow2D.OnScreenRedraw += OnUpdate;
        }

        public virtual void Destroy()
        {

        }


        public virtual void Start(GameObject gameObject)
        {
            
        }

        public void OnUpdate()
        {
            if (!parent.IsActive) return;
            Update();
        }
        
        public virtual void Update()
        {
        }
    }
}
