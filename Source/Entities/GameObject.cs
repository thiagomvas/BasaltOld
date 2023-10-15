using GameEngine.Source.Attributes;
using GameEngineProject.Source.Components;
using GameEngineProject.Source.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameEngineProject.Source.Entities
{
    public class GameObject
    {
        public Transform transform { get; private set; }
        public List<IComponent> Components { get; private set; } = new();
        public GameObject()
        {
            transform = new Transform();
            Components.Add(transform);
        }
        public GameObject(Vector3 position)
        {
            transform = new Transform(position);
            Components.Add(transform);
            Console.WriteLine(Components.Count);
        }
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

        public T GetComponent<T>() where T : IComponent => Components.OfType<T>().FirstOrDefault();
        public bool TryGetComponent<T>(out T component) where T : IComponent
        {
            component = Components.OfType<T>().FirstOrDefault();
            return component != null;
        }
    }

}

