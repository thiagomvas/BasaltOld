using Basalt.Source.Components;
using Basalt.Source.Core.Types;
using Basalt.Source.Core.Utils;
using Basalt.Source.Interfaces;
using System.Numerics;

namespace Basalt.Source.Modules
{
    public class ParticleSystemEmissionModule : IParticleSystemModule
    {
        public float ParticleLifetime = 1;

        public ParticleSystemEmissionModule()
        {
        }

        Random random = new();


        public void Initialize(List<Particle> particles)
        {
            for (var i = 0; i < particles.Count; i++)
            {
                var p = particles[i];
                float delta = ParticleLifetime / particles.Count;
                p.LastResetTimestamp = delta * i;
                Console.WriteLine($"Emission Log: {delta} {i} {p.LastResetTimestamp}");
            }
            Console.WriteLine("Initialize Called");
        }
        
        public void OnStart()
        {

        }

        public void OnStop()
        {

        }


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
    }
}
