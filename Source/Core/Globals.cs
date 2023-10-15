using GameEngineProject.Source.Components;
using GameEngineProject.Source.Entities;
using GameEngineProject.Source.Interfaces;

namespace GameEngineProject.Source.Core
{
    public static class Globals
    {
        public static List<GameObject> GameObjectsOnScene { get; private set; } = new();
        public static Dictionary<Type, List<IComponent>> AllComponentsOnScene { get; private set; } = new();

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

            Console.WriteLine($"Instantiated {gameObject}, {AllComponentsOnScene.Count}");
        }

        


    }
}
