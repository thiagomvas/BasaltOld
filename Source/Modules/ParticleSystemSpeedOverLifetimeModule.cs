using Basalt.Source.Core.Types;
using Basalt.Source.Core.Utils;
using Basalt.Source.Interfaces;
using TMath;

namespace Basalt.Source.Modules
{
    /// <summary>
    /// Controls the speed of particles over their lifetime using <see cref="TEasings"/> functions.
    /// </summary>
    public class ParticleSystemSpeedOverLifetimeModule : IParticleSystemModule
    {
        /// <summary>
        /// The easing type to use to transition from <see cref="StartSpeed"/> to <see cref="EndSpeed"/>
        /// </summary>
        public TEasings.EasingType Easing = TEasings.EasingType.InQuad;

        /// <summary>
        /// The speed at the start of the particle's lifetime
        /// </summary>
        public float StartSpeed = 50;

        /// <summary>
        /// The speed at the end of the particle's lifetime
        /// </summary>
        public float EndSpeed = 0;
        public void Initialize(Particle particle)
        {

        }

        public void Update(Particle particle)
        {
            float speed = StartSpeed + TEasings.GetEasing(Easing,particle.ElapsedSinceReset / particle.Lifetime) *
                          (EndSpeed - StartSpeed);
            particle.Object.Transform.Position += particle.Object.Transform.Forward * speed * Time.DeltaTime;
        }
        
    }
}