
namespace Basalt.Source.Core.Types
{
    /// <summary>
    /// Used by the ParticleSystem component to keep track of GameObject lifetimes.
    /// </summary>
    public struct Particle
    {
        /// <summary>
        /// The time this particle was last reset since its instantiation.
        /// </summary>
        public TimeOnly resetAt = TimeOnly.FromDateTime(DateTime.Now);

        /// <summary>
        /// The reference to this particle's object.
        /// </summary>
        public GameObject Object;

        public Particle(GameObject @object) : this()
        {
            Object = @object;
        }
    }
}
