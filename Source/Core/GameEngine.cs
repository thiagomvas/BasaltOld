using Basalt.Libraries;
using Basalt.Source.Components;
using Basalt.Source.Core.Graphics;
using Basalt.Source.Core.Types;
using Basalt.Source.Core.UI;
using Basalt.Source.Entities;
using Raylib_cs;
using System.Numerics;
using Basalt.Source.Modules;
using TMath;

namespace Basalt.Source.Core
{
    public static partial class Engine
    {
        //public static Camera Camera = new(Camera.RenderType.Camera3D);
        public static Window window;
        //public static List<Light> lights = new();
        public static Scene CurrentScene = new();

        public static event Action OnUpdate;

        public static void CallUpdate() => OnUpdate?.Invoke();
        public static void Setup()
        {
            window = new GameWindow3D();
            TestScene();
            window.Start();
            //window.Init(1000, 1000, CurrentScene.Cameras[0]);
        }

        public static void Instantiate(GameObject obj) => CurrentScene.InstantiateGameObject(obj);

        public static void TestScene()
        {
            List<GameObject> objects = new();
            List<Light> lights = new();
            GameObject obj = new();
            Player player = new(obj);
            CurrentScene.InstantiateGameObject(obj);

            GameObject lightsource = new();
            lightsource.Transform.Position = new(0, 5, 50);
            lightsource.Transform.Rotation = new(0, 1, 1, 1);
            lightsource.AddComponent(new SphereRenderer
            {
                Color = Color.GREEN,
                Radius = 2
            });
            lightsource.AddComponent(new LightEmitter
            {
                Color = Color.GREEN
            });

            ParticleSystem ps = new ParticleSystem
            {
                Mode = ParticleSystem.EmissionMode.Overtime,
                Loop = false,
                Duration = 2,
                StartDelay = 2,
                ParticleLifetime = 1,
                SpawnRadius = 25,
                RandomRotation = false,
                Shape = ParticleSystem.EmissionShape.OpenCone,
                FlowDirection = lightsource.Transform.Forward
            };
            ps.AddComponentToParticles(new SphereRenderer
            {
                Radius = 1,
                Color = Color.GREEN
            });
            ps.ResizePool(1000);

            ps.AddModule(new ParticleSystemSpeedOverLifetimeModule
            {
                Easing = TEasings.EasingType.Linear,
                StartSpeed = 100,
                EndSpeed = 25
            });
            ps.AddModule(new ParticleSystemColorOverLifetimeModule());
            

            lightsource.AddComponent(ps);
            CurrentScene.InstantiateGameObject(lightsource);

            GameObject lightsource2 = new();
            lightsource2.Transform.Position = new(50, 0, 0);
            lightsource2.AddComponent(new SphereRenderer
            {
                Color = Color.RED,
                Radius = 2
            });
            lightsource2.AddComponent(new LightEmitter
            {
                Color = Color.RED,
            });

            ParticleSystem ps2 = new ParticleSystem
            {
                Shape = ParticleSystem.EmissionShape.Sphere,
                Mode = ParticleSystem.EmissionMode.Overtime,
                ParticleLifetime = 3,
                RandomRotation = true,
                SpawnRadius = 6,
            };

            ps2.AddComponentToParticles(new SphereRenderer
            {
                Color = new(255, 255, 255, 40),
                Radius = 15
            });

            ps2.AddModule(new ParticleSystemConstSpeedModule
            {
                Speed = 1
            });

            ps2.ResizePool(25);
            lightsource2.AddComponent(ps2);

            

            CurrentScene.InstantiateGameObject(lightsource2);


            Label label = new(new Vector2(0, 50))
            {
                Text = "BASALT ENGINE - INPUT SYSTEM BRANCH"
            };
            label.SetPivot(UIElement.PivotPoint.Top);

            CurrentScene.InstantiateUIElement(label);

            CurrentScene.InstantiateCamera(new(Camera.RenderType.Camera3D));

        }
    }
}
