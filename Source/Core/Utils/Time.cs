using Raylib_cs;

namespace GameEngineProject.Source.Core.Utils
{
    /// <summary>
    /// Support class for all time related data.
    /// </summary>
    public static class Time
    {
        /// <summary>
        /// Time in seconds between frames
        /// </summary>
        public static float DeltaTime { get { return Raylib.GetFrameTime(); } }
    }
}
