using GameEngineProject.Source.Core;
using GameEngineProject.Source.Core.Graphics;
using Raylib_cs;
using System.Numerics;

namespace GameEngineProject.Source.Entities
{
    public class Player
    {
        public GameObject gameObject;
        public int id; 

        public Player(GameObject gameObject)
        {
            this.gameObject = gameObject;
            id = 0;
            GraphicsWindow2D.OnScreenRedraw += OnMovePlayer;
        }
        public void OnMovePlayer(object? sender, EventArgs e) => MovePlayer();
        public void MovePlayer()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) gameObject.transform.Move(-Vector3.UnitX * 10);
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) gameObject.transform.Move(Vector3.UnitX * 10);
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) gameObject.transform.Move(-Vector3.UnitY * 10);
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) gameObject.transform.Move(Vector3.UnitY * 10);
            if (Raylib.IsKeyDown(KeyboardKey.KEY_R)) gameObject.transform.MoveTo(Vector3.Zero);
        }
    }
}
