using GameEngineProject.Source.Entities;
using System.Numerics;

namespace GameEngineProject.Source.Core.Types
{
    public class OnCollisionEnterEventArgs : EventArgs
    {
        public GameObject collision { get; }

        public OnCollisionEnterEventArgs(GameObject collision)
        {
            this.collision = collision;
        }
    }
}
