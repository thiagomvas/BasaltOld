using Raylib_cs;

namespace Basalt.Source.Core.Utils
{
    public class InputSystem
    {
        #region Singleton Definition
        private static InputSystem instance;
        private InputSystem()
        {

        }

        public static InputSystem Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InputSystem();
                }
                return instance;
            }
        }
        #endregion

        private HashSet<int> keysDown = new();
        internal void CheckForInputs()
        {
            int key = Raylib.GetKeyPressed();
            if (key != 0)
            {
                keysDown.Add(key);
            }

            foreach (int k in keysDown)
            {
                if (Raylib.IsKeyReleased((KeyboardKey)k))
                {
                    keysDown.Remove(k);
                }
            }
        }

        public bool GetKey(KeyboardKey key) => keysDown.Contains((int)key);
        public bool GetKey(int keyCode) => keysDown.Contains(keyCode);

        public bool GetKeyPressed(KeyboardKey key) => Raylib.IsKeyPressed(key);
        public bool GetKeyPressed(int keyCode) => Raylib.IsKeyPressed((KeyboardKey)keyCode);

        public bool GetKeyReleased(KeyboardKey key) => Raylib.IsKeyReleased(key);
        public bool GetKeyReleased(int keyCode) => Raylib.IsKeyReleased((KeyboardKey)keyCode);
    }
}
