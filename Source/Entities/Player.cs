using GameEngineProject.Source.Core;
using GameEngineProject.Source.Core.Graphics;
using GameEngineProject.Source.Core.Utils;
using Raylib_cs;
using System.Numerics;
using static GameEngineProject.Source.Core.Utils.MathExtended;
using static GameEngineProject.Source.Core.Utils.Conversions;
using GameEngineProject.Source.Components;
using GameEngineProject.Source.Core.Types;

namespace GameEngineProject.Source.Entities
{
    /// <summary>
    /// Represents a player in the game.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Gets or sets the GameObject associated with the player.
        /// </summary>
        public GameObject gameObject;

        /// <summary>
        /// Gets the unique identifier for the player.
        /// </summary>
        public int id;

        /// <summary>
        /// Gets or sets the movement speed of the player.
        /// </summary>
        public int MovementSpeed = 250;

        /// <summary>
        /// Gets the Rigidbody component associated with the player's GameObject.
        /// </summary>
        Rigidbody rb;

        ObjectPooling pool = new();

        /// <summary>
        /// Initializes a new instance of the Player class with the provided GameObject.
        /// </summary>
        /// <param name="gameObject">The GameObject associated with the player.</param>
        public Player(GameObject gameObject)
        {
            this.gameObject = gameObject;
            id = 0;
            GraphicsWindow2D.OnScreenRedraw += OnMovePlayer;
            rb = gameObject.GetComponent<Rigidbody>();

            for (int i = 0; i < 10; i++)
            {
                GameObject proj = new GameObject();
                proj.Transform.Rotation = gameObject.Transform.Rotation;
                proj.AddComponent<Projectile>().Velocity = gameObject.Transform.Forward * 10;
                var rend = proj.AddComponent<CircleRenderer>();
                Globals.Instantiate(proj);
                pool.Populate(proj);
            }

        }

        /// <summary>
        /// Callback method for handling player movement.
        /// </summary>
        public void OnMovePlayer() => MovePlayer();

        /// <summary>
        /// Moves the player based on input controls and mouse position.
        /// </summary>
        public void MovePlayer()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE)) gameObject.IsActive = !gameObject.IsActive;

            if (!gameObject.IsActive) return;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) rb.Velocity.X = -MovementSpeed * Time.DeltaTime;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) rb.Velocity.X = MovementSpeed * Time.DeltaTime;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) rb.Velocity.Y = -MovementSpeed * Time.DeltaTime;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) rb.Velocity.Y = MovementSpeed * Time.DeltaTime;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_R)) gameObject.Transform.MoveTo(Vector2.Zero);

            if(Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_RIGHT))
            {
                var obj = pool.Get();
                obj.Transform.Position = gameObject.Transform.Position + gameObject.Transform.Forward * 25;
                obj.GetComponent<Projectile>().Velocity = gameObject.Transform.Forward * 10;
                obj.Transform.Rotation = gameObject.Transform.Rotation;
            }

            Vector2 mouseCoordsOnWorld = ScreenToWorldPosition(Raylib.GetMousePosition(), Engine.Camera2D.Value);

            gameObject.Transform.Rotation = LookAtRotation(gameObject.Transform.Position, mouseCoordsOnWorld);
        }
    }

}
