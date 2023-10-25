using GameEngineProject.Source.Core;
using GameEngineProject.Source.Core.Graphics;
using GameEngineProject.Source.Entities;
using GameEngineProject.Source.Interfaces;

namespace GameEngineProject.Source.Components
{
    /// <summary>
    /// Represents a base component that can be attached to a GameObject.
    /// </summary>
    public class Component : IComponent
    {
        /// <summary>
        /// The GameObject to which this component is attached.
        /// </summary>
        public GameObject parent;

        /// <summary>
        /// Initializes the component when a GameObject is awakened.
        /// </summary>
        /// <param name="gameObject">The GameObject to which this component is attached.</param>
        public virtual void Awake(GameObject gameObject)
        {
            parent = gameObject;
            Engine.window.OnScreenRedraw += OnUpdate;
        }

        /// <summary>
        /// Destroys the component, performing any necessary cleanup.
        /// </summary>
        public virtual void Destroy()
        {
            // Cleanup code can be added here if needed.
        }

        /// <summary>
        /// Initializes the component when a GameObject is started.
        /// </summary>
        /// <param name="gameObject">The GameObject to which this component is attached.</param>
        public virtual void Start(GameObject gameObject)
        {
            // Initialization code for the component can be added here.
        }

        /// <summary>
        /// Event handler for the screen redraw event, which triggers the component's Update method.
        /// </summary>
        public void OnUpdate()
        {
            if (!parent.IsActive)
                return;

            Update();
        }

        /// <summary>
        /// Updates the component's behavior. Override this method to implement custom functionality.
        /// </summary>
        public virtual void Update()
        {
            // Custom update code can be added here.
        }
    }

}
