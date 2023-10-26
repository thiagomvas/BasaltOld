using GameEngineProject.Libraries;
using GameEngineProject.Source.Core;
using GameEngineProject.Source.Core.Utils;
using GameEngineProject.Source.Entities;
using Raylib_cs;
using System.Numerics;

namespace GameEngineProject.Source.Components
{
    public class LightEmitter : Component
    {
        Light Source;
        int index;
        public Color Color = Color.WHITE;
        public LightType Type = LightType.Point;
        public void Setup()
        {
            Source = Rlights.CreateLight(Engine.lights.Count,
                                         Type,
                                         Vector3.One,
                                         Vector3.Zero,
                                         Color,
                                         Assets.LoadedShaders["lighting.fs"]);
            index = Engine.lights.Count;
            Engine.lights.Add(Source);
        }


        public override void Update()
        {
            base.Update();
            Source.Position = parent.Transform.Position;
            Rlights.UpdateLightValues(Assets.LoadedShaders["lighting.fs"], Source);
        }

        public override void Awake(GameObject gameObject)
        {
            base.Awake(gameObject);
            Configuration.OnPostInit += Setup;
        }
    }
}
