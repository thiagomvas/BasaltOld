using System.Numerics;

namespace Basalt.Source.Core.Types
{
    public class OnCollisionEnterEventArgs : EventArgs
    {
        /// <summary>
        /// The GameObject collided with.
        /// </summary>
        public GameObject Collision;

        public OnCollisionEnterEventArgs(GameObject collision)
        {
            Collision = collision;
        }
    }
}
