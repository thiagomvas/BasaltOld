using Basalt.Source.Components;
using Basalt.Source.Core.Types;
using Basalt.Source.Core.Utils;
using Basalt.Source.Interfaces;

namespace Basalt.Source.Modules
{
    public class ParticleSystemConstSpeedModule : IParticleSystemModule
    {
        public float Speed = 20;
        public float Dampen = 0f;
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
            float particleSpeed = Math.Max(0, Speed / (Dampen * particle.ElapsedSinceReset * particle.ElapsedSinceReset + 1));
            particle.Object.Transform.Position += particle.Object.Transform.Forward * particleSpeed * deltaTime;
            
        }
        
        public enum DeltaTimeMode { Scaled, Unscaled }
    }
}