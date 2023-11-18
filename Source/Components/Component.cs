using Basalt.Source.Core;
using Basalt.Source.Core.Types;
using Basalt.Source.Interfaces;

namespace Basalt.Source.Components
{
    /// <summary>
    /// Represents a base component that can be attached to a GameObject.
    /// </summary>
    public class Component : IComponent, ICloneable
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
            Engine.OnUpdate += OnUpdate;
            Start(gameObject);
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

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

}
