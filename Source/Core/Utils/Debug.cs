using static Raylib_cs.Raylib;
using System.Numerics;
using Raylib_cs;
using GameEngineProject.Source.Components;
using GameEngineProject.Source.Core.Types;
using GameEngineProject.Source.Core.UI;

namespace GameEngineProject.Source.Core.Utils
{
    public static class Debug
    {
        /// <summary>
        /// Whether or not the Debug System is enabled.
        /// </summary>
        public static bool IsDebugEnabled { get; private set; } = true;

        private static Collider2D? ObjectCollider;
        private const int MaxSelectionDistance = 50;
        private static Color FontColor = Color.WHITE;
        /// <summary>
        /// The GameObject currently being selected.
        /// </summary>
        public static GameObject? SelectedObject;

        /// <summary>
        /// Toggles the Debug System.
        /// </summary>
        public static void ToggleDebug() => IsDebugEnabled = !IsDebugEnabled;

        private static Label label;
        
        public static void Setup()
        {
            label = new(UI.ScreenLeft + new Vector2(600, 0));
            label.Text = "";
            label.SetPivot(UIElement.PivotPoint.Left);
            label.FontSize = 12;
            UI.Instantiate(label);
        }

        /// <summary>
        /// Draws all the Debug UI.
        /// </summary>
        public static void DrawDebugUI()
        {
            if (!IsDebugEnabled)
            {
                label.Text = "";
                return;
            }
            if(SelectedObject != null)
            {
                label.Text = Conversions.StringifyGameObject(SelectedObject);
            }
                
        }

        /// <summary>
        /// Selects the nearest GameObject to the cursor.
        /// </summary>
        /// <param name="mousePos">The Mouse Position</param>
        public static void SelectedNearestGameObject(Vector2 mousePos)
        {
            GameObject? nearest = null;
            int i = 0;
            foreach(var obj in Globals.GameObjectsOnScene)
            {
                float distanceToObject = Vector2.Distance(mousePos, Conversions.XYFromVector3(obj.Transform.Position));
                if (distanceToObject > MaxSelectionDistance) continue;
                if (nearest == null)
                {
                    nearest = obj;
                    continue;
                }
                else if (distanceToObject < Vector2.Distance(Conversions.XYFromVector3(nearest.Transform.Position), mousePos))
                {
                    nearest = obj;
                }
            }
            SelectedObject = nearest;
            if (SelectedObject is not null && SelectedObject.TryGetComponent(out Collider2D col)) ObjectCollider = col;
        }
    }
}
