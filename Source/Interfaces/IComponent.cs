using GameEngineProject.Source.Entities;

namespace GameEngineProject.Source.Interfaces
{
    /// <summary>
    /// Base Interface that all components will inherit
    /// </summary>
    public interface IComponent
    {
        /// <summary>
        /// Called when a component is created/added to an object.
        /// </summary>
        /// <param name="gameObject">The parent object that contains this component</param>
        void Initialize(GameObject gameObject);
        /// <summary>
        /// Method called every tick/frame
        /// </summary>
        /// <param name="deltaTime">Time between ticks/frames</param>
        void Update(float deltaTime);

        /// <summary>
        /// Called when a game object gets destroyed. Used for unsubscribing to events and disconnecting from everything to run before deletion.
        /// </summary>
        void Destroy();
    }

}
