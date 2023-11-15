using Basalt.Source.Core.Types;
using Raylib_cs;

namespace Basalt.Source.Core.Graphics
{
    public abstract class GraphicsWindow
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
        /// Event called every frame.
        /// </summary>
        public event Action OnScreenRedraw;

        /// <summary>
        /// Event called whenever the screen is resized.
        /// </summary>
        public event Action OnScreenResize;

        /// <summary>
        /// Event called whenever the world is rendered.
        /// </summary>
        public event Action RenderWorldSpace;
        /// <summary>
        /// Event called whenever the UI is rendered.
        /// </summary>
        public event Action RenderUI;
        public abstract void Init(int Width = -1, int Height = -1, Camera cameraObject = null);

        protected void CallOnRedraw() => OnScreenRedraw?.Invoke();
        protected void CallOnResize() => OnScreenResize?.Invoke();
        protected void CallRenderWorldSpace() => RenderWorldSpace?.Invoke();
        protected void CallRenderUI() => RenderUI?.Invoke();
    }
}
