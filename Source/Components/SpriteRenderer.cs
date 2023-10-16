using GameEngineProject.Source.Entities;
using Raylib_cs;

namespace GameEngineProject.Source.Components
{
    public class SpriteRenderer : Renderer2D
    {
        Texture2D texture;
        public override void Initialize(GameObject gameObject)
        {
            base.Initialize(gameObject);
            texture = Raylib.LoadTexture("resources/raylib_logo.png");
        }
        public override void Render()
        {
            Raylib.DrawTexture(texture, (int) transform.Position.X, (int)transform.Position.Y, Color.WHITE);
            Raylib.DrawCircle((int)transform.Position.X, (int)transform.Position.Y, 25, Color.BLUE);
        }
    }
}
