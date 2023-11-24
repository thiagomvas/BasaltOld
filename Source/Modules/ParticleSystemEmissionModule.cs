using Basalt.Source.Components;
using Basalt.Source.Core.Types;
using Basalt.Source.Core.Utils;
using Basalt.Source.Interfaces;
using System.Numerics;

namespace Basalt.Source.Modules
{
    public class ParticleSystemEmissionModule : IParticleSystemModule
    {

        /// <summary>
        /// How long each particle will last for before being reset.
        /// </summary>
        public float ParticleLifetime = 1;
        
        /// <summary>
        /// The emission mode for the system. Use <see cref="EmissionMode.Overtime"/> for continuous recycling and resetting particles
        /// and <see cref="EmissionMode.Burst"/> for releasing and resetting all the particles at once.
        /// </summary>
        public EmissionMode Emission = EmissionMode.Overtime;

        private readonly Random random = Random.Shared;

        public void Initialize(List<Particle> particles)
        {
            if (Emission == EmissionMode.Overtime)
            {
                for (var i = 0; i < particles.Count; i++)
                {
                    var p = particles[i];
                    float delta = ParticleLifetime / particles.Count;
                    p.LastResetTimestamp = delta * i;
                    p.Object.Transform.Position = new(0, 100000, 0);
                }
            }
        }
        
        public void OnStart(){ }
        public void OnStop(){ }
        


        public void Update(List<Particle> particles)
        {
            foreach(Particle p in particles)
            {
                if(p.LastResetTimestamp + ParticleLifetime <= Time.TimeSinceStartup)
                {
                    Vector3 offset = new(random.Next(5), random.Next(5), random.Next(5));
                    p.Object.Transform.Position = Vector3.Zero + offset;
                    p.Object.Transform.Rotation = new((float) random.NextDouble() * 2f - 1, 
                                                      (float) random.NextDouble() * 2f - 1,
                                                      (float) random.NextDouble() * 2f - 1,
                                                      (float) random.NextDouble() * 2f - 1);
                    p.AddToResetTime(ParticleLifetime);
                }
            }
        }        
        # region Enums
        public enum EmissionMode { Overtime, Burst }
        #endregion
    }
}
