using GameEngineProject.Source.Entities;
using static Raylib_cs.Raylib;
using System.Numerics;
using Raylib_cs;
using GameEngineProject.Source.Components;

namespace GameEngineProject.Source.Core.Utils
{
    public static class Debug
    {
        /// <summary>
        /// Whether or not the Debug System is enabled.
        /// </summary>
        public static bool IsDebugEnabled { get; private set; } = true;

        private static Collider2D ObjectCollider;
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
                DrawText(Conversions.StringifyGameObject(SelectedObject), 12, 12, 10, FontColor);


                Vector2 screenPosition = MathExtended.WorldToScreenPosition(
                    SelectedObject.Transform.Position, 
                    Engine.Camera2D.Value);


                ObjectCollider.DrawDebugHitbox(screenPosition);
                Vector2 forward = SelectedObject.Transform.Forward;
                DrawLine((int)screenPosition.X, (int)screenPosition.Y, (int)(screenPosition.X + forward.X * 100), (int)(screenPosition.Y + forward.Y*100), Color.LIME);
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
                float distanceToObject = Vector2.Distance(mousePos, obj.Transform.Position);
                if (distanceToObject > MaxSelectionDistance) continue;
                if (nearest == null)
                {
                    nearest = obj;
                    continue;
                }
                else if (distanceToObject < Vector2.Distance(nearest.Transform.Position, mousePos))
                {
                    nearest = obj;
                }
            }
            SelectedObject = nearest;
            if (SelectedObject is not null && SelectedObject.TryGetComponent(out Collider2D col)) ObjectCollider = col;
        }
    }
}
