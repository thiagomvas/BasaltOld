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
            GraphicsWindow2D.OnScreenRedraw += Update;
        }

        public virtual void Destroy()
        {

        }


        public void Start(GameObject gameObject)
        {

        }

        public void Update()
        {

        }
    }
}
