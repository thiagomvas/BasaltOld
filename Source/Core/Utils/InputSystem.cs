using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private List<int> keysPressed = new();

        internal void CheckForInputs()
        {
            int key = Raylib.GetKeyPressed();
            if (key != 0)
            {
                keysPressed.Add(key);
            }

            foreach (int k in keysPressed.ToArray())
            {
                if (Raylib.IsKeyReleased((KeyboardKey)k))
                {
                    keysPressed.Remove(k);
                }
            }
        }

        public static bool GetKey(KeyboardKey key)
        {
            return Raylib.IsKeyDown(key);
        }
    }
}
