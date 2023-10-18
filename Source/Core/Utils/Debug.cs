using GameEngineProject.Source.Entities;
using static Raylib_cs.Raylib;
using System.Numerics;
using Raylib_cs;

namespace GameEngineProject.Source.Core.Utils
{
    public static class Debug
    {
        public static bool IsDebugEnabled { get; private set; } = true;

        private const int MaxSelectionDistance = 50;
        private static Color FontColor = Color.WHITE;
        public static GameObject? SelectedObject;

        public static void ToggleDebug() => IsDebugEnabled = !IsDebugEnabled;

        public static void DrawDebugUI()
        {
            if(SelectedObject != null)
            {
                DrawText(SelectedObject.ToString(), 12, 12, 20, FontColor);
            }
                
        }

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
