using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basalt.Source.Attributes
{
    /// <summary>
    /// Determines which components should be included in the object for this component to work.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class RequiredComponentsAttribute : Attribute
    {
        public Type[] RequiredTypes { get; }
        public RequiredComponentsAttribute(params Type[] requiredTypes)
        {
            RequiredTypes = requiredTypes;
        }
    }
}
