using System.Numerics;

namespace Basalt.Source.Core.Types
{
    public class TransformPositionUpdatedEventArgs : EventArgs
    {
        /// <summary>
        /// The new position after moving.
        /// </summary>
        public Vector3 NewPosition { get; }

        public TransformPositionUpdatedEventArgs(Vector3 data)
        {
            NewPosition = data;
        }
    }
}
