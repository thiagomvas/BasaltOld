using Raylib_cs;
using static Raylib_cs.Raylib;
namespace Basalt.Source.Core.Utils
{
    public static class Configuration
    {
        public static event Action OnBeforeInit;
        public static event Action OnPostInit;
        public static event Action OnDeinitialize;
        public static void PreInitConfiguration()
        {
            SetConfigFlags(ConfigFlags.FLAG_FULLSCREEN_MODE);
            SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT);
            SetConfigFlags(ConfigFlags.FLAG_WINDOW_ALWAYS_RUN);

            OnBeforeInit?.Invoke();
        }

        public static unsafe void PostInitConfiguration()
        {
            SetTargetFPS(120);
            InitAudioDevice();
            HideCursor();
            DisableCursor();


            Assets.LoadShader("C:\\Users\\Thiago\\source\\repos\\Basalt\\Resources\\Shaders\\lighting.vs", "C:\\Users\\Thiago\\source\\repos\\Basalt\\Resources\\Shaders\\lighting.fs");
            // Get some required shader loactions
            Assets.LoadedShaders["lighting.fs"].Locs[(int)ShaderLocationIndex.SHADER_LOC_VECTOR_VIEW] = GetShaderLocation(Assets.LoadedShaders["lighting.fs"], "viewPos");

            // ambient light level
            int ambientLoc = GetShaderLocation(Assets.LoadedShaders["lighting.fs"], "ambient");
            float[] ambient = new[] { 0.1f, 0.1f, 0.1f, 1.0f };
            SetShaderValue(Assets.LoadedShaders["lighting.fs"], ambientLoc, ambient, ShaderUniformDataType.SHADER_UNIFORM_VEC4);
            Assets.LoadedShaders["lighting.fs"] = Assets.LoadedShaders["lighting.fs"];


            OnPostInit?.Invoke();
        }

        public static void Deinitialize()
        {
            OnDeinitialize?.Invoke();
            UnloadShader(Assets.LoadedShaders["lighting.fs"]);
            CloseAudioDevice();
            CloseWindow();
        }
    }
}
