using Basalt.Source.Core.Types;
using Basalt.Source.Interfaces;
using Raylib_cs;

namespace Basalt.Source.Modules
{
    public class ParticleSystemColorOverLifetimeModule : IParticleSystemModule
    {
        public Color[] Colors = {
            Color.RED,
            Color.ORANGE,
            Color.YELLOW,
            Color.GREEN,
            Color.SKYBLUE,
            Color.BLUE,
            Color.VIOLET
        };

        public void Initialize(Particle particle)
        {

        }

        public void Update(Particle particle)
        {
            var lifetime = particle.ElapsedSinceReset / particle.Lifetime;
            int index = (int) Math.Floor(lifetime * (Colors.Length)) + Colors.Length - 1;

            Color c1 = Colors[(index) % Colors.Length], c2 = Colors[(index + 1) % Colors.Length];

            Color color = new(
                (byte)(c1.R + (c2.R - c1.R) * (lifetime * Colors.Length % 1)),
                (byte)(c1.G + (c2.G - c1.G) * (lifetime * Colors.Length % 1)),
                (byte)(c1.B + (c2.B - c1.B) * (lifetime * Colors.Length % 1)),
                (byte)255
            );

            particle.Object.Renderer.Color = color;
        }
    }
}
