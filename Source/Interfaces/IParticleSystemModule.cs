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
        void Initialize();

        /// <summary>
        /// Updates the particle system module based on the elapsed time.
        /// </summary>
        /// <param name="particles">The list of particles in the current Particle System</param>
        void Update(List<Particle> particles);

        /// <summary>
        /// Handles any events or actions when the particle system starts and/or is resumed.
        /// </summary>
        void OnStart();

        /// <summary>
        /// Handles any events or actions when the particle system stops and/or pauses.
        /// </summary>
        void OnStop();
    }
}
