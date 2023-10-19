using GameEngine.Source.Attributes;
using GameEngineProject.Source.Components;
using GameEngineProject.Source.Core;
using GameEngineProject.Source.Interfaces;
using System.Numerics;

namespace GameEngineProject.Source.Entities
{
    /// <summary>
    /// The Object Class used by the entire engine. It represents any object and it's components that are in any world.
    /// </summary>
    public class GameObject
    {
        /// <summary>
        /// The object's transforms.
        /// </summary>
        public Transform transform { get; private set; }
        /// <summary>
        /// All the components currently included in this object.
        /// </summary>
        public List<IComponent> Components { get; private set; } = new();
        /// <summary>
        /// All the children attached to this object.
        /// </summary>
        public List<GameObject> Children { get; private set; } = new();

        #region Constructors
        public GameObject()
        {
            transform = new Transform();
            Components.Add(transform);
        }
        public GameObject(Vector3 position)
        {
            transform = new Transform(position);
            Components.Add(transform);
        }
        
        public GameObject(Transform transform, List<IComponent> components, List<GameObject> children)
        {
            this.transform = transform;
            this.Components = components;
            this.Children = children;
        }

        public GameObject(GameObject other)
        {
            transform = other.transform;
            Components = new List<IComponent>(other.Components);
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
            transform.AddChildren(obj);
        }

        /// <summary>
        /// Adds a component of type T to this object
        /// </summary>
        /// <typeparam name="T">The component type to be added</typeparam>
        /// <returns>The reference to the component added</returns>
        public T AddComponent<T>() where T : IComponent, new()
        {
            T component = new();

            var requiredComponents = component.GetType().GetCustomAttributes(typeof(RequiredComponentsAttribute), true)
                                                        .Cast<RequiredComponentsAttribute>()
                                                        .SelectMany(attr => attr.RequiredTypes);

            foreach (var requiredComponent in requiredComponents)
            {
                var type = (IComponent?)Activator.CreateInstance(requiredComponent);
                type.Initialize(this);
                bool hasComponent = false;

                foreach (var existingComponent in Components)
                    if (existingComponent.GetType() == type?.GetType()) hasComponent = true;

                if (!hasComponent && type != null) Components.Add(type);
            }
            component.Initialize(this);
            Components.Add(component);
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

