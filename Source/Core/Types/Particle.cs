
namespace Basalt.Source.Core.Types
{
    /// <summary>
    /// Used by the ParticleSystem component to keep track of GameObject lifetimes.
    /// </summary>
    public class Particle
    {

        /// <summary>
        /// The amount of time in seconds elapsed since it was last reset.
        /// </summary>
        public float ElapsedSinceReset = float.MaxValue;

        public float Lifetime = 0;

        /// <summary>
        /// The reference to this particle's object.
        /// </summary>
        public GameObject Object;

        public Particle(GameObject @object)
        {
            Object = @object;
        }

    }
}
