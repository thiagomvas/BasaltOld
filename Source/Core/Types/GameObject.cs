using GameEngine.Source.Attributes;
using GameEngineProject.Source.Components;
using GameEngineProject.Source.Core;
using GameEngineProject.Source.Interfaces;
using System.Numerics;

namespace GameEngineProject.Source.Core.Types
{
    /// <summary>
    /// The Object Class used by the entire engine. It represents any object and it's components that are in any world.
    /// </summary>
    public class GameObject
    {
        private bool AwakeCalled = false;
        private bool StartCalled = false;

        /// <summary>
        /// The object's transform.
        /// </summary>
        public Transform Transform { get; private set; }

        public Renderer Renderer { get; private set; }

        public Collider2D Collider { get; private set; }

        /// <summary>
        /// The object's rigidbody
        /// </summary>
        public Rigidbody Rigidbody { get; private set; }

        /// <summary>
        /// All the components currently included in this object.
        /// </summary>
        public List<Component> Components { get; private set; } = new();
        /// <summary>
        /// All the children attached to this object.
        /// </summary>
        public List<GameObject> Children { get; private set; } = new();

        /// <summary>
        /// Whether or not an object is active. Defines if it will be drawn, interacted with or interact with something.
        /// </summary>
        public bool IsActive = true;

        #region Constructors
        public GameObject()
        {
            Transform = new Transform();
            Components.Add(Transform);
        }
        public GameObject(Vector3 position)
        {
            Transform = new Transform(position);
            Components.Add(Transform);
        }

        public GameObject(Transform transform, List<Component> components, List<GameObject> children)
        {
            Transform = transform;
            Components = components;
            Children = children;
        }

        public GameObject(GameObject other)
        {
            Transform = new Transform(other.Transform.Position, other.Transform.Rotation);
            Components = new List<Component>(other.Components);
            Children = new List<GameObject>(other.Children);
        }

        #endregion

        /// <summary>
        /// Attaches a children to this object
        /// </summary>
        /// <param name="obj">The object to attach</param>
        public void AddChildren(GameObject obj)
        {
            Children.Add(obj);
            Transform.AddChildren(obj);
        }

        /// <summary>
        /// Ran whenever a game object is instantiated.
        /// </summary>
        public virtual void Awake()
        {
            if (AwakeCalled) return;
            AwakeCalled = true;
        }

        /// <summary>
        /// Ran on the first frame of its existance.
        /// </summary>
        public virtual void Start()
        {
            if (StartCalled) return;
            StartCalled = true;
        }

        /// <summary>
        /// Adds a component of type T to this object
        /// </summary>
        /// <typeparam name="T">The component type to be added</typeparam>
        /// <returns>The reference to the component added</returns>
        public T AddComponent<T>() where T : Component, new()
        {
            T component = new();
            component.parent = this;

            var requiredComponents = component.GetType().GetCustomAttributes(typeof(RequiredComponentsAttribute), true)
                                                        .Cast<RequiredComponentsAttribute>()
                                                        .SelectMany(attr => attr.RequiredTypes);

            foreach (var requiredComponent in requiredComponents)
            {
                var type = (Component?)Activator.CreateInstance(requiredComponent);
                bool hasComponent = false;

                foreach (var existingComponent in Components)
                    if (existingComponent.GetType() == type?.GetType()) hasComponent = true;

                if (!hasComponent && type != null) Components.Add(type);
            }
            component.Awake(this);
            Components.Add(component);
            if (Rigidbody == null && component.GetType().BaseType == typeof(Rigidbody)) Rigidbody = GetComponent<Rigidbody>();
            if (Renderer == null && component.GetType().BaseType == typeof(Renderer)) Renderer = GetComponent<Renderer>();
            return component;
        }

        /// <summary>
        /// Gets the reference to the desired component in this object.
        /// </summary>
        /// <typeparam name="T">The component type</typeparam>
        /// <returns>The reference to the component if it exists, null otherwise</returns>
        public T GetComponent<T>() where T : IComponent => Components.OfType<T>().FirstOrDefault();

        /// <summary>
        /// Checks if a component is in a Game Object, if it is, output a reference to it.
        /// </summary>
        /// <typeparam name="T">The component type</typeparam>
        /// <param name="component">The output's reference</param>
        /// <returns>true if the component is in the object, false otherwise</returns>
        public bool TryGetComponent<T>(out T component) where T : IComponent
        {
            component = Components.OfType<T>().FirstOrDefault();
            return component != null;
        }


        /// <summary>
        /// Destroys the game object and their components, unsubscribing from any events and disconnecting from everything.
        /// </summary>
        public virtual void Destroy()
        {
            foreach (var component in Components) component.Destroy();
            Globals.GameObjectsOnScene.Remove(this);
        }

    }

}

