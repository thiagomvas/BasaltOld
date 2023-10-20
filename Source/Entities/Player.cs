using GameEngineProject.Source.Core;
using GameEngineProject.Source.Core.Graphics;
using GameEngineProject.Source.Core.Utils;
using Raylib_cs;
using System.Numerics;
using static GameEngineProject.Source.Core.Utils.MathExtended;
using static GameEngineProject.Source.Core.Utils.Conversions;
using GameEngineProject.Source.Components;

namespace GameEngineProject.Source.Entities
{
    public class Player
    {
        public GameObject gameObject;
        public int id; 
        public int MovementSpeed = 250;
        Rigidbody rb;
        public Player(GameObject gameObject)
        {
            this.gameObject = gameObject;
            id = 0;
            GraphicsWindow2D.OnScreenRedraw += OnMovePlayer;
            rb = gameObject.GetComponent<Rigidbody>();
        }
        public void OnMovePlayer() => MovePlayer();
        public void MovePlayer()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) rb.Velocity.X = -MovementSpeed * Time.DeltaTime;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) rb.Velocity.X = MovementSpeed * Time.DeltaTime;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) rb.Velocity.Y = -MovementSpeed * Time.DeltaTime;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) rb.Velocity.Y =MovementSpeed * Time.DeltaTime;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_R)) gameObject.Transform.MoveTo(Vector2.Zero);

            Vector2 mouseCoordsOnWorld = ScreenToWorldPosition(Raylib.GetMousePosition(), Engine.Camera2D.Value);

            gameObject.Transform.Rotation = LookAtRotation(gameObject.Transform.Position, mouseCoordsOnWorld);
        }
    }
}
