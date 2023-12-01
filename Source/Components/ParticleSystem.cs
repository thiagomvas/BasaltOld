using System.ComponentModel;
using Basalt.Source.Core;
using Basalt.Source.Core.Types;
using Basalt.Source.Interfaces;
using Basalt.Source.Modules;
using System.Numerics;
using Basalt.Source.Core.Utils;

namespace Basalt.Source.Components
{
    
    /// <summary>
    /// Generates and controls particles to create visual effects. Components that inherit <see cref="Component"/> can be added to any particle in this system.
    /// </summary>
    public class ParticleSystem : Component, IParticleSystem
    {

        /// <summary>
        /// How long each particle will last for before being reset.
        /// </summary>
        public float ParticleLifetime = 5;
        /// <summary>
        /// How long the simulation will last before it stops if it isn't looping.
        /// </summary>
        public float Duration = 5f;

        /// <summary>
        /// How many seconds to wait before starting the simulation.
        /// </summary>
        public float StartDelay = 0f;
        
        /// <summary>
        /// Whether or not the simulation should loop and run endlessly.
        /// </summary>
        public bool Loop = true;

        /// <summary>
        /// Whether or not objects should be randomly rotated when spawned.
        /// </summary>
        public bool RandomRotation = true;


        /// <summary>
        /// The maximum distance an object will be from the center of the system when spawned.
        /// </summary>
        public float SpawnRadius = 1;
        
        /// <summary>
        /// The emission mode of the system. Burst will spawn all particles at once, Overtime will spawn them over time.
        /// </summary>
        public EmissionMode Mode = EmissionMode.Overtime;

        /// <summary>
        /// The emission shape of this particle system
        /// </summary>
        public EmissionShape Shape = EmissionShape.Sphere;

        /// <summary>
        /// The direction the particles will flow in (if <see cref="RandomRotation"/> is false).
        /// </summary>
        public Vector3 FlowDirection = Vector3.UnitX;
        
        private readonly List<Particle> particles = new();
        private readonly List<IParticleSystemModule> modules = new();
        private bool isPaused = false;
        private float elapsed;
        private readonly Random random = Random.Shared;
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


        /// <summary>
        /// Fixes the timings of the particles in the system.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void FixParticleTimings()
        {
            float delta = ParticleLifetime / particles.Count;
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].ElapsedSinceReset = Mode switch
                {
                    EmissionMode.Overtime => i * delta,
                    EmissionMode.Burst => 0,
                    _ => throw new ArgumentOutOfRangeException()
                };
                particles[i].Lifetime = ParticleLifetime;
                particles[i].Object.IsActive = false;

            }
            
        }
        
        public override void Start(GameObject gameObject)
        {
            FixParticleTimings();
            foreach (Particle particle in particles)
            {
                foreach(IParticleSystemModule module in modules)
                    module.Initialize(particle);
            }
            Resume();
        }

        /// <summary>
        /// Starts / Resumes the particle system.
        /// </summary>
        public void Resume() => isPaused = false;

        /// <summary>
        /// Pauses / Stops the particle system.
        /// </summary>
        public void Stop() => isPaused = true;

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
            if (isPaused || !Parent.IsActive || (!Loop && elapsed >= Duration))
                return;
            elapsed += Time.DeltaTime;
            if (elapsed < StartDelay) return;
            
            foreach (Particle particle in particles)
            {
                if (particle.ElapsedSinceReset >= particle.Lifetime)
                {
                    ResetParticle(particle);
                }
                
                foreach(IParticleSystemModule module in modules)
                    module.Update(particle);
                
                particle.ElapsedSinceReset += Time.DeltaTime;
            }
        }

        private void ResetParticle(Particle particle)
        {
            particle.ElapsedSinceReset -= particle.Lifetime;
            if(!particle.Object.IsActive) particle.Object.IsActive = true;
            Vector3 offset = Vector3.Zero;

            switch (Shape)
            {
                case EmissionShape.Sphere:
                {
                    Vector3 rand = new((random.NextSingle() * 2 - 1) * SpawnRadius,
                        (random.NextSingle() * 2 - 1) * SpawnRadius, (random.NextSingle() * 2 - 1) * SpawnRadius);
                    offset = Vector3.Normalize(rand) * SpawnRadius;
                }
                    break;
                case EmissionShape.Box:
                {
                    offset = new Vector3((random.NextSingle() * 2 - 1) * SpawnRadius,
                        (random.NextSingle() * 2 - 1) * SpawnRadius, (random.NextSingle() * 2 - 1) * SpawnRadius);
                }
                    break;

                case EmissionShape.OpenCone:
                {
                    float angle = random.NextSingle() * MathF.PI * 2;
                    float height = 5;
                    float radius = SpawnRadius;

                    Vector3 direction = Parent.Transform.Forward;

                    float r = random.NextSingle();

                    float randomRadius = r * radius * random.NextSingle();
                    float randomHeight = height * r;

                    offset = direction * randomHeight + Vector3.Transform(new Vector3(randomRadius, 0, 0),
                        Quaternion.CreateFromAxisAngle(direction, angle));
                    particle.Object.Transform.Rotation =
                        MathExtended.LookAtRotation(Vector3.Zero, offset, Vector3.UnitY);
                }
                    break;

                case EmissionShape.ClosedCone:
                {
                    float angle = random.NextSingle() * MathF.PI * 2;
                    float height = 5;
                    float radius = SpawnRadius;

                    Vector3 direction = Parent.Transform.Forward;

                    float r = random.NextSingle();

                    float randomRadius = r * radius * random.NextSingle();
                    float randomHeight = height * r;

                    offset = direction * randomHeight + Vector3.Transform(new Vector3(randomRadius, 0, 0),
                        Quaternion.CreateFromAxisAngle(direction, angle));
                    }
                    break;
                case EmissionShape.Point:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            particle.Object.Transform.Position = Parent.Transform.Position + offset;
            if (RandomRotation)
                particle.Object.Transform.Rotation = new((float)random.NextDouble() * 2f - 1,
                    (float)random.NextDouble() * 2f - 1,
                    (float)random.NextDouble() * 2f - 1,
                    (float)random.NextDouble() * 2f - 1);
            else if(Shape != EmissionShape.OpenCone) particle.Object.Transform.Rotation = MathExtended.LookAtRotation(Vector3.Zero, FlowDirection, Vector3.UnitY);
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
                    obj.IsActive = false;
                    foreach(Component c in particleObjectBase.Components)
                        obj.AddComponent(c);
            
                    Particle p = new(obj);
                    particles.Add(p);
                    
                    Engine.Instantiate(obj);
                }
            }
            FixParticleTimings();
        }

        /// <summary>
        /// Tries to get a specific module in the system.
        /// </summary>
        /// <param name="moduleType">The type of the module to try to get</param>
        /// <returns>
        /// The module if it finds any instance of it, null if it doesn't.
        /// </returns>
        public IParticleSystemModule? TryGetModule(Type moduleType)
        {
            return modules.FirstOrDefault(x => x.GetType() == moduleType);
        }
        
        public enum EmissionMode { Overtime, Burst }
        public enum EmissionShape { Sphere, Box, ClosedCone, OpenCone, Point } 
    }
}
