using Basalt.Source.Components;
using Basalt.Source.Core.Types;

namespace Basalt.Source.Interfaces
{

    /// <summary>
    /// Provides a mechanism to control the system's and particles' behaviours
    /// </summary>
    /// <remarks>
    /// Particle systems are intended to also inherit <see cref="Component"/> if data on the parent <see cref="GameObject"/> is necessary (such as position). 
    /// </remarks>
    public interface IParticleSystem
    {
        /// <summary>
        /// Adds a component to the particles managed by the particle system.
        /// </summary>
        /// <param name="component">The component to be added to the particles.</param>
        void AddComponentToParticles(Component component);

        /// <summary>
        /// Adds a module to the particle system, enhancing its functionality.
        /// </summary>
        /// <param name="module">The particle system module to be added.</param>
        void AddModule(IParticleSystemModule module);

        /// <summary>
        /// Resumes the emission of particles in the particle system.
        /// </summary>
        void Resume();

        /// <summary>
        /// Stops the emission of particles in the particle system.
        /// </summary>
        void Stop();

        /// <summary>
        /// Resizes the particle system.
        /// </summary>
        void ResizePool(int newSize);
    }
}