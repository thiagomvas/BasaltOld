using GameEngineProject.Source.Components;
using GameEngineProject.Source.Entities;
using GameEngineProject.Source.Interfaces;
using Raylib_cs;

namespace GameEngineProject.Source.Core
{
    public static class Globals
    {
        /// <summary>
        /// The list of all Game Objects currently in the world.
        /// </summary>
        public static List<GameObject> GameObjectsOnScene { get; private set; } = new();

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

        public static string GetAssetsFolder() => Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Assets\\";
        public static Texture2D GetTextureFromAssets(string fileName)
        {
            var img = Raylib.LoadImage($"{GetAssetsFolder()}\\{fileName}");
            var texture = Raylib.LoadTextureFromImage(img);
            Raylib.UnloadImage(img);
            return texture;
        }




    }
}
