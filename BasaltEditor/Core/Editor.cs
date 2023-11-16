using BasaltEditor.Core.Rendering;
using BasaltEditor.Core.Types;
using static Raylib_cs.Raylib;

namespace BasaltEditor.Core
{
    internal class Editor
    {
        private readonly EditorConfig config;

        public Editor(EditorConfig? config = null)
        {
            this.config = config ?? new();
        }

        public void Init()
        {
            EditorWindow window = new EditorWindow(config);
            window.Start("Basalt Editor");
        }
    }
}
