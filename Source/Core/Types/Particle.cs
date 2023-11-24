
namespace Basalt.Source.Core.Types
{
    /// <summary>
    /// Used by the ParticleSystem component to keep track of GameObject lifetimes.
    /// </summary>
    public class Particle
    {
        /// <summary>
        /// The time in seconds this particle was last reset since its instantiation.
        /// </summary>
        public float LastResetTimestamp = 0;

        /// <summary>
        /// The reference to this particle's object.
        /// </summary>
        public GameObject Object;

        public Particle(GameObject @object)
        {
            Object = @object;
        }

        public void AddToResetTime(float timestamp) => LastResetTimestamp += timestamp;
    }
}
