using GameEngineProject.Source.Core;
using GameEngineProject.Source.Entities;
using System.Numerics;

namespace GameEngineProject.Source.Components
{
    public class CircleCollider : Collider2D
    {
        public int Radius = 25;
        public override void CheckCollision(GameObject other)
        {
            Vector3 dir = parent.transform.Position - other.transform.Position;
            var dist = dir.Length();
            if(other.TryGetComponent<CircleCollider>(out CircleCollider col) && dist < Radius + col.Radius)
            {
                InvokeOnCollision(other);
            }
        }
    }
}
