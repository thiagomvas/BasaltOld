
using GameEngineProject.Source.Core.Types;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace GameEngineProject.Source.Core.Utils
{
    /// <summary>
    /// Support class for creating UI Elements
    /// </summary>
    public static class UI
    {
        #region Screen Coordinates
        /// <summary>
        /// Gets the center of the screen as a Vector2.
        /// </summary>
        public static Vector2 ScreenCenter { get { return new Vector2(GetScreenWidth() / 2, GetScreenHeight() / 2); } }

        /// <summary>
        /// Gets the top-left corner of the screen as a Vector2.
        /// </summary>
        public static Vector2 ScreenTopLeft { get { return Vector2.Zero; } }

        /// <summary>
        /// Gets the left-center of the screen as a Vector2.
        /// </summary>
        public static Vector2 ScreenLeft { get { return new(0, GetScreenHeight() / 2); } }

        /// <summary>
        /// Gets the bottom-left corner of the screen as a Vector2.
        /// </summary>
        public static Vector2 ScreenBottomLeft { get { return new(0, GetScreenHeight()); } }

        /// <summary>
        /// Gets the bottom-center of the screen as a Vector2.
        /// </summary>
        public static Vector2 ScreenBottom { get { return new(GetScreenWidth() / 2, GetScreenHeight()); } }

        /// <summary>
        /// Gets the bottom-right corner of the screen as a Vector2.
        /// </summary>
        public static Vector2 ScreenBottomRight { get { return new(GetScreenWidth(), GetScreenHeight()); } }

        /// <summary>
        /// Gets the right-center of the screen as a Vector2.
        /// </summary>
        public static Vector2 ScreenRight { get { return new(GetScreenWidth(), GetScreenHeight() / 2); } }

        /// <summary>
        /// Gets the top-right corner of the screen as a Vector2.
        /// </summary>
        public static Vector2 ScreenTopRight { get { return new(GetScreenWidth(), 0); } }

        /// <summary>
        /// Gets the top-center of the screen as a Vector2.
        /// </summary>
        public static Vector2 ScreenTop { get { return new(GetScreenWidth() / 2, 0); } }
        #endregion


        /// <summary>
        /// Adds a new UIElement to the screen.
        /// </summary>
        /// <param name="gameObject">The UIElement to be added into the GUI</param>
        public static void Instantiate(UIElement uiElement)
        {
            Globals.UIElementsOnScene.Add(uiElement);
        }
    }
}
