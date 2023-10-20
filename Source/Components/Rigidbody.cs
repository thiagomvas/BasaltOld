using GameEngineProject.Source.Core.Utils;
using System.Numerics;

namespace GameEngineProject.Source.Components
{
    public class Rigidbody : Component
    {
        public float Mass = 1f;
        public float Drag = 10f;
        public Vector2 Velocity = Vector2.Zero;
        public Vector2 Acceleration = Vector2.Zero;
        public float Restitution = 0;
        public Vector2 Gravity = Vector2.Zero;
        public Vector2 MaxVelocity = Vector2.One * 25;
        public bool IsKinematic = false;
        public float StoppingThreshold = 0.001f;

        public override void Update()
        {
            base.Update();

            Velocity += Acceleration * Time.DeltaTime;
            Velocity /= 1 + Drag * Time.DeltaTime;

            Acceleration = Vector2.Zero;

            if (Velocity.LengthSquared() < StoppingThreshold * StoppingThreshold) Velocity = Vector2.Zero;

            if(!IsKinematic) parent.Transform.Move(Velocity);
        }

        public void AddForce(Vector2 force)
        {
            Acceleration += force / Mass; 
        }
    }
}
