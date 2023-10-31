using GameEngineProject.Libraries;
using GameEngineProject.Source.Entities;

namespace GameEngineProject.Source.Core.Types
{
    public class Scene
    {
        public static Player Player;
        /// <summary>
        /// All the game objects on scene.
        /// </summary>
        public List<GameObject> GameObjects { get; private set; } = new();
        /// <summary>
        /// All the UI Elements on scene.
        /// </summary>
        public List<UIElement> UI = new();

        /// <summary>
        /// All the light sources on scene.
        /// </summary>
        public List<Light> Lights = new();

        public List<Camera> Cameras = new();
        public Scene() { }

        public Scene(List<GameObject> gameObjects, List<UIElement> uI, List<Light> lights)
        {
            GameObjects = gameObjects;
            UI = uI;
            Lights = lights;
        }



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
