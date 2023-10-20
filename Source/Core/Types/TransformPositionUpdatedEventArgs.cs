using System.Numerics;

namespace GameEngineProject.Source.Core.Types
{
    public class TransformPositionUpdatedEventArgs : EventArgs
    {
        /// <summary>
        /// The new position after moving.
        /// </summary>
        public Vector2 NewPosition { get; }

        public TransformPositionUpdatedEventArgs(Vector2 data)
        {
            NewPosition = data;
        }
    }
}
