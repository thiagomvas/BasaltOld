using Basalt.Source.Core;
using Basalt.Source.Core.Types;
using Basalt.Source.Interfaces;
using Basalt.Source.Modules;
using System.Numerics;

namespace Basalt.Source.Components
{
    public class ParticleSystem : Component, IParticleSystem
    {
        // For testing
        private List<Particle> particles = new();
        private List<IParticleSystemModule> modules = new();
        private readonly GameObject particleObjectBase = new();


        public void AddModule(IParticleSystemModule module)
        {
            modules.Add(module);
        }

        public override void Awake(GameObject gameObject)
        {
            AddModule(new ParticleSystemEmissionModule());
            for (int i = 0; i < 5; i++)
            {
                GameObject obj = new();
                Particle p = new(obj);
                particles.Add(p);
                Engine.Instantiate(obj);
            }
            AddComponentToParticles(new SphereRenderer() { Radius = 1 });
            ResizePool(25);
        }

        public override void Start(GameObject gameObject)
        {
            base.Start(gameObject);
            foreach(IParticleSystemModule module in modules)
                module.Initialize(particles);
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
            foreach (var particle in particles)
            {
                particle.Object.AddComponent(component);
            }
            particleObjectBase.AddComponent(component);

        }

        public override void Update()
        {
            foreach (IParticleSystemModule module in modules) module.Update(particles);
        }

        // TO-DO: Objects arent cloning properly to resize the particles list.
        public void ResizePool(int newSize)
        {
            if (particles.Count == newSize) return;
            if(particles.Count > newSize)
            {
                int delta = particles.Count - newSize;
                particles.RemoveRange(particles.Count - delta, delta);
            }
            else
            {
                while(particles.Count < newSize)
                {
                    GameObject obj = new();
                    foreach(Component c in particleObjectBase.Components)
                        obj.AddComponent(c);
                    obj.ResyncComponentParents();
            
                    Particle p = new(obj);
                    particles.Add(p);
                    
                    Engine.Instantiate(obj);
                }
            }
            
        }
    }
}
