using Raylib_cs;

namespace GameEngineProject.Source.Core.Utils
{
    public static class Assets
    {
        public static string GetAssetsFolder() => Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Assets\\";
        public static Texture2D GetTextureFromAssets(string fileName)
        {
            var img = Raylib.LoadImage($"{GetAssetsFolder()}\\{fileName}");
            var texture = Raylib.LoadTextureFromImage(img);
            Raylib.UnloadImage(img);
            return texture;
        }
    }
}
