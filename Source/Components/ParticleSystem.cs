using Basalt.Source.Core;
using Basalt.Source.Core.Types;
using Basalt.Source.Core.Utils;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Basalt.Source.Components
{
    public class ParticleSystem : Component
    {
        // For testing
        private List<GameObject> particles = new();


        public override void Awake(GameObject gameObject)
        {
            base.Awake(gameObject);

            SphereRenderer rend = new SphereRenderer() { Radius = 2 };

            for (int i = 0; i < 5; i++)
            {
                GameObject obj = new();
                obj.Transform.Position = Vector3.UnitX * i * 5;
                particles.Add(obj);
                Engine.Instantiate(obj);
            }
            AddComponentToParticles(rend);

        }



        /// <summary>
        /// Clones a component and adds it to all the particles.
        /// </summary>
        /// <param name="component">The component to be added.</param>
        public void AddComponentToParticles(Component component)
        {
            foreach(var particle in particles)
            {
                particle.AddComponent(component);
            }
        }

        public override void Update()
        {
            foreach(var particle in particles)
            {

            }
        }
    }
}
