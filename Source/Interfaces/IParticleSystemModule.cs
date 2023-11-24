using Basalt.Source.Components;
using Basalt.Source.Core.Types;

namespace Basalt.Source.Interfaces
{
    /// <summary>
    /// Defines the mandatory implementation for any ParticleSystem module.
    /// </summary>
    public interface IParticleSystemModule
    {
        /// <summary>
        /// Initializes the particle system module.
        /// </summary>
        void Initialize(Particle particle);

        /// <summary>
        /// Updates the particle system module based on the elapsed time.
        /// </summary>
        /// <param name="particle">The reference to the particle being modified</param>
        void Update(Particle particle);
    }
}
