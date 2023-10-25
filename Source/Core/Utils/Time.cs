using Raylib_cs;

namespace GameEngineProject.Source.Core.Utils
{
    /// <summary>
    /// Support class for all time related data.
    /// </summary>
    public static class Time
    {
        /// <summary>
        /// Time in seconds between frames multiplied by the Time Scale
        /// </summary>
        public static float DeltaTime { get { return Raylib.GetFrameTime() * TimeScale; } }

        /// <summary>
        /// Time in seconds between frames without the Time Scale.
        /// </summary>
        public static float UnscaledDeltaTime { get { return Raylib.GetFrameTime(); } }

        /// <summary>
        /// The time scale factor that affects the speed of time in the game. A value of 1.0 represents normal speed. 
        /// Values less than 1.0 create slow-motion effects, while values greater than 1.0 create fast-forward effects.
        /// </summary>
        public static float TimeScale = 1f;
    }
}
