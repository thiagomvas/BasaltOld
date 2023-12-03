using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
