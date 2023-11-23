using Basalt.Source.Core;
using Basalt.Source.Core.Types;
using Basalt.Source.Interfaces;
using Basalt.Source.Modules;
using System.Numerics;

namespace Basalt.Source.Components
{
    public class ParticleSystem : Component
    {
        // For testing
        private List<Particle> particles = new();
        private List<IParticleSystemModule> modules = new();

        public void AddModule(IParticleSystemModule module)
        {
            module.Initialize();
            modules.Add(module);
        }

        public override void Awake(GameObject gameObject)
        {
            base.Awake(gameObject);
            AddModule(new ParticleSystemEmissionModule(this));
            TimeOnly now = TimeOnly.FromDateTime(DateTime.Now);
            for (int i = 0; i < 5; i++)
            {
                GameObject obj = new();
                obj.Transform.Position = Vector3.UnitX * i * 5;
                Particle p = new(obj);
                p.resetAt = now;
                particles.Add(p);
                Engine.Instantiate(obj);
            }
            AddComponentToParticles(new SphereRenderer() { Radius = 1 });
        }

        public override void Start(GameObject gameObject)
        {
            base.Start(gameObject);
            Resume();

        }

        /// <summary>
        /// Starts / Resumes the particle system.
        /// </summary>
        public void Resume()
        {
            foreach (IParticleSystemModule module in modules) module.OnStart();
        }

        /// <summary>
        /// Pauses / Stops the particle system.
        /// </summary>
        public void Stop()
        {
            foreach (IParticleSystemModule module in modules) module.OnStop();
        }

        /// <summary>
        /// Clones a component and adds it to all the particles.
        /// </summary>
        /// <param name="component">The component to be added.</param>
        public void AddComponentToParticles(Component component)
        {
            foreach(var particle in particles)
            {
                particle.Object.AddComponent(component);
            }
        }

        public override void Update()
        {
            foreach (IParticleSystemModule module in modules) module.Update(particles);
        }
    }
}
