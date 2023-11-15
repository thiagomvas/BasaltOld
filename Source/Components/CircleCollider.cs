using Basalt.Source.Core.Types;
using Basalt.Source.Core.Utils;
using Raylib_cs;
using System.Numerics;

namespace Basalt.Source.Components
{/// <summary>
 /// Represents a 2D circle collider used for collision detection and resolution.
 /// </summary>
    public class CircleCollider : Collider2D
    {
        /// <summary>
        /// Gets or sets the radius of the collision circle.
        /// </summary>
        public int Radius { get; set; } = 25;

        /// <summary>
        /// Initializes the collider when a GameObject is started. 
        /// </summary>
        /// <param name="gameObject">The GameObject to which this collider is attached.</param>
        public override void Start(GameObject gameObject)
        {
            if (gameObject.TryGetComponent(out SpriteRenderer renderer))
            {
                // Calculate the radius based on the sprite's dimensions.
                Radius = (renderer.texture.Value.width + renderer.texture.Value.height) / 4;
            }
            base.Start(gameObject);
        }

        /// <summary>
        /// Checks for collisions with another GameObject.
        /// </summary>
        /// <param name="other">The GameObject to check for collision with.</param>
        public override void CheckCollision(GameObject other)
        {
            base.CheckCollision(other);
            Vector2 direction = Conversions.XYFromVector3(parent.Transform.Position - other.Transform.Position);
            var distance = direction.Length();
            if (other.TryGetComponent(out CircleCollider collider) && distance < Radius + collider.Radius)
            {
                InvokeOnCollision(other);
                SolveCollision(collider);
            }
        }

        /// <summary>
        /// Solves a collision with another Collider2D, if it is a CircleCollider.
        /// </summary>
        /// <param name="collided">The collider with which this collider has collided.</param>
        public override void SolveCollision(Collider2D collided)
        {
            base.SolveCollision(collided);
            if (collided is CircleCollider circleCollider)
            {
                Vector2 direction = Conversions.XYFromVector3(parent.Transform.Position - circleCollider.parent.Transform.Position);
                var delta = direction.Length();
                parent.Transform.Move(Conversions.XYToVector3(0.01f * delta * Vector2.Normalize(direction)));
                circleCollider.parent.Transform.Move(Conversions.XYToVector3(-0.01f * delta * Vector2.Normalize(direction)));
            }
        }

        /// <summary>
        /// Draws the debug hitbox of the collider on the screen.
        /// </summary>
        /// <param name="screenPos">The position on the screen where the hitbox should be drawn.</param>
        public override void DrawDebugHitbox(Vector2 screenPos)
        {
            base.DrawDebugHitbox(screenPos);
            Raylib.DrawCircleLines((int)screenPos.X, (int)screenPos.Y, Radius, Color.LIME);
        }
    }

}
