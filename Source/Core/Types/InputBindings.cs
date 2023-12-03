using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Basalt.Source.Core.Types
{
    public class InputBindings
    {
        private readonly Dictionary<string, int> bindings = new();
        
        public int GetBinding(string name) => bindings[name];
        public void AddBinding(string name, byte keyCode) => bindings.Add(name, keyCode);
        public void AddBinding(string name, KeyboardKey key) => bindings.Add(name, (int) key);
    }
}
