using Basalt.Source.Core;
using Basalt.Source.Core.Types;
using Basalt.Source.Interfaces;
using Basalt.Source.Modules;
using System.Numerics;
using Basalt.Source.Core.Utils;
using Raylib_cs;

namespace Basalt.Source.Components
{
    
    /// <summary>
    /// Generates and controls particles to create visual effects. Components that inherit <see cref="Component"/> can be added to any particle in this system.
    /// </summary>
    public class ParticleSystem : Component, IParticleSystem
    {

        /// <summary>
        /// How long the simulation will last before it stops if it isn't looping.
        /// </summary>
        public float Duration = 5f;
        
        /// <summary>
        /// Whether or not the simulation should loop and run endlessly.
        /// </summary>
        public bool Loop = true;
        
        private List<Particle> particles = new();
        private List<IParticleSystemModule> modules = new();
        private bool isPaused = false;
        private float elapsed;
        
        //A base particle object that all objects will clone.
        private readonly GameObject particleObjectBase = new();


        /// <summary>
        /// Adds an <see cref="IParticleSystemModule"/> to the Particle System.
        /// </summary>
        /// <param name="module">The module to add.</param>
        public void AddModule(IParticleSystemModule module)
        {
            modules.Add(module);
        }

        public override void Awake(GameObject gameObject)
        {
            AddModule(new ParticleSystemEmissionModule{Emission = ParticleSystemEmissionModule.EmissionMode.Burst});
            for (int i = 0; i < 5; i++)
            {
                GameObject obj = new();
                Particle p = new(obj);
                particles.Add(p);
                Engine.Instantiate(obj);
            }
            AddComponentToParticles(new SphereRenderer
            {
                Radius = 1,
                Color = Color.SKYBLUE
            });
            
            ResizePool(125);
        }

        public override void Start(GameObject gameObject)
        {
            foreach(IParticleSystemModule module in modules)
                module.Initialize(particles);
            Resume();
        }

        /// <summary>
        /// Starts / Resumes the particle system.
        /// </summary>
        public void Resume()
        {
            isPaused = false;
            foreach (IParticleSystemModule module in modules) module.OnStart();
        }

        /// <summary>
        /// Pauses / Stops the particle system.
        /// </summary>
        public void Stop()
        {
            isPaused = true;
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
            elapsed += Time.DeltaTime;
            if (!Loop && elapsed >= Duration)
                return;
            
            if(!isPaused && Parent.IsActive)
                foreach (IParticleSystemModule module in modules) module.Update(particles);
        }

        /// <summary>
        /// Resizes the Particle System's particle pool.
        /// </summary>
        /// <param name="newSize">The new particle pool size.</param>
        /// <remarks>Changing the amount of particles in the system may change their emission rate in the <see cref="ParticleSystemEmissionModule"/>
        /// which is always in the system by default. To know the emission rate, simply divide the amount of particles by the lifetime in that module.</remarks>
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
            
                    Particle p = new(obj);
                    particles.Add(p);
                    
                    Engine.Instantiate(obj);
                }
            }
        }

        /// <summary>
        /// Tries to get a specific module in the system.
        /// </summary>
        /// <param name="moduleType">The type of the module to try to get</param>
        /// <returns>
        /// The module if it finds any instance of it, null if it doesnt.
        /// </returns>
        public IParticleSystemModule? TryGetModule(Type moduleType)
        {
            return modules.FirstOrDefault(x => x.GetType() == moduleType);
        }
    }
}
