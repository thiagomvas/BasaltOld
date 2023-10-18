using GameEngineProject.Source.Entities;
using System.Numerics;

namespace GameEngineProject.Source.Core.Utils
{
    public static class Debug
    {
        public static bool IsDebugEnabled { get; private set; } = true;
        private static GameObject? SelectedObject;

        public static void ToggleDebug() => IsDebugEnabled = !IsDebugEnabled;

        public static void SelectedNearestGameObject(Vector3 mousePos)
        {
            GameObject? nearest = null;
            int i = 0;
            foreach(var obj in Globals.GameObjectsOnScene)
            {
                if (nearest == null)
                {
                    nearest = obj;
                }
                else if (Vector3.Distance(mousePos, obj.transform.Position) < Vector3.Distance(nearest.transform.Position, mousePos))
                {
                    nearest = obj;
                }
            }
            SelectedObject = nearest;
        }
    }
}
