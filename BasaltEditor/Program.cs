using BasaltEditor.Core;
using System.ComponentModel.DataAnnotations;

namespace BasaltEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Editor editor = new();
            editor.Init();
        }
    }
}
