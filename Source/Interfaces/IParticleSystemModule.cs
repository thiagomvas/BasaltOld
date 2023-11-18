using Basalt.Source.Components;
using Basalt.Source.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        void Update(List<ParticleSystem> particles);

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
