using Basalt.Source.Core.Graphics;
using Basalt.Source.Core.UI;
using Basalt.Source.Core.Utils;
using BasaltEditor.Core.Types;
using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace BasaltEditor.Core.Rendering
{
    internal class EditorWindow : Window
    {
        private readonly EditorConfig config;
        private bool Dragging = false;
        public EditorWindow(EditorConfig config)
        {
            this.config = config;
        }

        public override void Start(string name = "Window")
        {
            SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
            SetConfigFlags(ConfigFlags.FLAG_WINDOW_MAXIMIZED);
            InitWindow(800, 800, name);
            MaximizeWindow();

            List<Label> l = new();
            for(int i = 0; i < 10; i++)
            {
                Label label = new(new Vector2(0, 400) + Vector2.UnitX * i * 50);
                label.SetPivot(Basalt.Source.Core.Types.UIElement.PivotPoint.Left);
                label.Text = i.ToString();
                l.Add(label);
            }

            while (!WindowShouldClose())
            {
                if(IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
                {
                    Vector2 pos = GetWindowPosition();
                    Vector2 delta = GetMouseDelta();
                    SetWindowPosition((int)(pos.X + delta.X), (int)(pos.Y + delta.Y));
                }
                BeginDrawing();
                ClearBackground(config.Theme.Background);
                foreach (var label in l)
                    label.Render();
                RenderUI();
                EndDrawing();
            }
        }

        public void RenderUI()
        {
            DrawLine(0, 30, GetScreenWidth(), 30, config.Theme.DividerColor);
        }
    }
}
