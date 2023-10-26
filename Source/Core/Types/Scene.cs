using GameEngineProject.Libraries;
using GameEngineProject.Source.Entities;

namespace GameEngineProject.Source.Core.Types
{
    public class Scene
    {
        /// <summary>
        /// All the game objects on scene.
        /// </summary>
        public List<GameObject> GameObjects { get; private set; } = new();
        /// <summary>
        /// All the UI Elements on scene.
        /// </summary>
        public List<UIElement> UI = new();

        public List<Light> Lights = new();

        /// <summary>
        /// Adds a Game Object to this scene.
        /// </summary>
        /// <param name="obj">The object to be added.</param>
        public void InstantiateGameObject(GameObject obj) => GameObjects.Add(obj);
        
        /// <summary>
        /// Adds an UI Element to this scene.
        /// </summary>
        /// <param name="obj">The element to be added.</param>
        public void InstantiateUIElement(UIElement elem) => UI.Add(elem);
    }
}
