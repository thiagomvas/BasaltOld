using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Source.Attributes
{
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
