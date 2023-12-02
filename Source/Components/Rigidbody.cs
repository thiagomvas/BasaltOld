using Basalt.Source.Core.Utils;
using System.Numerics;

namespace Basalt.Source.Components
{
    /// <summary>
    /// A component representing the physics properties of a game object, including mass, linear drag, velocity, and acceleration.
    /// </summary>
    public class Rigidbody : Component
    {
        /// <summary>
        /// Mass of the rigidbody (default: 1f).
        /// </summary>
        public float Mass = 1f;

        /// <summary>
        /// Linear drag coefficient (default: 10f).
        /// </summary>
        public float Drag = 10f;

        /// <summary>
        /// Current velocity of the rigidbody (initialized as zero).
        /// </summary>
        public Vector3 Velocity = Vector3.Zero;

        /// <summary>
        /// Current acceleration of the rigidbody (initialized as zero).
        /// </summary>
        public Vector3 Acceleration = Vector3.Zero;

        /// <summary>
        /// Determines if the rigidbody is kinematic (doesn't respond to forces).
        /// </summary>
        public bool IsKinematic = false;

        /// <summary>
        /// Threshold for stopping velocity to avoid small drifting (default: 0.001f).
        /// </summary>
        public float StoppingThreshold = 0.001f;

        public override void Update()
        {
            base.Update();

            // If the rigidbody is kinematic, don't perform any updates
            if (IsKinematic) return;

            // Update velocity based on acceleration
            Velocity += Acceleration;

            // Calculate and apply linear drag to the velocity
            Velocity += -Velocity * Drag * Time.DeltaTime;

            // Reset the acceleration
            Acceleration = Vector3.Zero;

            // Check if velocity is close to zero and clamp it to avoid small drifting
            if (Velocity.LengthSquared() < StoppingThreshold * StoppingThreshold)
            {
                Velocity = Vector3.Zero;
            }

            // Move the parent object using the updated velocity
            Parent.Transform.Move(Velocity);
        }

        /// <summary>
        /// Add a force to the rigidbody's acceleration.
        /// </summary>
        /// <param name="force">The force to be applied to the acceleration.</param>
        public void AddForce(Vector3 force)
        {
            Acceleration += force / Mass;
        }
    }

}
