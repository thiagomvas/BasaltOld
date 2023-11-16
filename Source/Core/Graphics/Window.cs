using Basalt.Source.Core.Types;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Basalt.Source.Core.Graphics
{
    public class Window
    {
        public virtual void Start(string name = "Window")
        {
            InitWindow(800, 800, name);
            MaximizeWindow();


            while (!WindowShouldClose())
            {
                BeginDrawing();
                EndDrawing();

            }
        }
    }
}
