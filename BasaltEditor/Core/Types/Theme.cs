using Raylib_cs;
namespace BasaltEditor.Core.Types
{
    internal struct Theme
    {
        public Color Background;
        public Color DividerColor;
        public Color TextColor;

        public static Theme DarkMode = new Theme()
        {
            Background = new(30, 31, 31, 255),
            TextColor = new(251, 250, 251, 255),
            DividerColor = new(64, 60, 60, 255)
        };
    }
}
