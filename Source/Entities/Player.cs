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

        public Vector3 Movement;

        /// <summary>
        /// Gets the unique identifier for the player.
        /// </summary>
        public int id;

        /// <summary>
        /// Gets or sets the movement speed of the player.
        /// </summary>
        public int MovementSpeed = 25;

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
            Engine.window.OnScreenRedraw += OnMovePlayer;
            rb = gameObject.GetComponent<Rigidbody>();

            for (int i = 0; i < 10; i++)
            {
                GameObject proj = new GameObject();
                proj.Transform.Rotation = gameObject.Transform.Rotation;
                proj.AddComponent<Projectile>().Velocity = gameObject.Transform.Forward * 10;
                var rend = proj.AddComponent<CircleRenderer>();
                proj.AddComponent<CircleCollider>();
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
            Movement = new Vector3((Raylib.IsKeyDown(KeyboardKey.KEY_W) || Raylib.IsKeyDown(KeyboardKey.KEY_UP) ? 1 : 0) * MovementSpeed * Time.DeltaTime -      // Move forward-backward
                                (Raylib.IsKeyDown(KeyboardKey.KEY_S)    || Raylib.IsKeyDown(KeyboardKey.KEY_DOWN) ? 1 : 0) * MovementSpeed * Time.DeltaTime,
                                (Raylib.IsKeyDown(KeyboardKey.KEY_D)    || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) ? 1 : 0) * MovementSpeed * Time.DeltaTime -   // Move right-left
                                (Raylib.IsKeyDown(KeyboardKey.KEY_A)    || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) ? 1 : 0) * MovementSpeed * Time.DeltaTime,
                                0.0f);
            gameObject.Transform.Move(Movement);
            if (Raylib.IsKeyDown(KeyboardKey.KEY_R)) gameObject.Transform.MoveTo(Vector3.Zero);

            if(Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_RIGHT))
            {
                var obj = pool.Get();
                obj.Transform.Position = gameObject.Transform.Position + gameObject.Transform.Forward * 25;
                obj.GetComponent<Projectile>().Velocity = gameObject.Transform.Forward * 10;
                obj.Transform.Rotation = gameObject.Transform.Rotation;
            }

            Vector2 mouseCoordsOnWorld = ScreenToWorldPosition(Raylib.GetMousePosition(), Engine.Camera.Camera2D);

            gameObject.Transform.Rotation = LookAtRotation(gameObject.Transform.Position, Conversions.XYToVector3(mouseCoordsOnWorld), Vector3.UnitY);
        }
    }

}
