using GameEngineProject.Source.Core.Types;

namespace GameEngineProject.Source.Interfaces
{
    /// <summary>
    /// Base Interface that all components will inherit
    /// </summary>
    public interface IComponent
    {
        /// <summary>
        /// Called whenever an object is created/instantiated. Usually used for setting up the component and its values.
        /// </summary>
        /// <param name="gameObject">The parent object that contains this component</param>
        public abstract void Awake(GameObject gameObject);

        /// <summary>
        /// Called on the first frame of the game.
        /// </summary>
        /// <param name="gameObject">The parent object that contains this component</param>
        public abstract void Start(GameObject gameObject);
        /// <summary>
        /// Method called every tick/frame
        /// </summary>
        /// <param name="deltaTime">Time between ticks/frames</param>
        public abstract void Update();

        /// <summary>
        /// Called when a game object gets destroyed. Used for unsubscribing to events and disconnecting from everything to run before deletion.
        /// </summary>
        public abstract void Destroy();
    }

}
