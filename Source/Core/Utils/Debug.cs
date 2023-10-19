using GameEngineProject.Source.Entities;
using static Raylib_cs.Raylib;
using System.Numerics;
using Raylib_cs;

namespace GameEngineProject.Source.Core.Utils
{
    public static class Debug
    {
        /// <summary>
        /// Whether or not the Debug System is enabled.
        /// </summary>
        public static bool IsDebugEnabled { get; private set; } = true;

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

        /// <summary>
        /// Draws all the Debug UI.
        /// </summary>
        public static void DrawDebugUI()
        {
            if(SelectedObject != null)
            {
                DrawText(SelectedObject.ToString(), 12, 12, 20, FontColor);

                Vector2 topLeftScreenCornerRelativePos = Engine.Camera2D.Value.target - new Vector2((int)(GetScreenWidth()/2), (int)(GetScreenHeight()/2));
                Vector2 finalPosition = Conversions.XYFromVector3(SelectedObject.transform.Position) - topLeftScreenCornerRelativePos;
                DrawCircleLines((int)finalPosition.X, (int)finalPosition.Y, 25, Color.LIME);
                Vector3 forward = SelectedObject.transform.Forward;
                DrawLine((int)finalPosition.X, (int)finalPosition.Y, (int)(finalPosition.X + forward.X * 100), (int)(finalPosition.Y + forward.Y*100), Color.LIME);
            }
                
        }

        /// <summary>
        /// Selects the nearest GameObject to the cursor.
        /// </summary>
        /// <param name="mousePos">The Mouse Position</param>
        public static void SelectedNearestGameObject(Vector3 mousePos)
        {
            GameObject? nearest = null;
            int i = 0;
            foreach(var obj in Globals.GameObjectsOnScene)
            {
                float distanceToObject = Vector3.Distance(mousePos, obj.transform.Position);
                if (distanceToObject > MaxSelectionDistance) continue;
                if (nearest == null)
                {
                    nearest = obj;
                    continue;
                }
                else if (distanceToObject < Vector3.Distance(nearest.transform.Position, mousePos))
                {
                    nearest = obj;
                }
            }
            SelectedObject = nearest;
        }
    }
}
