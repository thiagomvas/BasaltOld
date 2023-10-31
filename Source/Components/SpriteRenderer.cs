using GameEngineProject.Source.Core.Utils;
using GameEngineProject.Source.Entities;
using Raylib_cs;
using System.Numerics;

namespace GameEngineProject.Source.Components
{
    /// <summary>
    /// Renders a texture at a object's position. <br /> <br />
    /// 
    /// * Note: A file path to the <b>MUST BE SET</b> to render a texture.
    /// </summary>
    public class SpriteRenderer : Renderer
    {
        /// <summary>
        /// Whether or not the texture has been loaded
        /// </summary>
        public static bool TextureHasLoaded;
        /// <summary>
        /// The actual texture being rendered.
        /// </summary>
        public Texture2D? texture;
        /// <summary>
        /// The file path to the texture.
        /// </summary>
        public string texturePath;

        public override void Awake(GameObject gameObject)
        {
            base.Awake(gameObject);
            texture = Raylib.LoadTexture(texturePath);
        }
        public override void Render()
        {
            if (!parent.IsActive) return;
            if (texture != null) Raylib.DrawTexturePro(texture.Value,
                                                       new Rectangle(0, 0, texture.Value.width, texture.Value.height),
                                                       new Rectangle(transform.Position.X,
                                                                     transform.Position.Y,
                                                                     texture.Value.width,
                                                                     texture.Value.height),
                                                       new Vector2(texture.Value.width/2, texture.Value.height/2),
                                                       MathExtended.GetZRotation(transform.Rotation),
                                                       Color.WHITE);
            else Raylib.DrawCircle((int)transform.Position.X, (int)transform.Position.Y, 25, Color.BLUE);
        }

    }
}
