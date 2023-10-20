
using GameEngineProject.Source.Entities;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace GameEngineProject.Source.Core.Utils
{
    /// <summary>
    /// Support class for creating UI Elements
    /// </summary>
    public static class UI
    {
        /// <summary>
        /// Returns the screen center's position
        /// </summary>
        public static Vector2 ScreenCenter { get { return new Vector2(GetScreenWidth()/2, GetScreenHeight()/2); } }
        public static Vector2 ScreenTopLeft { get { return Vector2.Zero; } }
        public static Vector2 ScreenLeft { get { return new(0, GetScreenHeight() / 2); } }
        public static Vector2 ScreenBottomLeft { get { return new(0, GetScreenHeight()); } }
        public static Vector2 ScreenBottom { get { return new(GetScreenWidth() / 2, GetScreenHeight()); } }
        public static Vector2 ScreenBottomRight { get { return new(GetScreenWidth(), GetScreenHeight()); } }
        public static Vector2 ScreenRight { get { return new(GetScreenWidth(), GetScreenHeight() / 2); } }
        public static Vector2 ScreenTopRight { get { return new (GetScreenWidth(), 0); } }
        public static Vector2 ScreenTop { get { return new(GetScreenWidth()/2, 0); } }



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
