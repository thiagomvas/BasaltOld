using System.Numerics;

namespace GameEngineProject.Source.Core.Types
{
    public class TransformPositionUpdatedEventArgs : EventArgs
    {
        public Vector3 NewPosition { get; }

        public TransformPositionUpdatedEventArgs(Vector3 data)
        {
            NewPosition = data;
        }
    }
}
