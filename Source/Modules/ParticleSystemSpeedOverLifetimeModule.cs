using Basalt.Source.Core.Types;
using Basalt.Source.Core.Utils;
using Basalt.Source.Interfaces;
using TMath;

namespace Basalt.Source.Modules
{
    public class ParticleSystemSpeedOverLifetimeModule : IParticleSystemModule
    {
        public TEasings.EasingType Easing = TEasings.EasingType.InQuad;
        public float StartSpeed = 50;
        public float EndSpeed = 0;
        public void Initialize(Particle particle)
        {

        }

        public void Update(Particle particle)
        {
            float speed = TEasings.GetEasing(Easing,particle.ElapsedSinceReset / particle.Lifetime) *  MathF.Abs(StartSpeed - EndSpeed);
            particle.Object.Transform.Position += particle.Object.Transform.Forward * speed * Time.DeltaTime;
        }
        
    }
}