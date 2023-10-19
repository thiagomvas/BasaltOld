using Raylib_cs;

namespace GameEngineProject.Source.Core.Utils
{
    public static class Assets
    {
        /// <summary>
        /// Gets the (expected) Assets folder used by the engine.
        /// </summary>
        /// <returns>The Assets folder path.</returns>
        public static string GetAssetsFolder() => Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Assets");
        /// <summary>
        /// Gets the full path for an asset.
        /// </summary>
        /// <param name="fileName">The file name including file extensions</param>
        /// <returns>The full file path to that asset.</returns>
        public static string GetAssetPath(string fileName) => Path.Combine(GetAssetsFolder(), fileName);

        /// <summary>
        /// Loads a Texture2D from the assets folder
        /// </summary>
        /// <param name="fileName">The texture file name</param>
        /// <returns>The Texture2D file loaded</returns>
        public static Texture2D GetTexture2DFromAssets(string fileName) => Raylib.LoadTexture(Path.Combine(GetAssetsFolder(), fileName));
    }
}
