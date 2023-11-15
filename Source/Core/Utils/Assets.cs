using Raylib_cs;

namespace Basalt.Source.Core.Utils
{
    public static class Assets
    {
        /// <summary>
        /// Dictionary containing all the textures loaded. The key is the file name including file extension.
        /// </summary>
        public static Dictionary<string, Texture2D> LoadedTextures = new();
        /// <summary>
        /// Dictionary containing all the models loaded. The key is the file name including file extension.
        /// </summary>
        public static Dictionary<string, Model> LoadedModels = new();
        /// <summary>
        /// Dictionary containing all the shaders loaded. The key is the file name including file extension.
        /// </summary>
        public static Dictionary<string, Shader> LoadedShaders = new();
        /// <summary>
        /// Dictionary containing all the sound assets loaded. The key is the fs file name including file extension.
        /// </summary>
        public static Dictionary<string, Sound> LoadedSounds = new();
        /// <summary>
        /// Dictionary containing all the music assets loaded. The key is the file name including file extension.
        /// </summary>
        public static Dictionary<string, Music> LoadedMusic = new();

        /// <summary>
        /// Loads a texture from a file and stores it in the LoadedTextures dictionary for future use.
        /// </summary>
        /// <param name="fileName">The path to the texture file.</param>
        /// <returns>The loaded Texture2D object.</returns>
        public static Texture2D LoadTexture(string fileName)
        {
            Texture2D texture = Raylib.LoadTexture(fileName);
            LoadedTextures[fileName] = texture;
            return texture;
        }

        /// <summary>
        /// Loads a 3D model from a file and stores it in the LoadedModels dictionary for future use.
        /// </summary>
        /// <param name="fileName">The path to the 3D model file.</param>
        /// <returns>The loaded Model object.</returns>
        public static Model LoadModel(string fileName)
        {
            Model model = Raylib.LoadModel(fileName);
            LoadedModels[fileName] = model;
            return model;
        }

        /// <summary>
        /// Loads a shader from a file and stores it in the LoadedShaders dictionary for future use.
        /// </summary>
        /// <param name="vsFileName">The path to the vertex shader file.</param>
        /// <param name="fsFileName">The path to the fragment shader file.</param>
        /// <returns>The loaded Shader object.</returns>
        public static Shader LoadShader(string vsFileName, string fsFileName)
        {
            Shader shader = Raylib.LoadShader(vsFileName, fsFileName);
            LoadedShaders[Path.GetFileName(fsFileName)] = shader;
            return shader;
        }

        /// <summary>
        /// Loads a sound effect from a file and stores it in the LoadedSounds dictionary for future use.
        /// </summary>
        /// <param name="fileName">The path to the sound effect file.</param>
        /// <returns>The loaded Sound object.</returns>
        public static Sound LoadSound(string fileName)
        {
            Sound sound = Raylib.LoadSound(fileName);
            LoadedSounds[fileName] = sound;
            return sound;
        }

        /// <summary>
        /// Loads a music track from a file and stores it in the LoadedMusic dictionary for future use.
        /// </summary>
        /// <param name="fileName">The path to the music track file.</param>
        /// <returns>The loaded Music object.</returns>
        public static Music LoadMusic(string fileName)
        {
            Music music = Raylib.LoadMusicStream(fileName);
            LoadedMusic[fileName] = music;
            return music;
        }


        /// <summary>
        /// Gets the Resources Folder used by the engine.
        /// </summary>
        public static string ResourcesFolder { get { return FindTargetFolder("Resources"); } }


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
