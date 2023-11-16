using static Raylib_cs.Raylib;
using Raylib_cs;
using System.Numerics;

namespace Basalt.Libraries
{

    public struct Light
    {
        public bool Enabled;
        public LightType Type;
        public Vector3 Position;
        public Vector3 Target;
        public Color Color;

        public int EnabledLoc;
        public int TypeLoc;
        public int PosLoc;
        public int TargetLoc;
        public int ColorLoc;
    }

    public enum LightType
    {
        Directorional,
        Point
    }

    public static class Rlights
    {
        public static Light CreateLight(
            int lightsCount,
            LightType type,
            Vector3 pos,
            Vector3 target,
            Color color,
            Shader shader
        )
        {
            Light light = new();

            light.Enabled = true;
            light.Type = type;
            light.Position = pos;
            light.Target = target;
            light.Color = color;

            string enabledName = "lights[" + lightsCount + "].enabled";
            string typeName = "lights[" + lightsCount + "].type";
            string posName = "lights[" + lightsCount + "].position";
            string targetName = "lights[" + lightsCount + "].target";
            string colorName = "lights[" + lightsCount + "].color";

            light.EnabledLoc = GetShaderLocation(shader, enabledName);
            light.TypeLoc = GetShaderLocation(shader, typeName);
            light.PosLoc = GetShaderLocation(shader, posName);
            light.TargetLoc = GetShaderLocation(shader, targetName);
            light.ColorLoc = GetShaderLocation(shader, colorName);

            UpdateLightValues(shader, light);

            return light;
        }

        public static void UpdateLightValues(Shader shader, Light light)
        {
            // Send to shader light enabled state and type
            SetShaderValue(
                shader,
                light.EnabledLoc,
                light.Enabled ? 1 : 0,
                ShaderUniformDataType.SHADER_UNIFORM_INT
            );
            SetShaderValue(shader, light.TypeLoc, (int)light.Type, ShaderUniformDataType.SHADER_UNIFORM_INT);

            // Send to shader light target position values
            SetShaderValue(shader, light.PosLoc, light.Position, ShaderUniformDataType.SHADER_UNIFORM_VEC3);

            // Send to shader light target position values
            SetShaderValue(shader, light.TargetLoc, light.Target, ShaderUniformDataType.SHADER_UNIFORM_VEC3);

            // Send to shader light color values
            float[] color = new[]
            {
                light.Color.R / (float)255,
                light.Color.G / (float)255,
                light.Color.B/ (float)255,
                light.Color.A / (float)255
            };
            SetShaderValue(shader, light.ColorLoc, color, ShaderUniformDataType.SHADER_UNIFORM_VEC4);
        }
    }

}
