using GameEngineProject.Source.Entities;
using System.Numerics;

namespace GameEngineProject.Source.Core.Types
{
    public class OnCollisionEnterEventArgs : EventArgs
    {
        /// <summary>
        /// The GameObject collided with.
        /// </summary>
        public GameObject Collision;

        public OnCollisionEnterEventArgs(GameObject collision)
        {
            this.Collision = collision;
        }
    }
}
