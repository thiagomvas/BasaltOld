using Basalt.Source.Components;
using Basalt.Source.Core.Types;
using Basalt.Source.Core.Utils;
using Basalt.Source.Interfaces;
using System.Numerics;

namespace Basalt.Source.Modules
{
    public class ParticleSystemEmissionModule : IParticleSystemModule
    {
        public int ParticleLifetime = 5;
        public float BaseSpeed = 5;
        private readonly ParticleSystem system;

        public ParticleSystemEmissionModule(ParticleSystem system)
        {
            this.system = system;
            if(system == null) throw new NullReferenceException(nameof(system));
        }

        Random random = new();
        public void Initialize()
        {

        }

        public void OnStart()
        {

        }

        public void OnStop()
        {

        }

        public void Update(List<Particle> particles)
        {
            TimeOnly now = TimeOnly.FromDateTime(DateTime.Now);
            TimeSpan dur = new(0, 0, ParticleLifetime);
            foreach(Particle p in particles)
            {
                if(p.resetAt.Add(dur).CompareTo(now) <= 0)
                {
                    Vector3 offset = new(random.Next(5), random.Next(5), random.Next(5));
                    p.Object.Transform.Position = system.parent.Transform.Position + offset;
                    p.SetResetTime(now);
                }
                else
                {
                    p.Object.Transform.Move(Vector3.UnitY * Time.DeltaTime * BaseSpeed); // For Testing
                }
            }
        }
    }
}
