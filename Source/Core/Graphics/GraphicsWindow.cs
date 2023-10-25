using GameEngineProject.Source.Core.Types;
using Raylib_cs;

namespace GameEngineProject.Source.Core.Graphics
{
    public class GraphicsWindow
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
        public virtual void Init(int Width = -1, int Height = -1, Camera cameraObject = null)
        {

        }

        public void CallOnRedraw() => OnScreenRedraw?.Invoke();
        public void CallOnResize() => OnScreenResize?.Invoke();
        public void CallRenderWorldSpace() => RenderWorldSpace?.Invoke();
        public void CallRenderUI() => RenderUI?.Invoke();
    }
}
