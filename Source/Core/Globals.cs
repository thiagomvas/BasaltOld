using Basalt.Source.Core.Types;
using Basalt.Source.Interfaces;

namespace Basalt.Source.Core
{
    public static class Globals
    {
        /// <summary>
        /// Gets the list of all Game Objects present on the scene.
        /// </summary>
        public static List<GameObject> GameObjectsOnScene { get; private set; } = new();

        /// <summary>
        /// Gets the list of all UIElements present on the scene.
        /// </summary>
        public static List<UIElement> UIElementsOnScene { get; private set; } = new();

        /// <summary>
        /// The list of all components currently in the world. Mostly used for debugging.
        /// </summary>
        public static Dictionary<Type, List<IComponent>> AllComponentsOnScene { get; private set; } = new();

        /// <summary>
        /// Adds a new Game Object to the world.
        /// </summary>
        /// <param name="gameObject">The object to be added to the world</param>
        public static void Instantiate(GameObject gameObject)
        {
            GameObjectsOnScene.Add(gameObject);

            foreach (var component in gameObject.Components)
            {
                var componentType = component.GetType();
                if (!AllComponentsOnScene.ContainsKey(componentType))
                {
                    AllComponentsOnScene[componentType] = new List<IComponent>();
                }
                AllComponentsOnScene[componentType].Add(component);
            }
        }
    }
}
