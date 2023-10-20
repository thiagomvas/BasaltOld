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
        public int MovementSpeed = 2500;
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
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) rb.AddForce(-Vector2.UnitX * MovementSpeed * Time.DeltaTime);
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) rb.AddForce(Vector2.UnitX * MovementSpeed * Time.DeltaTime);
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) rb.AddForce(-Vector2.UnitY * MovementSpeed * Time.DeltaTime);
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) rb.AddForce(Vector2.UnitY * MovementSpeed * Time.DeltaTime);
            if (Raylib.IsKeyDown(KeyboardKey.KEY_R)) gameObject.Transform.MoveTo(Vector2.Zero);
            if (Raylib.IsKeyDown(KeyboardKey.KEY_T)) rb.AddForce(Vector2.UnitY * 25);

            Vector2 mouseCoordsOnWorld = ScreenToWorldPosition(Raylib.GetMousePosition(), Engine.Camera2D.Value);

            gameObject.Transform.Rotation = LookAtRotation(gameObject.Transform.Position, mouseCoordsOnWorld);
        }
    }
}
