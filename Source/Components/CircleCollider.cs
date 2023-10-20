using GameEngineProject.Source.Core;
using GameEngineProject.Source.Entities;
using Raylib_cs;
using System.Numerics;

namespace GameEngineProject.Source.Components
{
    public class CircleCollider : Collider2D
    {
        public int Radius = 25;

        public override void Start(GameObject gameObject)
        {
            if(gameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer renderer)) 
                Radius = (renderer.texture.Value.width + renderer.texture.Value.height)/4;
            base.Start(gameObject);
        }
        public override void CheckCollision(GameObject other)
        {
            base.CheckCollision(other);
            Vector2 dir = parent.Transform.Position - other.Transform.Position;
            var dist = dir.Length();
            if(other.TryGetComponent<CircleCollider>(out CircleCollider col) && dist < Radius + col.Radius)
            {
                InvokeOnCollision(other);
                SolveCollision(col);
            }
        }

        public override void SolveCollision(Collider2D collided)
        {
            base.SolveCollision(collided);
            if(collided is CircleCollider)   
            {
                Vector2 dir = parent.Transform.Position - collided.parent.Transform.Position;
                var delta = dir.Length();
                parent.Transform.Move( 0.01f * delta * Vector2.Normalize(dir));
                collided.parent.Transform.Move( -0.01f * delta * Vector2.Normalize(dir));
            }
        }

        public override void DrawDebugHitbox(Vector2 screenPos)
        {
            base.DrawDebugHitbox(screenPos);
            Raylib.DrawCircleLines((int)screenPos.X, (int)screenPos.Y, Radius, Color.LIME);
        }
    }
}
