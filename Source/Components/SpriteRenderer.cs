using GameEngineProject.Source.Entities;
using Raylib_cs;

namespace GameEngineProject.Source.Components
{
    /// <summary>
    /// Renders a texture at a object's position. <br /> <br />
    /// 
    /// * Note: A file path to the <b>MUST BE SET</b> to render a texture.
    /// </summary>
    public class SpriteRenderer : Renderer2D
    {
        /// <summary>
        /// The actual texture being rendered.
        /// </summary>
        public Texture2D? texture;
        /// <summary>
        /// The file path to the texture.
        /// </summary>
        public string texturePath;
        public override void Initialize(GameObject gameObject)
        {
            base.Initialize(gameObject);
        }
        public override void Render()
        {
            if (texture != null) Raylib.DrawTexture(texture.Value, (int) transform.Position.X, (int)transform.Position.Y, Color.WHITE);
            else Raylib.DrawCircle((int)transform.Position.X, (int)transform.Position.Y, 25, Color.BLUE);
        }

    }
}
