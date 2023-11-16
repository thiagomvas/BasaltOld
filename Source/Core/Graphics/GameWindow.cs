using Basalt.Source.Core.Types;
using Raylib_cs;

namespace Basalt.Source.Core.Graphics
{
    public abstract class GameWindow : Window
    {

        /// <summary>
        /// Background color for the world.
        /// </summary>
        public Color BackgroundColor = Color.BLACK;

        /// <summary>
        /// Font color used on UI;
        /// </summary>
        public Color FontColor = Color.WHITE;
        /// <summary>
        /// Event called whenever the world is rendered.
        /// </summary>
        public event Action RenderWorldSpace;
        public abstract void Init(int Width = -1, int Height = -1, Camera cameraObject = null);
        protected void CallRenderWorldSpace() => RenderWorldSpace?.Invoke();
    }
}
