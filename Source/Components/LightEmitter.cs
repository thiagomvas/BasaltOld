using Basalt.Libraries;
using Basalt.Source.Core.Types;
using Basalt.Source.Core.Utils;
using Raylib_cs;
using System.Numerics;
using Basalt.Source.Core;

namespace Basalt.Source.Components
{
    public class LightEmitter : Component
    {
        private static int _index;
        public Light Source;
        public Color Color = Color.WHITE;
        public LightType Type = LightType.Point;
        public void Setup()
        {
            Source = Rlights.CreateLight(_index,
                                         Type,
                                         Vector3.One,
                                         Vector3.Zero,
                                         Color,
                                         Assets.LoadedShaders["lighting.fs"]);
            _index++;
            Engine.CurrentScene.InstantiateLight(Source);
            Console.WriteLine($"LIGHT INDEX {_index}");
        }

        public override void Update()
        {
            base.Update();
            Source.Position = Parent.Transform.Position;
            Rlights.UpdateLightValues(Assets.LoadedShaders["lighting.fs"], Source);
        }

        public override void Awake(GameObject gameObject)
        {
            base.Awake(gameObject);
            Configuration.OnPostInit += Setup;
        }
    }
}
