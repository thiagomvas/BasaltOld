using Basalt.Source.Components;
using Basalt.Source.Core.Types;
using Basalt.Source.Core.Utils;
using Basalt.Source.Interfaces;

namespace Basalt.Source.Modules
{
    /// <summary>
    /// Moves the particle at a constant speed.
    /// </summary>
    public class ParticleSystemConstSpeedModule : IParticleSystemModule
    {
        /// <summary>
        /// The starting speed for any given particle.
        /// </summary>
        public float Speed = 20;


        /// <summary>
        /// Whether to use Scaled or Unscaled delta time.
        /// </summary>
        public DeltaTimeMode DeltaTimeScaling = DeltaTimeMode.Scaled;

        private float deltaTime
        {
            get
            {
                switch (DeltaTimeScaling)
                {
                    case DeltaTimeMode.Scaled:
                        return Time.DeltaTime;
                    case DeltaTimeMode.Unscaled:
                        return Time.UnscaledDeltaTime;
                }

                return 0;
            }
        }

        public void Initialize(Particle particle)
        {
            
        }

        public void Update(Particle particle)
        {
            particle.Object.Transform.Position += particle.Object.Transform.Forward * Speed * deltaTime;
            
        }
        
        public enum DeltaTimeMode { Scaled, Unscaled }
    }
}