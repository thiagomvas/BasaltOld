using Raylib_cs;

namespace GameEngineProject.Source.Core.Utils
{
    public static class Assets
    {
        public static string ResourcesFolder { get { return FindTargetFolder("Resources"); } }
        public static Shader LightingShader;

        /// <summary>
        /// Gets the (expected) Assets folder used by the engine.
        /// </summary>
        /// <returns>The Assets folder path.</returns>
        public static string GetAssetsFolder() => Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Assets");

        /// <summary>
        /// Gets the path to a file in the resources folder
        /// </summary>
        /// <param name="fileName">The file name including subfolders inside Resources</param>
        /// <returns>The file path to the file</returns>
        public static string GetResourcesPath(string fileName)
        {
            return Path.Combine(ResourcesFolder, fileName);
        }

        /// <summary>
        /// Recursively searches for a specified folder in the current directory and its parent directories.
        /// If found, it returns the full path to the folder; otherwise, it returns null.
        /// </summary>
        /// <param name="folder">The name of the target folder to search for.</param>
        /// <returns>
        /// The full path to the target folder if found, or null if the folder is not found in the current
        /// directory or its parent directories.
        /// </returns>
        public static string FindTargetFolder(string folder)
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            while (currentDirectory != null)
            {
                string targetFolder = Path.Combine(currentDirectory, folder);

                if (Directory.Exists(targetFolder))
                {
                    return targetFolder;
                }

                DirectoryInfo parentDirectory = Directory.GetParent(currentDirectory);

                if (parentDirectory != null)
                {
                    currentDirectory = parentDirectory.FullName;
                }
                else
                {
                    // We've reached the root directory, and "target" folder was not found.
                    // You can decide what to do in this case. For this example, we'll return null.
                    return null;
                }
            }

            // This should never be reached, but if it is, return null.
            return null;
        }
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
